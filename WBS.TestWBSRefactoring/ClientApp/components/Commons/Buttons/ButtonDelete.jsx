import React from 'react';
import PropTypes from 'prop-types';
// import Button from 'material-ui/Button';
import IconButton from 'material-ui/IconButton';
import { withStyles } from 'material-ui/styles';
import Delete from 'material-ui-icons/Delete';
import styles from './Button.css'

function ButtonDelete(props) {
  const { classes, size, onClick } = props;
  return <IconButton className={classes.button} size={size} variant="Flat" color="secondary" onClick={onClick}><Delete/>
  </IconButton>
}

ButtonDelete.propTypes = {
  classes: PropTypes.object.isRequired,
  onClick: PropTypes.func,
  size: PropTypes.string
};

export default withStyles(styles)(ButtonDelete);