import React from 'react';
import PropTypes from 'prop-types';

import classNames from "classnames";
import RefreshIcon from "@material-ui/icons/Refresh";
import IconButton from "@material-ui/core/IconButton";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import Tooltip from "@material-ui/core/Tooltip";
import FilterListIcon from "@material-ui/icons/FilterList";
import { withStyles } from "@material-ui/core/styles";
import Button from "@material-ui/core/Button";

import { toolbarStyles } from "components/Commons/Table/TableStyles.css";

const TableToolbar = props => {
    const { numSelected, classes, onOpen } = props;

    return (
        <Toolbar
            className={classNames(classes.root, {
                [classes.highlight]: numSelected > 0
            })}
        >
            <div className={classes.title}>
                <Typography variant="title">
                    Список моих задач по обработке заявок
                </Typography>
                <IconButton
                    color="secondary"
                    className={classes.button}
                    aria-label="Refresh"
                >
                    <RefreshIcon />
                </IconButton>
            </div>
            <div className={classes.spacer} />
            <div className={classes.actions}>
                <Tooltip title="Filter list">
                    <Button
                        variant="flat"
                        size="small"
                        onClick={onOpen}
                        style={{ marginRight: 10 }}
                        color="secondary"
                        aria-label="Create new"
                    >
                        Фильтры&nbsp;
                        <FilterListIcon />
                    </Button>
                </Tooltip>
            </div>
        </Toolbar>
    );
};

TableToolbar.propTypes = {
    classes: PropTypes.object.isRequired,
    numSelected: PropTypes.number.isRequired,
    onOpen: PropTypes.func.isRequired
};

export default withStyles(toolbarStyles)(TableToolbar);