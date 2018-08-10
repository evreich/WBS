import React from "react";
import PropTypes from "prop-types";

import Dialog, {
    DialogActions,
    DialogContent,
    DialogTitle
} from "material-ui/Dialog";
import Button from "material-ui/Button";
import { withStyles } from 'material-ui/styles';

import styles from './ChangeItemModalWindow.css';
import HTTP_METHOD from '../../../../settings/httpMethods';

class ChangeItemModalWindow extends React.Component {
    constructor(props) {
        super(props);
        this.dialogContent = React.createRef();
    }

    static propTypes = {
        cancel: PropTypes.func.isRequired,
        save: PropTypes.func.isRequired,
        error: PropTypes.object,
        open: PropTypes.bool.isRequired,
        data: PropTypes.any,
        currentPage: PropTypes.number,
        elementsPerPage: PropTypes.number,
        classes: PropTypes.object,
        formFields: PropTypes.object,
        header: PropTypes.string,
        children: PropTypes.object
    };

    onSaveButtonClick = () => {
        const values = this.dialogContent.getDataToSave();
        const { save, cancel, data, currentPage, elementsPerPage } = this.props;

        if(values) {
            let method = data ? HTTP_METHOD.HTTP_PUT : HTTP_METHOD.HTTP_POST;

            save(currentPage, elementsPerPage, method, values);
            cancel(values);
        }
    };

    render() {
        const { open, cancel, data, formFields, classes, header, children } = this.props;

        const dialogBodyComponent = React.Children.map(children, child => React.cloneElement(child, { 
            onRef: instance => { this.dialogContent = instance },                         
            data,
            formFields
        }));

        return (
            <Dialog open={open} onClose={cancel} maxWidth={false} classes={{paper: classes.container}}>
                <DialogTitle id="form-dialog-title" className={classes.dialogTitle}>
                    <div>{header}</div>
                </DialogTitle>
                <DialogContent>
                    { dialogBodyComponent }
                </DialogContent>
                <DialogActions>
                    <Button
                        onClick={this.onSaveButtonClick}
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
            </Dialog>
        );
    }
}

export default withStyles(styles)(ChangeItemModalWindow);
