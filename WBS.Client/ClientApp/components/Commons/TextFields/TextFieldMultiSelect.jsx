import React from "react";
import PropTypes from "prop-types";
import { withStyles } from "material-ui/styles";
import Select from "@material-ui/core/Select";
import MenuItem from "@material-ui/core/MenuItem";
import styles from "./TextField.css";
import InputLabel from "@material-ui/core/InputLabel";
import ListItemText from "@material-ui/core/ListItemText";
import Checkbox from "@material-ui/core/Checkbox";
import FormControl from "@material-ui/core/FormControl";

//Компонент 'выпадающий список с мультивыбором'
//ожидается обязательный параметр items - массив обьектов вида {id, title}
//values - массив текущих выбранных элементов
//renderValue выводит названия обьектов через запятую
const getAllTitles = (id, allItems) =>
    allItems.filter(item => item.id === id).map(f => f.title);

const renderValue = (selected, allItems) =>
    selected
        .map(id => getAllTitles(id, allItems))
        .reduce((prev, curr) => prev.concat(curr))
        .join(", ");

const TextFieldMultiSelect = props => {
    const { muProps, classes, items, values } = props;
    const label = muProps.label;
    return (
        <FormControl className={classes.textField}>
            <InputLabel htmlFor="select-multiple-checkbox">{label}</InputLabel>
            <Select
                {...muProps}
                multiple
                renderValue={selected => renderValue(selected, items)}
                className={classes.textField}
                MenuProps={{
                    disableEnforceFocus: true
                }}
            >
                {items.map(item => (
                    <MenuItem key={item.id} value={item.id}>
                        <Checkbox
                            name={name}
                            checked={values && values.indexOf(item.id) > -1}
                        />
                        <ListItemText primary={item.title} />
                    </MenuItem>
                ))}
            </Select>
        </FormControl>
    );
};

TextFieldMultiSelect.propTypes = {
    classes: PropTypes.object.isRequired,
    items: PropTypes.array.isRequired,
    muProps: PropTypes.object,
    values: PropTypes.array.isRequired
};

export default withStyles(styles)(TextFieldMultiSelect);
