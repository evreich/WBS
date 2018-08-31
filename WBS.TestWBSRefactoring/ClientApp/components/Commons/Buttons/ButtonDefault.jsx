import React from 'react';
import PropTypes from 'prop-types';

import { withStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';

import styles from './Button.css'

const ButtonDefault = ({ classes, size, text, onClick, type }) => (
    <Button size={size} type={type} variant="raised" className={classes.button} onClick={onClick}>
        {text}
    </Button>
);

ButtonDefault.propTypes = {
    classes: PropTypes.object.isRequired,
    size: PropTypes.string,
    text: PropTypes.string,
    type: PropTypes.string,
    onClick: PropTypes.func.isRequired
};

export default withStyles(styles)(ButtonDefault);