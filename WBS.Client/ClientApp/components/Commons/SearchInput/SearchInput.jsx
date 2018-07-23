import React from "react";
import PropTypes from "prop-types";
import { withStyles } from "material-ui/styles";
import TextField from "material-ui/TextField";
import SearchIcon from "material-ui-icons/Search";
import { InputAdornment } from "material-ui/Input";
import styles from "./SearchInput.css";

function CustomizedInputs(props) {
    const { classes } = props;

    return (
        <TextField
            id="mainSearch"
            InputProps={{
                disableUnderline: true,
                startAdornment: (
                    <InputAdornment
                        position="start"
                        className={classes.adornment}
                    >
                        <SearchIcon style={{ fill: "#fafafa" }} />
                    </InputAdornment>
                ),
                classes: {
                    root: classes.textFieldRoot,
                    input: classes.textFieldInput
                }
            }}
        />
    );
}

CustomizedInputs.propTypes = {
    classes: PropTypes.object.isRequired
};

export default withStyles(styles)(CustomizedInputs);
