import React from 'react';
import PropTypes from 'prop-types';

import { withStyles } from 'material-ui/styles';
import TextField from '@material-ui/core/TextField';
import MenuItem from '@material-ui/core/MenuItem';

import styles from '../TextFields/TextField.css'

// компонент выпадающий список TextFieldSelect
// ожидаемый вх.параметр items должен представлять собой массив обьектов вида {value, text}
const TextFieldSelect = (props) => {
    const { classes, muProps, items } = props;
    const { margin, disabled, defaultValue } = muProps;
    return (
            <TextField
                {...muProps}
                margin={margin ? margin : "normal"}
                disabled={disabled ? disabled : false}
                defaultValue={defaultValue ? defaultValue : null}  
                className={classes.textField}
                SelectProps={{
                    MenuProps: {
                        className: classes.menu,
                        disableEnforceFocus: true
                    },
                }}
                select 
                style={{ display: "flex"}}          
            >
                {items && items.map((item) =>
                    <MenuItem key={item.value} value={item.value}>
                        {item.text}
                    </MenuItem>
                )}
            </TextField>
    )
}

TextFieldSelect.propTypes = {
    classes: PropTypes.object,
    muProps: PropTypes.object,
    items: PropTypes.array.isRequired
}

export default withStyles(styles)(TextFieldSelect);
