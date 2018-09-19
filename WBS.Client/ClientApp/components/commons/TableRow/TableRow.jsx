import React from "react";
import PropTypes from "prop-types";

import MuiTableCell from "@material-ui/core/TableCell";
import MuiTableRow from "@material-ui/core/TableRow";
import IconButton from "@material-ui/core/IconButton";
import { withStyles } from '@material-ui/core/styles';
import DeleteIcon from "@material-ui/icons/Delete";
import VisibilityIcon from "@material-ui/icons/Visibility";
import BorderColorIcon from "@material-ui/icons/BorderColor";

import transformDataForRender from 'utils/transormDataForRender';
import { columnHeaderPropType } from 'propTypes';
import styles from 'stylesheets/button.css';

const TableRow = props => {
    const { row, classes, displayedColumns, handleInfoButtonClick } = props;
console.log(classes);
    return (
        <MuiTableRow
            className={classes.rowHover}
            onClick={() => handleInfoButtonClick(row)}
        >
            {displayedColumns && displayedColumns.map(elem => (
                <MuiTableCell key={elem.propName} className={classes.cell}>
                    {transformDataForRender(row[elem.propName], elem.type)}
                </MuiTableCell>
            ))}
            <MuiTableCell className={classes.cell}>
                <IconButton className={classes.small}>
                    <VisibilityIcon />
                </IconButton>
                <IconButton className={classes.small}>
                    <BorderColorIcon className={classes.iconSmall}/>
                </IconButton>
                <IconButton className={classes.small}>
                    <DeleteIcon className={classes.iconSmall}/>
                </IconButton>
            </MuiTableCell>
        </MuiTableRow>
    );
};

TableRow.propTypes = {
    classes: PropTypes.object.isRequired,
    row: PropTypes.object.isRequired,
    handleInfoButtonClick: PropTypes.func,
    displayedColumns: PropTypes.arrayOf(columnHeaderPropType).isRequired
};

export default withStyles(styles)(TableRow);
