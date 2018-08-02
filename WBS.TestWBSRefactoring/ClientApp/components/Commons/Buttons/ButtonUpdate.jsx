import React from 'react';
import PropTypes from 'prop-types';

import IconButton from 'material-ui/IconButton';
import { withStyles } from 'material-ui/styles';
import EditIcon from 'material-ui-icons/Edit';

import styles from './Button.css'

function IconLabelButtons(props) {
  const { classes, size, onClick, href } = props;
  return <IconButton
    variant="Flat"
    color="primary"
    onClick={onClick}
    className={classes.button}
    size={size}
    href={href}
  >
    <EditIcon />
  </IconButton>
}



IconLabelButtons.propTypes = {
  classes: PropTypes.object.isRequired,
  size: PropTypes.string,
  onClick: PropTypes.func,
  href: PropTypes.string
};

export default withStyles(styles)(IconLabelButtons);
