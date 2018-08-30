import React from 'react';
import PropTypes from 'prop-types';

import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import MenuItem from '@material-ui/core/MenuItem';

import styles from '../TextFields/TextField.css'

// компонент выпадающий список TextFieldSelect
// ожидаемый вх.параметр items должен представлять собой массив обьектов вида {value, text}
class TextFieldSelect extends React.Component {
    handleChange = (event) => {
        const { muProps, items, textPropName } = this.props;
        const selectedItem = items.find( item => item.value === event.target.value);
        muProps.onChange(event, { [textPropName]: selectedItem.text});
    };

    render() {
        const { classes, muProps, items } = this.props;
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
                onChange={this.handleChange}
                select
                style={{ ...muProps.style, display: "flex" }}
            >
                {items && items.map((item) =>
                    <MenuItem key={item.value} value={item.value}>
                        {item.text}
                    </MenuItem>
                )}
            </TextField>
        )
    }
}

TextFieldSelect.propTypes = {
    classes: PropTypes.object,
    muProps: PropTypes.object,
    items: PropTypes.array.isRequired,
    textPropName: PropTypes.string
}

export default withStyles(styles)(TextFieldSelect);
