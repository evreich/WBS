import React from 'react';
import PropTypes from 'prop-types';

import IconButton from '@material-ui/core/IconButton';
import { withStyles } from '@material-ui/core/styles';
import Delete from '@material-ui/icons/Delete';

import styles from 'stylesheets/button.css';

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