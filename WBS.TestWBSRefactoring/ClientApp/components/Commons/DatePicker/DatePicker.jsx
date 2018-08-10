import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { DatePicker } from 'material-ui-pickers';
import KeyboardArrowLeft from 'material-ui-icons/KeyboardArrowLeft'
import KeyboardArrowRight from 'material-ui-icons/KeyboardArrowRight'


class CustomDatePicker extends Component {
  render() {
    const { label, placeholder, value, disabled = false, onChange, ...otherProps } = this.props;  
    return (
      <DatePicker
        {...otherProps}
        clearable
        value={value}
        onChange={onChange}
        placeholder={placeholder}
        label={label}
        disabled={disabled}
        animateYearScrolling
        leftArrowIcon={<KeyboardArrowLeft />}
        rightArrowIcon={<KeyboardArrowRight />}
        cancelLabel="Закрыть"
        clearLabel="Очистить"
        format="DD/MM/YYYY"
         // handle clearing outside => pass plain array if you are not controlling value outside
         mask={value => (value ? [/\d/, /\d/, '/', /\d/, /\d/, '/', /\d/, /\d/, /\d/, /\d/] : [])}
        InputLabelProps={{
          shrink: true,
        }}
      />
    );
  }
}

CustomDatePicker.propTypes = {
  disabled: PropTypes.bool,
  value: PropTypes.object,
  placeholder: PropTypes.string,
  label: PropTypes.string,
  onChange: PropTypes.func
};

export default CustomDatePicker;
