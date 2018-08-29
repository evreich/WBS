import React from "react";
import PropTypes from "prop-types";

import ButtonDelete from "../../Buttons/ButtonDelete";
import ButtonUpdate from "../../Buttons/ButtonUpdate";

import Dialog, {
    DialogActions,
    DialogContent,
    DialogTitle
} from "@material-ui/core/Dialog";
import Button from "@material-ui/core/Button";
import { withStyles } from "@material-ui/core/styles";

import styles from "./InformationModalWindow.css";
import TypesOfColumnData from "constants/typesOfColumnData";

class InformationModalWindow extends React.PureComponent {
    static propTypes = {
        cancel: PropTypes.func,
        formData: PropTypes.object,
        handleDeleteButtonClick: PropTypes.func,
        handleUpdateButtonClick: PropTypes.func,
        formFieldNames: PropTypes.array.isRequired,
        open: PropTypes.bool.isRequired,
        onExited: PropTypes.func,
        classes: PropTypes.object.isRequired
    };

    handleDeleteButtonClick = () => {
        const {
            formData: { id },
            handleDeleteButtonClick,
            cancel
        } = this.props;
        handleDeleteButtonClick(id);
        cancel();
    };

    handleUpdateButtonClick = () => {
        const { handleUpdateButtonClick } = this.props;
        handleUpdateButtonClick();
    };

    render() {
        const {
            formData,
            cancel,
            formFieldNames,
            open,
            classes,
            onExited
        } = this.props;
        const firstPropOfObj = formFieldNames[0];
        const otherPropsOfObj = formFieldNames.slice(1);

        return (
            <Dialog
                open={open}
                onExited={onExited}
                onClose={cancel}
                maxWidth={false}
            >
                <DialogTitle
                    className={classes.dialogTitle}
                    id="form-dialog-title"
                >
                    <div>Информационное окно</div>
                </DialogTitle>
                <DialogContent>
                    {formData && (
                        <div className={classes.dialogContent}>
                            <table border="0" cellPadding="5" cellSpacing="0">
                                <tbody>
                                    <tr className={classes.row}>
                                        <td>{firstPropOfObj.label}</td>
                                        <td>
                                            <div className={classes.cellValue}>
                                                {
                                                    formData[firstPropOfObj.propName]
                                                }
                                            </div>
                                        </td>
                                        <td>
                                            <ButtonDelete
                                                className={classes.deleteButton}
                                                onClick={
                                                    this.handleDeleteButtonClick
                                                }
                                                size={"small"}
                                            />
                                            <ButtonUpdate
                                                onClick={
                                                    this.handleUpdateButtonClick
                                                }
                                                size={"small"}
                                            />
                                        </td>
                                    </tr>
                                    {otherPropsOfObj.map(elem => (
                                        <tr
                                            className={classes.row}
                                            key={elem.propName}
                                        >
                                            <td>{elem.label}</td>
                                            <td>
                                                <div
                                                    className={
                                                        classes.cellValue
                                                    }
                                                >
                                                    {elem.type ===
                                                        TypesOfColumnData.ARRAY
                                                        ? formData[elem.propName].map(item => item.title).join(", ")
                                                        : formData[
                                                        elem.propName
                                                        ]}
                                                </div>
                                            </td>
                                            <td />
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                        </div>
                    )}
                    <DialogActions>
                        <Button
                            onClick={cancel}
                            variant="raised"
                            className={classes.submitButton}
                        >
                            ОК
                        </Button>
                    </DialogActions>
                </DialogContent>
            </Dialog>
        );
    }
}

export default withStyles(styles)(InformationModalWindow);
