import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from 'material-ui/styles';
import styles from '../TextFields/TextField.css'
import TextField from '@material-ui/core/TextField';
import MenuItem from '@material-ui/core/MenuItem';

// компонент выпадающий список TextFieldSelect
// ожидаемый вх.параметр items должен представлять собой массив обьектов вида {value, text}
const TextFieldSelect = (props) => {
    const { classes, items, input, label, disabled = false, style, meta: { touched, error } } = props;
    return (
        <Fragment>
            <TextField
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
};

export default withStyles(styles)(TextFieldSelect);
