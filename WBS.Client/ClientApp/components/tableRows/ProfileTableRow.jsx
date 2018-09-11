import React from "react";
import PropTypes from "prop-types";

import TableCell from "@material-ui/core/TableCell";
import TableRow from "@material-ui/core/TableRow";

const ProfileTableRow = props => {
    const { row, classes, handleInfoButtonClick } = props;
    return (
        <TableRow
            className={classes.rowHover}
            onClick={() => handleInfoButtonClick(row)}
        >
            <TableCell className={classes.cell}>{row.fio}</TableCell>
            <TableCell className={classes.cell}>{row.jobPosition}</TableCell>
            <TableCell className={classes.cell}>{row.department}</TableCell>
            <TableCell className={classes.cell}>
                {row.deletionMark ? "да" : "нет"}
            </TableCell>
        </TableRow>
    );
};

ProfileTableRow.propTypes = {
    classes: PropTypes.object.isRequired,
    row: PropTypes.object.isRequired,
    handleInfoButtonClick: PropTypes.func
};

export default ProfileTableRow;
