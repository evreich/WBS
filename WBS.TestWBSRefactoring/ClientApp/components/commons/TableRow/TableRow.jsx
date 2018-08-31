import React from "react";
import PropTypes from "prop-types";

import MuiTableCell from "@material-ui/core/TableCell";
import MuiTableRow from "@material-ui/core/TableRow";

import transformDataForRender from '../../../helpers/transormDataForRender'

const TableRow = props => {
    const { row, classes, displayedColumns, handleInfoButtonClick } = props;
    
    return (
        <MuiTableRow
            className={classes.rowHover}
            onClick={() => handleInfoButtonClick(row)}
        >
            {displayedColumns && displayedColumns.map(elem => (
                <MuiTableCell key={elem.propName} className={classes.cell}>
                    {transformDataForRender(row[elem.propName],elem.type) }
                </MuiTableCell>
            ))}
        </MuiTableRow>
    );
};

TableRow.propTypes = {
    classes: PropTypes.object.isRequired,
    row: PropTypes.object.isRequired,
    handleInfoButtonClick: PropTypes.func,
    displayedColumns: PropTypes.array.isRequired
};

export default TableRow;
