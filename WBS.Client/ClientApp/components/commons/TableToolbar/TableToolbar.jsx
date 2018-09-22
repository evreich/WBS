import React from 'react';
import classNames from 'classnames';
import PropTypes from 'prop-types';

import { withStyles } from '@material-ui/core/styles';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import AddCircleOutlineIcon from '@material-ui/icons/AddCircleOutline';
import Button from '@material-ui/core/Button';
import Tooltip from '@material-ui/core/Tooltip';

import { toolbarStyles } from './TableToolbar.css';

let TableToolbar = props => {
    const { classes, onCreate, title, accessToCreate = false } = props;

    return (
        <Toolbar
            className={classNames(classes.root, {
                [classes.highlight]: false,
            })}
        >
            <div className={classes.title}>
                <Typography variant="title">{title}</Typography>
            </div>
            <div className={classes.spacer} />
            <div className={classes.actions}>{
                accessToCreate && (
                    <Tooltip title="Создать">
                        <Button variant="flat" size="small" onClick={onCreate} style={{ marginRight: 10, color: "green" }} aria-label="Создать">
                            Создать&nbsp;
                            <AddCircleOutlineIcon />
                        </Button>
                    </Tooltip>
                )
            }
            </div>
        </Toolbar>
    );
};

TableToolbar.propTypes = {
    classes: PropTypes.object.isRequired,
    onCreate: PropTypes.func.isRequired,

    title: PropTypes.string,
    accessToCreate: PropTypes.bool
};

export default withStyles(toolbarStyles)(TableToolbar);