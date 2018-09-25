import React from "react";
import { connect } from 'react-redux';
import PropTypes from "prop-types";

import { Field, reduxForm } from 'redux-form';
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";
import Button from "@material-ui/core/Button";
import { withStyles } from '@material-ui/core/styles';
import CircularProgress from '@material-ui/core/CircularProgress';

import styles from './ChangeItemModalWindow.css';
import fields from 'constants/textFields';
import HTTP_METHOD from 'constants/httpMethods';
import {
    getDataForModalForm,
    getDescriptorsForModalForm,
    clearComponentData
} from 'actions/componentsActions';

export default (route,
    componentName,
    objectType,
    mapStateToProps = defaultMapStateToProps(componentName),
    mapDispatchToProps = defaultMapDispatchToProps(route, componentName, objectType)
) => {
    class ChangeItemModalWindow extends React.Component {
        componentDidMount() {
            const { getInitialValues, getDescriptors, itemId } = this.props;
            getDescriptors();
            if (itemId)
                getInitialValues(itemId);
        }

        componentWillUnmount() {
            const { clearComponentData } = this.props;
            clearComponentData();
        }

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

        render() {
            const { close, descriptors, classes, header, handleSubmit, loading = true } = this.props;

            return (
                <Dialog open={true} onClose={close} maxWidth={false} classes={{ paper: classes.container }}>
                    <DialogTitle id="form-dialog-title" className={classes.dialogTitle}>
                        <div>{header}</div>
                    </DialogTitle>
                    <DialogContent>
                        {
                            loading ?
                                <div className={classes.loaderContainer}>
                                    <CircularProgress className={classes.loader} size={75} />
                                </div>
                                :
                                <form onSubmit={handleSubmit(this.submit)}>
                                    {
                                        descriptors &&
                                        Object.values(descriptors).map(field => {
                                            const { fieldComponent, propName, label, canEdit } = field || {};
                                            const component = fields[fieldComponent];
                                            return (
                                                <div key={propName}>
                                                    < Field
                                                        component={component}
                                                        name={propName}
                                                        label={label}
                                                        disabled={!canEdit}
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
                        }
                    </DialogContent>
                </Dialog>
            );
        }
    }

    ChangeItemModalWindow.propTypes = {
        handleSubmit: PropTypes.func.isRequired,
        close: PropTypes.func.isRequired,
        save: PropTypes.func.isRequired,
        getInitialValues: PropTypes.func.isRequired,
        getDescriptors: PropTypes.func.isRequired,
        clearComponentData: PropTypes.func.isRequired,

        error: PropTypes.object,
        data: PropTypes.any, //TODO
        classes: PropTypes.object,
        descriptors: PropTypes.object,
        header: PropTypes.string,
        initialValues: PropTypes.object,
        currentPage: PropTypes.number,
        elementsPerPage: PropTypes.number,
        itemId: PropTypes.number,
        loading: PropTypes.bool
    };

    return connect(mapStateToProps, mapDispatchToProps)(
        withStyles(styles)(
            reduxForm({ form: componentName })(ChangeItemModalWindow)
        )
    );
}

const defaultMapStateToProps = componentName => state => (
    state.components[componentName]
        ? {
            initialValues: state.components[componentName].data,
            descriptors: state.components[componentName].descriptors,
            loading: state.components[componentName].isFetching
        }
        : {}
);

const defaultMapDispatchToProps = (route, componentName, objectType) => (dispatch) => ({
    getInitialValues: (id) => dispatch(getDataForModalForm(route, componentName, id)),
    getDescriptors: (id) => dispatch(getDescriptorsForModalForm(componentName, objectType, id)),
    clearComponentData: () => dispatch(clearComponentData(componentName))
});