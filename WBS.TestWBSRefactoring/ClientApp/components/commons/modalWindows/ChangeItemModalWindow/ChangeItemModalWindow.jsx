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
import TextFieldMultiline from "../../textFields/TextFieldMultiline/TextFieldMultiline";

class ChangeItemModalWindow extends React.Component {
    submit = (values) => {
        console.log(values);
        //validation
        /*return new Promise((resolve, reject) => {
            const { save } = this.props;
            save(values, resolve, reject)
        })*/
    };

    cancel = () => {
        const { cancel } = this.props
        cancel();
    };

    static propTypes = {
        handleSubmit: PropTypes.func.isRequired,
        cancel: PropTypes.func.isRequired,
        save: PropTypes.func.isRequired,
        error: PropTypes.object,
        data: PropTypes.any, //TODO
        classes: PropTypes.object,
        formFields: PropTypes.object,
        header: PropTypes.string
    };

    render() {
        const { cancel, /*data,*/ formFields, classes, header, handleSubmit } = this.props;

        /*const dialogBodyComponent = React.Children.map(children, child => React.cloneElement(child, {
            onRef: instance => { this.dialogContent = instance },
            data,
            formFields
        }));*/

        return (
            <Dialog open={true} onClose={cancel} maxWidth={false} classes={{ paper: classes.container }}>
                <DialogTitle id="form-dialog-title" className={classes.dialogTitle}>
                    <div>{header}</div>
                </DialogTitle>
                <DialogContent>
                    <form onSubmit={handleSubmit(this.submit)}>
                        {
                            Object.values(formFields).map((field) => (
                                <div key={field.propName}>
                                    < Field
                                        component={TextFieldMultiline}
                                        name={field.propName}
                                        label={field.label}
                                    />
                                </div>
                                /*if (field.isVisible) {
                                   switch (field.component) {
                                       case componentTypes.TEXT_FIELD:
       
                                           break;
                                       case componentTypes.TEXT_FIELD_MULTILINE:
                                           <Field
                                               component={TextFieldMultiline}
                                               ...
                                           />
                                           break;
                                           {  и т.д.... }
                                   }
                                 }*/
                            ))
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
                                onClick={cancel}
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
