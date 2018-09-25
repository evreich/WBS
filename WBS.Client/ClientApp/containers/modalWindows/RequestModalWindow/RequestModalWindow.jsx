import React from "react";
//import { connect } from 'react-redux';
import PropTypes from "prop-types";
import { reduxForm } from 'redux-form';

import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";
import Button from "@material-ui/core/Button";
import { withStyles } from '@material-ui/core/styles';

import MainFormBody from './parts/MainFormBody/MainFormBody';
import styles from './RequestModalWindow.css';

class RequestModalWindow extends React.Component {

    submit = (values) => console.log(values);

    render() {
        const { classes, header } = this.props;
        return (
            <Dialog open={true} onClose={close} maxWidth={false} classes={{ paper: classes.container }}>
                <DialogTitle id="form-dialog-title" className={classes.dialogTitle}>
                    <div>{header}</div>
                </DialogTitle>
                <DialogContent>
                    <form onSubmit={this.submit}>

                        <MainFormBody classes={classes} />
                        <h1>InvestmentTabs</h1>
                        <h1>RationaleForInvestment</h1>
                        <h1>ExpansionElementsComponent</h1>
                        <h1>Attachments</h1>

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

RequestModalWindow.propTypes = {
    close: PropTypes.func.isRequired,
    header: PropTypes.string,
    classes: PropTypes.object
};

export default withStyles(styles)(
    reduxForm({ form: "NewRequests" })(RequestModalWindow));