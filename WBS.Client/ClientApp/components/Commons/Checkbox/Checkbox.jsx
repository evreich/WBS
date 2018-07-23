import React from 'react';
import PropTypes from 'prop-types';
import { FormControlLabel } from 'material-ui/Form';
import CheckboxComp from 'material-ui/Checkbox';

const Checkbox = ( {label, checkboxStyle, defaultChecked=false, onChange, name, value} ) => 
        <FormControlLabel                  
             control={
                <CheckboxComp style={checkboxStyle} defaultChecked={defaultChecked} name={name} value={value} onChange={onChange}/>
            }
            label={label}
    />     
   
Checkbox.propTypes = {
  type:  PropTypes.string,
  classes: PropTypes.object,
  label: PropTypes.string,
  placeholder: PropTypes.string,
  checkboxStyle: PropTypes.object,
  defaultChecked: PropTypes.bool,  
  onChange: PropTypes.func,
  name: PropTypes.string,
  value: PropTypes.any  

};

export default Checkbox;
