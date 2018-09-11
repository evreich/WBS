import React from 'react';
import PropTypes from 'prop-types';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import CheckboxComp from '@material-ui/core/Checkbox';


const Checkbox = ( {label, checkboxStyle, checked=false, onChange, name, value} ) => 
        <FormControlLabel                  
             control={
                <CheckboxComp style={checkboxStyle} checked={checked} name={name} value={value} onChange={onChange}/>
            }
            label={label}
    />     
   
Checkbox.propTypes = {
  type:  PropTypes.string,
  classes: PropTypes.object,
  label: PropTypes.string,
  placeholder: PropTypes.string,
  checkboxStyle: PropTypes.object,
  checked: PropTypes.bool,  
  onChange: PropTypes.func,
  name: PropTypes.string,
  value: PropTypes.any  

};

export default Checkbox;
