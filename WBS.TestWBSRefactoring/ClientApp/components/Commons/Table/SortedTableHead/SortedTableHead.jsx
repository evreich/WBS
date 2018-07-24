import React from "react";
import PropTypes from "prop-types";
import {
    TableCell,
    TableHead,
    TableRow,
    TableSortLabel
} from "material-ui/Table";
import Tooltip from "@material-ui/core/Tooltip";
import { styles as classes } from "./SortedTableHead.css";
import { TypesOfColumnData } from "../../../../constants";

const SortedTableHead = props => {
    const { columnHeaders, order, orderBy } = props;

    const handleColumnSortClick = sortColumnId => () => {
        const onRequestSort = props.onRequestSort;
        onRequestSort(sortColumnId);
    };

    return (
        <TableHead>
            <TableRow>
                {columnHeaders &&
                    columnHeaders.map(
                        column => (
                            <TableCell
                                className={classes.cell}
                                key={column.id}
                                sortDirection={
                                    orderBy === column.id ? order : false
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
                                        active={orderBy === column.id}
                                        direction={order}
                                        onClick={handleColumnSortClick(column.id)}
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
    columnHeaders: PropTypes.array.isRequired
};
export default SortedTableHead;
