import React from "react";
import PropTypes from "prop-types";
import TextField from "material-ui/TextField";
import styles from "./TextField.css";

const TextFieldPlaceholder = props => {
    const muProps = props.muProps;
    return (
        <TextField
            {...muProps}
            disabled={muProps && muProps.disabled ? muProps.disabled : false}
            className={styles.textField}
            margin="normal"
            InputLabelProps={{
                shrink: true
            }}
        />
    );
};

TextFieldPlaceholder.propTypes = {
    muProps: PropTypes.object
};

export default TextFieldPlaceholder;
