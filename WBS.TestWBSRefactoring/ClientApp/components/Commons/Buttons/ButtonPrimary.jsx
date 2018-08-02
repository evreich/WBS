import React from 'react';
import PropTypes from 'prop-types';

import { withStyles } from 'material-ui/styles';
import Button from 'material-ui/Button';

import styles from './Button.css'

function ButtonPrimary(props) {
  const { classes, size, text, onClick, type } = props;
  return (
    <Button size={size} type ={type} variant="raised" color="primary" className={classes.button} onClick={onClick}>
      {text}
    </Button>
  );
}

ButtonPrimary.propTypes = {
  classes: PropTypes.object.isRequired,
  size: PropTypes.string,
  text: PropTypes.string,
  type:  PropTypes.string,
  onClick: PropTypes.func
};

export default withStyles(styles)(ButtonPrimary);