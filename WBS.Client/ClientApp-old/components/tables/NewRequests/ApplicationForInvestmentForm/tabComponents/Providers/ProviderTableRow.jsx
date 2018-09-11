import React from 'react'
import PropTypes from 'prop-types';

import TableCell from "@material-ui/core/TableCell";
import TableRow from "@material-ui/core/TableRow";
import Add from "@material-ui/icons/Add";
import IconButton from "@material-ui/core/IconButton";

const ProviderTableRow = ({ row, classes, add }) => (
    <TableRow className={classes.rowHover}>
        <TableCell className={classes.cell}> {row.title}</TableCell>
        <TableCell className={classes.cell}> {row.profiles.map(item => item.title).join(", ")}</TableCell>
        <TableCell>
            <IconButton onClick={() => add({ id: row.id, title: row.title })} name={"addProviderBtn"}>
                < Add />
            </IconButton>
        </TableCell>
    </TableRow>
)

ProviderTableRow.propTypes = {
    classes: PropTypes.object.isRequired,
    row: PropTypes.object.isRequired,
    add: PropTypes.func
}

export default ProviderTableRow;