import React from "react";
import PropTypes from "prop-types";

import TextField from "@material-ui/core/TextField";

import styles from "./TextField.css";

const TextFieldMultiline = props => {
    const muProps = props.muProps;
    return (
        <TextField
            {...muProps}
            multiline
            style={{ display: "flex"}}  
            rows={muProps && muProps.rows ? muProps.rows : 1}
            className={styles.textField}
            margin="normal"
            InputLabelProps={{
                shrink: true
            }}
        />
    );
};

TextFieldMultiline.propTypes = {
    muProps: PropTypes.object
};

export default TextFieldMultiline;
