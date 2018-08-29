import React from "react";
import PropTypes from "prop-types";

import {
    TableCell,
    TableHead,
    TableRow,
    TableSortLabel
} from "@material-ui/core/Table";
import Tooltip from "@material-ui/core/Tooltip";

import TypesOfColumnData from "constants/typesOfColumnData";

const SortedTableHead = props => {
    const { columnHeaders, order, orderBy, classes } = props;

    const handleColumnSortClick = sortColumnId => () => {
        const onRequestSort = props.onRequestSort;
        onRequestSort(sortColumnId);
    };

    return (
        <TableHead className={classes.header}>
            <TableRow>
                {columnHeaders &&
                    columnHeaders.map(
                        column => (
                            <TableCell
                                className={classes.cell}
                                key={column.propName}
                                sortDirection={
                                    orderBy === column.propName ? order : false
                                }
                            >
                                <Tooltip
                                    title="Sort"
                                    placement={
                                        column.type === TypesOfColumnData.NUMBER
                                            ? "bottom-end"
                                            : "bottom-start"
                                    }
                                    enterDelay={300}
                                >
                                    <TableSortLabel
                                        style={classes.label}
                                        active={orderBy === column.propName}
                                        direction={order}
                                        onClick={handleColumnSortClick(column.propName)}
                                    >
                                        {column.label}
                                    </TableSortLabel>
                                </Tooltip>
                            </TableCell>
                        ),
                        this
                    )}
            </TableRow>
        </TableHead>
    );
};

SortedTableHead.propTypes = {
    onRequestSort: PropTypes.func.isRequired,
    order: PropTypes.string.isRequired,
    orderBy: PropTypes.string.isRequired,
    columnHeaders: PropTypes.array.isRequired,
    classes: PropTypes.object
};
export default SortedTableHead;
