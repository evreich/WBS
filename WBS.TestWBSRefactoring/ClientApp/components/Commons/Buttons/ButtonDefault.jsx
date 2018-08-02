import React from 'react';
import PropTypes from 'prop-types';

import { withStyles } from 'material-ui/styles';
import Button from 'material-ui/Button';

import styles from './Button.css'

function ButtonDefault(props) {
  const { classes, size, text, onClick, type } = props;
  return (
    <Button size={size} type ={type} variant="raised" className={classes.button} onClick={onClick}>
      {text}
    </Button>
  );
}

ButtonDefault.propTypes = {
  classes: PropTypes.object.isRequired,
  size: PropTypes.string,
  text: PropTypes.string,
  type:  PropTypes.string,
  onClick: PropTypes.func.isRequired
};

export default withStyles(styles)(ButtonDefault);