import React from "react";
import PropTypes from "prop-types";

import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";
import Button from "@material-ui/core/Button";
import Divider from "@material-ui/core/Divider";
import { withStyles } from "@material-ui/core/styles";

import moment from "moment";

import styles from "./ApplicationForInvestmentForm.css";
import HTTP_METHOD from "settings/httpMethods";
import MainFormBody from "./MainFormBody/MainFormBody";
import InvestmentTabs from "./tabComponents/InvestmentTabs";
import Attachments from "./Attachments";
import ExpansionElementsComponent from "./expansionComponents/ExpansionElementsComponent";
import RationaleForInvestment from "./RationaleForInvestment/RationaleForInvestment";
import DATE_FORMAT from "../../../../constants/dateFormat";

let mainFormBodyRef = React.createRef();
let investmentTabsRef = React.createRef();
let rationaleForInvestment = React.createRef();
let expansionComponents = React.createRef();

const ApplicationForInvestmentForm = props => {

    const { classes, cancel, open, formFields, data } = props;
    const {
        mainDialogBodyFields,
        rationaleForInvestmenFields,
        expansionElementsFields
    } = formFields;

    let dataToMainBody, dataToRationaleForInvestment, dataToExpansionElements;
    
    //destruct "data" to part of form
    if (data) {
        const getDefineFieldsFromData = defineFields => { 
            let accumObj = {};

            defineFields.forEach(field => accumObj = ({ ...accumObj, [field]: data[field] }));        
            return accumObj;
        }

        dataToMainBody = getDefineFieldsFromData(Object.keys(mainDialogBodyFields));
        dataToRationaleForInvestment = getDefineFieldsFromData(Object.keys(rationaleForInvestmenFields));
        dataToExpansionElements = getDefineFieldsFromData(Object.keys(expansionElementsFields));
    }

    const onSaveButtonClick = () => {
        const { save, cancel, data, currentPage, elementsPerPage } = props;

        const mainFormValues = mainFormBodyRef.getDataToSave();
        const investmentTabsValues = investmentTabsRef.getDataToSave();
        const rationaleForInvestmentValues = rationaleForInvestment.getDataToSave();
        const expansionComponentsValues = expansionComponents.getDataToSave();

        const allFormValues = {
            ...mainFormValues,
            ...investmentTabsValues,
            ...rationaleForInvestmentValues,
            ...expansionComponentsValues,
            subject: data ? data.subject : "-",
            creationData: data ? data.creationData : moment().format(DATE_FORMAT),
            lastModifiedData: moment().format(DATE_FORMAT),
            id: data ? data.id : 0
        };

        if (allFormValues) {
            let method = data ? HTTP_METHOD.HTTP_PUT : HTTP_METHOD.HTTP_POST;

            save(currentPage, elementsPerPage, method, allFormValues);
            cancel(allFormValues);
        }
    };

    return (
        <Dialog open={open} onClose={cancel} maxWidth={false} disableEnforceFocus={true}>
            <DialogTitle className={classes.dialogTitle}>
                <div>
                    <div>Заявка на получение инвестиции</div>
                    <Button color="secondary" style={{ color: "#fafafa" }}>
                        Запустить рабочий процесс
                    </Button>
                </div>
            </DialogTitle>
            <DialogContent>
                {/*Базовые поля формы */}
                <MainFormBody
                    onRef={instance => (mainFormBodyRef = instance)}
                    formFields={mainDialogBodyFields}
                    data={dataToMainBody}
                    classes={classes}
                />

                {/* Переключатель по вкладкам */}
                <InvestmentTabs
                    classes={classes}dataToRationaleForInvestment
                    onRef={instance => (investmentTabsRef = instance)}
                />

                <Divider />

                <RationaleForInvestment
                    onRef={instance => (rationaleForInvestment = instance)}
                    data={dataToRationaleForInvestment}
                    formFields={rationaleForInvestmenFields}
                    classes={classes}
                />

                {/* Выпадающие меню */}
                <ExpansionElementsComponent
                    formFields={expansionElementsFields}
                    data={dataToExpansionElements}
                    classes={classes}
                    onRef={instance => (expansionComponents = instance)}
                />

                <Attachments classes={classes} />

                <DialogActions>
                    {/* <span style={{ flex: 1 }}>
                        <Button
                            onClick={cancel}
                            variant="raised"
                            disabled={removeButtonEnable}
                            className={classes.cancelButton}
                        >
                            Удалить
                        </Button>
                    </span> */}
                    <Button onClick={cancel} className={classes.cancelButton}>
                        Отмена
                    </Button>
                    <Button
                        type="submit"
                        variant="raised"
                        className={classes.saveButton}
                        onClick={onSaveButtonClick}
                    >
                        Сохранить
                    </Button>
                </DialogActions>
            </DialogContent>
        </Dialog>
    );
};

ApplicationForInvestmentForm.propTypes = {
    cancel: PropTypes.func,
    classes: PropTypes.object.isRequired,
    save: PropTypes.func.isRequired,
    data: PropTypes.any,
    currentPage: PropTypes.number,
    elementsPerPage: PropTypes.number,
    open: PropTypes.bool,
    formFields: PropTypes.object
};

export default withStyles(styles)(ApplicationForInvestmentForm);
