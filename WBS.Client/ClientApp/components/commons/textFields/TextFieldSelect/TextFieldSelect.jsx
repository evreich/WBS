import React, { Fragment } from 'react';
import PropTypes from 'prop-types';

import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import MenuItem from '@material-ui/core/MenuItem';
//import CircularProgress from '@material-ui/core/CircularProgress';

import styles from 'stylesheets/textField.css'

// компонент выпадающий список TextFieldSelect
// ожидаемый вх.параметр items должен представлять собой массив обьектов вида {value, text}
const TextFieldSelect = (props) => {
    const { classes, items, input, label, style, selectionChanged, value,
        /*loading = true,*/ disabled = false, meta: { touched, error } = {} } = props;
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
                    MenuProps: { className: classes.menu },
                    //TODO: if loading
                    //IconComponent: () => <CircularProgress style={{ marginLeft: 'auto' }} size={20} />
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
        </Fragment >
    )
}

TextFieldSelect.propTypes = {
    items: PropTypes.array.isRequired,

    selectionChanged: PropTypes.func,
    label: PropTypes.string,
    classes: PropTypes.object,
    input: PropTypes.object,
    meta: PropTypes.object,
    style: PropTypes.object,
    disabled: PropTypes.bool,
    loading: PropTypes.bool,
    value: PropTypes.oneOfType([
        PropTypes.number,
        PropTypes.string
    ])
};

export default withStyles(styles)(TextFieldSelect);
