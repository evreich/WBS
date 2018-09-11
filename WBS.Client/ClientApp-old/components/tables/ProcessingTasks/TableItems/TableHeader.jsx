import React from 'react';
import PropTypes from 'prop-types';

import TableSortLabel from "@material-ui/core/TableSortLabel";
import TableCell from "@material-ui/core/TableCell";
import TableRow from "@material-ui/core/TableRow";
import TableHead from "@material-ui/core/TableHead";
import Tooltip from "@material-ui/core/Tooltip";

const columnData = [
    {
        id: "number",
        numeric: false,
        disablePadding: false,
        label: "Номер заявки"
    },
    {
        id: "siteName",
        numeric: false,
        disablePadding: false,
        label: "Название сита"
    },
    {
        id: "date",
        numeric: false,
        disablePadding: true,
        label: "Дата поступления задачи"
    },
    {
        id: "processingTime",
        numeric: false,
        disablePadding: true,
        label: "Срок обработки задачи"
    },
    {
        id: "currentStage",
        numeric: false,
        disablePadding: false,
        label: "Текущий этап"
    },
    {
        id: "protocol",
        numeric: false,
        disablePadding: true,
        label: "Протокол обработки заявки"
    },
    {
        id: "extracted",
        numeric: false,
        disablePadding: true,
        label: "Кем извлечено"
    },
    {
        id: "delegated",
        numeric: false,
        disablePadding: true,
        label: "Делегировано"
    }
];

class TableHeader extends React.PureComponent {
    createSortHandler = property => event => {
        this.props.onRequestSort(event, property);
    };

    render() {
        const { order, orderBy, rowClassName, cellClassName } = this.props;

        return (
            <TableHead>
                <TableRow className={rowClassName}>
                    {columnData.map(
                        column => (
                            <TableCell
                                key={column.id}
                                className={cellClassName}
                                sortDirection={
                                    orderBy === column.id ? order : false
                                }
                            >
                                <Tooltip
                                    title="Sort"
                                    placement={
                                        column.numeric
                                            ? "bottom-end"
                                            : "bottom-start"
                                    }
                                    enterDelay={300}
                                >
                                    <TableSortLabel
                                        active={orderBy === column.id}
                                        direction={order}
                                        onClick={this.createSortHandler(
                                            column.id
                                        )}
                                    >
                                        {column.label}
                                    </TableSortLabel>
                                </Tooltip>
                            </TableCell>
                        ),
                    )}
                </TableRow>
            </TableHead>
        );
    }
}

TableHeader.propTypes = {
    numSelected: PropTypes.number.isRequired,
    onRequestSort: PropTypes.func.isRequired,
    order: PropTypes.string.isRequired,
    orderBy: PropTypes.string.isRequired,
    rowCount: PropTypes.number.isRequired,
    cellClassName: PropTypes.string,
    rowClassName: PropTypes.string
};

export default TableHeader;