import React from "react";
import PropTypes from "prop-types";

import ButtonDelete from "../../Buttons/ButtonDelete";
import ButtonUpdate from "../../Buttons/ButtonUpdate";

import Dialog, {
    DialogActions,
    DialogContent,
    DialogTitle
} from "material-ui/Dialog";
import Button from "material-ui/Button";
import styles from "./InformationModalWindow.css";
import { withStyles } from "material-ui/styles";

class InformationModalWindow extends React.PureComponent {
    static propTypes = {
        cancel: PropTypes.func,
        formData: PropTypes.object.isRequired,
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
        const { formData, handleUpdateButtonClick } = this.props;
        handleUpdateButtonClick(formData);
    };

    render() {
        const { formData, cancel, formFieldNames, open, classes, onExited } = this.props;
        const firstPropOfObj = formFieldNames[0];
        const otherPropsOfObj = formFieldNames.slice(1);

        return (
            <Dialog open={open} onExited={onExited} onClose={cancel} maxWidth={false}>
                <DialogTitle
                    className={classes.dialogTitle}
                    id="form-dialog-title"
                >
                    <div>Информационное окно</div>
                </DialogTitle>
                <DialogContent>
                    {formData &&
                        <div className={classes.dialogContent}>
                            <table border="0" cellPadding="5" cellSpacing="0">
                                <tbody>
                                    <tr className={classes.row}>
                                        <td>{firstPropOfObj.label}</td>
                                        <td>
                                            <div className={classes.cellValue}>
                                                {formData[firstPropOfObj.id]}
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
                                        <tr className={classes.row} key={elem.id}>
                                            <td>{elem.label}</td>
                                            <td>
                                                <div className={classes.cellValue}>
                                                    {formData[elem.id]}
                                                </div>
                                            </td>
                                            <td />
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                        </div>
                    }
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
