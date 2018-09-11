import React from "react";
import PropTypes from "prop-types";

import Dialog from "@material-ui/core/Dialog";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";
import { withStyles } from '@material-ui/core/styles';
import Clear from "@material-ui/icons/Clear";
import IconButton from "@material-ui/core/IconButton";

import styles from './ChooseItemModalWindow.css';

class ChooseItemModalWindow extends React.Component {
    constructor(props) {
        super(props);
        this.dialogContent = React.createRef();
    }

    static propTypes = {
        cancel: PropTypes.func.isRequired,
        error: PropTypes.object,
        open: PropTypes.bool.isRequired,
        data: PropTypes.any,
        classes: PropTypes.object,
        formFields: PropTypes.object,
        header: PropTypes.string,
        children: PropTypes.object
    };


    render() {
        const { open, cancel, data, classes, header, children } = this.props;

        const dialogBodyComponent = React.Children.map(children, child => React.cloneElement(child, {
            onRef: instance => { this.dialogContent = instance },
            data
        }));

        return (
            <Dialog open={open} maxWidth={"md"} onClose={cancel}>
                <DialogTitle id="form-dialog-choose">
                    <div className={classes.dialogTitle}>
                        <div className={classes.header}>{header}</div>
                        <IconButton
                            className={classes.cancelButton}
                            color="secondary"
                            onClick={cancel}
                        >
                            <Clear />
                        </IconButton>
                    </div>
                </DialogTitle>
                <DialogContent>
                    {dialogBodyComponent}
                    {/*<Filters
                        technicalServs={technicalServs}
                        applyFilter={getFilteredDataTable}
                        reset={getDataTable}
                    />
                        <Paper>
                            <ProvidersTable
                                data={data}
                                sortingData={sortingData}
                                paginationData={paginationData}
                                emptyRows={emptyRows}
                                actions={actions}
                                add={this.add}
                            />
                        </Paper>*/}
                </DialogContent>
            </Dialog>
        );
    }
}

export default withStyles(styles)(ChooseItemModalWindow);