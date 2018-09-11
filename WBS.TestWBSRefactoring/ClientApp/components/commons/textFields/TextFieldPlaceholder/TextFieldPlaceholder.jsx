import React, { Fragment } from 'react';
import PropTypes from 'prop-types';

import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';

import styles from 'stylesheets/textField.css'

class TextFieldPlaceholder extends React.Component {
    state = {
        multiline: 'Controlled',
    };

    render() {
        const { classes, input, label, placeholder, type, disabled = false, style, meta: { touched, error } = {} } = this.props;

        return (
            <Fragment>
                <TextField
                    {...input}
                    type={type}
                    label={label}
                    placeholder={placeholder}
                    className={classes.textField}
                    margin="normal"
                    disabled={disabled}
                    InputLabelProps={{
                        shrink: true,
                    }}
                    style={style}
                />
                {touched && error && <span style={{ color: 'red' }}>{error}</span>}
            </Fragment>
        )
    }
}

TextFieldPlaceholder.propTypes = {
    disabled: PropTypes.bool,
    input: PropTypes.object,
    meta: PropTypes.object,
    type: PropTypes.string,
    classes: PropTypes.object.isRequired,
    label: PropTypes.string,
    placeholder: PropTypes.string,
    style: PropTypes.object
};

export default withStyles(styles)(TextFieldPlaceholder);
