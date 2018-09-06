import React, { Fragment } from 'react';
import PropTypes from 'prop-types';

import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField'

import styles from 'stylesheets/textField.css'

const TextFieldMultiline = (props) => {
    const { classes, label, rows = 1, placeholder, input, meta: { touched, error }, style } = props;
    return (
        <Fragment>
            <TextField
                {...input}
                multiline
                rows={rows}
                label={label}
                placeholder={placeholder}
                className={classes.textField}
                margin="normal"
                InputLabelProps={{
                    shrink: true,
                }}
                style={style}
            />
            {touched && error && <span style={{ color: 'red' }}>{error}</span>}
        </Fragment>
    )
}


TextFieldMultiline.propTypes = {
    input: PropTypes.object,
    classes: PropTypes.object.isRequired,
    label: PropTypes.string,
    placeholder: PropTypes.string,
    meta: PropTypes.object,
    style: PropTypes.object,
    rows: PropTypes.number
};

export default withStyles(styles)(TextFieldMultiline);
