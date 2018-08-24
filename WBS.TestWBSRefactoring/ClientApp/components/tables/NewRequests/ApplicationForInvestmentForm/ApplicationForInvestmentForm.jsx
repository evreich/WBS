import React from "react";
import PropTypes from "prop-types";

import Dialog, {
    DialogActions,
    DialogContent,
    DialogTitle
} from "material-ui/Dialog";
import Button from "material-ui/Button";
import Divider from "material-ui/Divider";
import { withStyles } from "material-ui/styles";

import styles from "./ApplicationForInvestmentForm.css";
import HTTP_METHOD from "settings/httpMethods";
import MainFormBody from "./MainFormBody/MainFormBody";
import InvestmentTabs from "./tabComponents/InvestmentTabs";
import Attachments from "./Attachments";
import ExpansionElementsComponent from "./expansionComponents/ExpansionElementsComponent";
import RationaleForInvestment from "./RationaleForInvestment/RationaleForInvestment";

let mainFormBodyRef = React.createRef();
let investmentTabsRef = React.createRef();
let rationaleForInvestment = React.createRef();
let expansionComponents = React.createRef();

const ApplicationForInvestmentForm = props => {
    //заносим все поля объекта в state компонента;
    //каждому элементу массива объектов technicalServices соответсвует чекбокс на форме, поэтому
    //расскладываем массив technicalServices в state на поля вида [technicalServices.title]:true

    // static getDerivedStateFromProps(nextProps) {
    //     if (nextProps.data) {
    //         const techServsIsNotEmpty =
    //             nextProps.data.technicalServices.length > 0;
    //         const techServs = techServsIsNotEmpty
    //             ? nextProps.data.technicalServices
    //                   .map(t => ({ [t.title]: true }))
    //                   .reduce(
    //                       (accum, currElem) =>
    //                           (accum = { ...accum, ...currElem })
    //                   )
    //             : {};
    //         const radioBlock = techServsIsNotEmpty
    //             ? "techServsSelected"
    //             : "aribaSelected";

    //         return { ...nextProps.data, ...techServs, radioBlock };
    //     } else return null;
    // };

    const onSaveButtonClick = () => {
        const { save, cancel, data, currentPage, elementsPerPage } = props;

        //TODO: rename
        //берем данные с связанных частей формы
        const values1 = mainFormBodyRef.getDataToSave();
        const values2 = investmentTabsRef.getDataToSave();
        const values3 = rationaleForInvestment.getDataToSave();
        const values4 = expansionComponents.getDataToSave();

        const allFormValues = {
            ...values1,
            ...values2,
            ...values3,
            ...values4
        };

        if (allFormValues) {
            let method = data ? HTTP_METHOD.HTTP_PUT : HTTP_METHOD.HTTP_POST;

            save(currentPage, elementsPerPage, method, allFormValues);
            cancel(allFormValues);
        }
    };

    const { classes, cancel, open, formFields } = props;
    const removeButtonEnable = true;
    const {
        mainDialogBodyFields,
        rationaleForInvestmenFields,
        expansionElementsFields
    } = formFields;

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
                    classes={classes}
                />

                {/* Переключатель по вкладкам */}
                <InvestmentTabs
                    classes={classes}
                    onRef={instance => (investmentTabsRef = instance)}
                />

                <Divider />

                <RationaleForInvestment
                    onRef={instance => (rationaleForInvestment = instance)}
                    formFields={rationaleForInvestmenFields}
                    classes={classes}
                />

                {/* Выпадающие меню */}
                <ExpansionElementsComponent
                    formFields={expansionElementsFields}
                    classes={classes}
                    onRef={instance => (expansionComponents = instance)}
                />

                {/* Attachments */}
                <Attachments classes={classes} />

                <DialogActions>
                    <span style={{ flex: 1 }}>
                        <Button
                            onClick={cancel}
                            variant="raised"
                            disabled={removeButtonEnable}
                            className={classes.cancelButton}
                        >
                            Удалить
                        </Button>
                    </span>
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
