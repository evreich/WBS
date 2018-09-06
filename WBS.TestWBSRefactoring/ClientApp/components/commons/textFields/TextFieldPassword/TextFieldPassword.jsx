import React, { Fragment } from 'react';
import PropTypes from 'prop-types';

import { withStyles } from 'material-ui/styles';
import TextField from 'material-ui/TextField';

import styles from 'stylesheets/textField.css'

class TextFieldPlaceholder extends React.Component {

    render() {
        const { classes, label, placeholder, text, onHandleChange } = this.props;

        return (
            <Fragment>
                <TextField
                    inputRef={e => this.textf = e}
                    label={label}
                    placeholder={placeholder}
                    className={classes.textField}
                    margin="normal"
                    value={text}
                    onChange={(event) => onHandleChange(event.target.value)}
                    type="password"
                    autoComplete="current-password"
                />
            </Fragment>
        )
    }
}

TextFieldPlaceholder.propTypes = {
    classes: PropTypes.object.isRequired,
    label: PropTypes.string,
    placeholder: PropTypes.string,
    text: PropTypes.string,
    onHandleChange: PropTypes.func,
    disabled: PropTypes.bool,
};

export default withStyles(styles)(TextFieldPlaceholder);