import React from "react";
import PropTypes from "prop-types";
import { FormControlLabel } from "material-ui/Form";
import RadioComp from "material-ui/Radio";

const Radio = ({
    input,
    label,
    style,
    value,
    checked,
    radioStyle,
    onChange
}) => (
    <FormControlLabel
        {...input}
        style={style}
        control={
            <RadioComp
                name={name}
                style={radioStyle}
                value={value}
                onChange={onChange}
            />
        }
        checked={checked}
        label={label}
    />
);

Radio.propTypes = {
    input: PropTypes.object,
    classes: PropTypes.object,
    label: PropTypes.any,
    style: PropTypes.object,
    radioStyle: PropTypes.object,
    checked: PropTypes.bool,
    value: PropTypes.any,
    onChange: PropTypes.func
};

export default Radio;
