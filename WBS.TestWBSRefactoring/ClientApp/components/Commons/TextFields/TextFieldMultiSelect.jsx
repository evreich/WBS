import React from "react";
import PropTypes from "prop-types";

import { withStyles } from "@material-ui/core/styles";
import Select from "@material-ui/core/Select";
import MenuItem from "@material-ui/core/MenuItem";
import InputLabel from "@material-ui/core/InputLabel";
import ListItemText from "@material-ui/core/ListItemText";
import Checkbox from "@material-ui/core/Checkbox";
import FormControl from "@material-ui/core/FormControl";

import styles from "./TextField.css";
//Компонент 'выпадающий список с мультивыбором'

const TextFieldMultiSelect = props => {
    const { muProps, classes, items } = props;
    const label = muProps.label;
    return (
        <FormControl className={classes.textField}>
            <InputLabel htmlFor="select-multiple-checkbox">{label}</InputLabel>
            <Select
                {...muProps}
                multiple
                style={{ ...muProps.style, display: "flex" }}
                renderValue={selected => selected.join(', ')}
                className={classes.textField}
                MenuProps={{
                    disableEnforceFocus: true
                }}
            >
                {items.map(item => (
                    <MenuItem key={item} value={item}>
                        <Checkbox
                            checked={
                                muProps.value &&
                                muProps.value.indexOf(item) > -1
                            }
                        />
                        <ListItemText primary={item} />
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
    values: PropTypes.array
};

export default withStyles(styles)(TextFieldMultiSelect);
