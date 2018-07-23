import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from 'material-ui/styles';
import styles from '../TextFields/TextField.css'
import TextField from '@material-ui/core/TextField';
import MenuItem from '@material-ui/core/MenuItem';

// компонент выпадающий список TextFieldSelect
// ожидаемый вх.параметр items должен представлять собой массив обьектов вида {value, text}
const TextFieldSelect = (props) => {
    const { classes, muProps, items } = props;
    const { margin, disabled, defaultValue } = muProps;
    return (
        <Fragment>
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
            >
                {items && items.map((item) =>
                    <MenuItem key={item.value} value={item.value}>
                        {item.text}
                    </MenuItem>
                )}
            </TextField>
        </Fragment>
    )
}

TextFieldSelect.propTypes = {
    classes: PropTypes.object,
    muProps: PropTypes.object,
    items: PropTypes.array.isRequired
}

export default withStyles(styles)(TextFieldSelect);
