import React from "react";
import PropTypes from "prop-types";
import Dialog, {
    DialogActions,
    DialogContent,
    DialogTitle
} from "material-ui/Dialog";
import Button from "material-ui/Button";
import styles from './ChangeItemModalWindow.css'
import { withStyles } from 'material-ui/styles';

class ChangeItemModalWindow extends React.Component {
    constructor(props) {
        super(props);
        this.dialogContent = React.createRef();
    }

    static propTypes = {
        cancel: PropTypes.func.isRequired,
        save: PropTypes.func.isRequired,
        getGroupsForSelect: PropTypes.func,
        groups: PropTypes.array,
        error: PropTypes.object,
        open: PropTypes.bool.isRequired,
        data: PropTypes.any,
        DialogBodyComponent: PropTypes.func.isRequired,
        classes: PropTypes.object 
    };

    onSaveButtonClick = () => {
        const values = this.dialogContent.getDataToSave();
        const { save, cancel } = this.props;
        if(values) {
            save(values);
            cancel(values);
        }
    };

    render() {
        const { open, cancel, data, DialogBodyComponent, classes } = this.props;
        const header = data && data.id ? "Редактирование" : "Создание";
        return (
            <Dialog open={open} onClose={this.cancel} maxWidth={'xs'}>
                <DialogTitle id="form-dialog-title" className={classes.dialogTitle}>
                    <div>{header}</div>
                </DialogTitle>
                <DialogContent>
                    <DialogBodyComponent onRef={instance => {this.dialogContent = instance}} data={data} />
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
