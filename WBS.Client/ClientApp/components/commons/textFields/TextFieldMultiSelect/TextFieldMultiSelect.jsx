import React, { Fragment } from 'react';
import PropTypes from 'prop-types';

import { withStyles } from '@material-ui/core/styles';
import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';
import InputLabel from '@material-ui/core/InputLabel';
import ListItemText from '@material-ui/core/ListItemText';
import Checkbox from '@material-ui/core/Checkbox';
import FormControl from '@material-ui/core/FormControl';

import styles from 'stylesheets/textField.css'

//Компонент 'выпадающий список с мультивыбором'
//ожидается обязательный параметр items - массив обьектов вида {id, title}

class TextFieldMultiSelect extends React.Component {

    render() {
        const { classes, items, input, label, meta: { touched, error } } = this.props;
        const values = /*Array.isArray(input.value) ? input.value.map(item => item.id) : [];*/ input.value !== "" ? input.value : []
        return (
            <Fragment>
                <FormControl className={classes.textField}>
                    <InputLabel htmlFor="select-multiple-checkbox">{label}</InputLabel>
                    <Select
                        multiple
                        {...input}
                        value={values}
                        renderValue={selected => selected.map(id => items.filter(item => (item.id === id.id)).map(f => f.title)).reduce((prev, curr) => prev.concat(curr)).join(', ')}
                        className={classes.textField}
                    >
                        {items.map(item => (
                            <MenuItem key={item.id} value={item}>
                                <Checkbox checked={values && values.findIndex(val => val.id === item.id) > -1} />
                                <ListItemText primary={item.title} />
                            </MenuItem>
                        ))}
                    </Select>
                    {touched && error && <span style={{ color: 'red' }}>{error}</span>}
                </FormControl>
            </Fragment>
        )
    }
}


TextFieldMultiSelect.propTypes = {
    input: PropTypes.object,
    classes: PropTypes.object.isRequired,
    label: PropTypes.string,
    placeholder: PropTypes.string,
    items: PropTypes.array.isRequired,
    meta: PropTypes.object,
};

export default withStyles(styles)(TextFieldMultiSelect);
