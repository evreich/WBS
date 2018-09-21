import React, { Fragment } from 'react';
import PropTypes from 'prop-types';

import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import MenuItem from '@material-ui/core/MenuItem';

import styles from 'stylesheets/textField.css'

// компонент выпадающий список TextFieldSelect
// ожидаемый вх.параметр items должен представлять собой массив обьектов вида {value, text}
const TextFieldSelect = (props) => {
    const { classes, items, input, label, disabled = false, style, selectionChanged, value, meta: { touched, error } = {} } = props;
    return (
        <Fragment>
            <TextField
                onChange={selectionChanged}
                value={value}
                {...input}
                select
                className={classes.textField}
                label={label}
                SelectProps={{
                    MenuProps: {
                        className: classes.menu,
                    },
                }}
                margin="normal"
                style={style}
                disabled={disabled}
            >
                {items.map((item) =>
                    <MenuItem key={item.value} value={item.value}>
                        {item.text}
                    </MenuItem>
                )}
            </TextField>
            {touched && error && <span style={{ color: 'red' }}>{error}</span>}
        </Fragment>
    )
}

TextFieldSelect.propTypes = {
    label: PropTypes.string,
    classes: PropTypes.object,
    items: PropTypes.array.isRequired,
    input: PropTypes.object,
    meta: PropTypes.object,
    style: PropTypes.object,
    disabled: PropTypes.bool,
    selectionChanged: PropTypes.func,
    value: PropTypes.oneOfType([
        PropTypes.number,
        PropTypes.string
    ])
};

export default withStyles(styles)(TextFieldSelect);
