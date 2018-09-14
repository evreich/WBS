import React from "react";
import PropTypes from "prop-types";

import { Field, reduxForm } from 'redux-form';
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";
import Button from "@material-ui/core/Button";
import { withStyles } from '@material-ui/core/styles';

import styles from './ChangeItemModalWindow.css';
import fields from 'constants/textFields';
import HTTP_METHOD from 'constants/httpMethods';

class ChangeItemModalWindow extends React.Component {
    submit = (values) => {
        const { /*validate, */save, close, initialValues, currentPage, elementsPerPage } = this.props;
        //validate(values);
        //save(values);

        if (values) {
            let method = initialValues ? HTTP_METHOD.HTTP_PUT : HTTP_METHOD.HTTP_POST;

            save(currentPage, elementsPerPage, method, values);
            close();
        }
        //validation
        /*return new Promise((resolve, reject) => {
            const { save } = this.props;
            save(values, resolve, reject)
        })*/
    };

    static propTypes = {
        handleSubmit: PropTypes.func.isRequired,
        close: PropTypes.func.isRequired,
        save: PropTypes.func.isRequired,
        error: PropTypes.object,
        data: PropTypes.any, //TODO
        classes: PropTypes.object,
        formFields: PropTypes.object,
        header: PropTypes.string,
        initialValues: PropTypes.object,
        currentPage: PropTypes.number,
        elementsPerPage: PropTypes.number
    };

    render() {
        const { close, /*data,*/ formFields, classes, header, handleSubmit } = this.props;

        return (
            <Dialog open={true} onClose={close} maxWidth={false} classes={{ paper: classes.container }}>
                <DialogTitle id="form-dialog-title" className={classes.dialogTitle}>
                    <div>{header}</div>
                </DialogTitle>
                <DialogContent>
                    <form onSubmit={handleSubmit(this.submit)}>
                        {
                            Object.values(formFields).map(field => {
                                const { fieldComponent, propName, label } = field || {};
                                const component = fields[fieldComponent];
                                return (
                                    <div key={propName}>
                                        < Field
                                            component={component}
                                            name={propName}
                                            label={label}
                                        />
                                    </div>
                                )
                            })
                        }
                        <DialogActions>
                            <Button
                                type="submit"
                                variant="raised"
                                className={classes.saveButton}
                            >
                                Сохранить
                            </Button>
                            <Button
                                onClick={close}
                                className={classes.cancelButton}
                            >
                                Отмена
                            </Button>
                        </DialogActions>
                    </form>
                </DialogContent>

            </Dialog>
        );
    }
}

export default withStyles(styles)(
    reduxForm({ form: 'ChangeItemModalForm' })(
        ChangeItemModalWindow
    )
);
