﻿import React, { Fragment } from 'react';
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
        const values = input.value === ""
            ? [] : Array.isArray(input.value)
                ? input.value.map(JSON.stringify) : JSON.stringify(input.value)

        const parse = event => {
            const val = event.target.value;
            return Array.isArray(val) ? val.map(JSON.parse) : JSON.parse(val);
        }

        const getRenderValue = selected => selected
            .map(elem => items
                .filter(item => (item.id === JSON.parse(elem).id))
                .map(f => f.title))
            .reduce((prev, curr) => prev
                .concat(curr)).join(', ');

        return (
            <Fragment>
                <FormControl className={classes.textField}>
                    <InputLabel htmlFor="select-multiple-checkbox">{label}</InputLabel>
                    <Select
                        multiple
                        {...input}
                        value={values}
                        renderValue={selected => getRenderValue(selected)}
                        className={classes.textField}
                        onChange={event => input.onChange(parse(event))}

                    >
                        {items.map(item => (
                            <MenuItem key={item.id} value={JSON.stringify(item)}>
                                <Checkbox
                                    checked={Array.isArray(values)
                                        && values.length > 0
                                        && input.value.findIndex(val => val.id === item.id) > -1}
                                />
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
    items: PropTypes.array.isRequired,
    classes: PropTypes.object.isRequired,

    input: PropTypes.object,
    label: PropTypes.string,
    placeholder: PropTypes.string,
    meta: PropTypes.object,
};

export default withStyles(styles)(TextFieldMultiSelect);
