import React from "react";
import PropTypes from "prop-types";
import { TableCell, TableRow } from "material-ui/Table";

const CommonTableRow = props => {
    const { row, style, displayedColumns, handleInfoButtonClick } = props;

    return (
        <TableRow
            className={style.rowHover}
            onClick={() => handleInfoButtonClick(row)}
        >
            {displayedColumns && displayedColumns.map(elem => (
                <TableCell key={elem.id} className={style.cell}>{row[elem.id]}</TableCell>
            ))}
        </TableRow>
    );
};

CommonTableRow.propTypes = {
    style: PropTypes.object.isRequired,
    row: PropTypes.object.isRequired,
    handleInfoButtonClick: PropTypes.func,
    displayedColumns: PropTypes.array.isRequired
};

export default CommonTableRow;
