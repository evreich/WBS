import React from "react";
import PropTypes from "prop-types";

import { TableCell, TableRow } from "material-ui/Table";

const CommonTableRow = props => {
    const { row, classes, displayedColumns, handleInfoButtonClick } = props;

    return (
        <TableRow
            className={classes.rowHover}
            onClick={() => handleInfoButtonClick(row)}
        >
            {displayedColumns && displayedColumns.map(elem => (
                <TableCell key={elem.propName} className={classes.cell}>{row[elem.propName]}</TableCell>
            ))}
        </TableRow>
    );
};

CommonTableRow.propTypes = {
    classes: PropTypes.object.isRequired,
    row: PropTypes.object.isRequired,
    handleInfoButtonClick: PropTypes.func,
    displayedColumns: PropTypes.array.isRequired
};

export default CommonTableRow;
