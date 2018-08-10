import React from "react";
import PropTypes from "prop-types";

import { withStyles } from "material-ui/styles";
import Table, {
    TableBody,
    TableCell,
    TableFooter,
    TablePagination,
    TableRow
} from "material-ui/Table";

import InsertDriveFileIcon from "material-ui-icons/InsertDriveFile";
import Paper from "material-ui/Paper";

import { styles } from "../../Commons/Table/TableStyles.css";
import fillDataToTable from "./tempHelpers/fillDataToTable";
import TableToolbar from "./TableItems/TableToolbar";
import TableHeader from "./TableItems/TableHeader";
import Filters from "./Filters";

class ProcessingTasksTable extends React.PureComponent {
    constructor(props, context) {
        super(props, context);

        this.state = {
            order: "asc",
            open: false,
            orderBy: "date",
            selected: [],
            data: fillDataToTable(20).sort(
                (currElem, nextElem) => (currElem.date < nextElem.date ? -1 : 1)
            ),
            page: 0,
            rowsPerPage: 10
        };
    }

    handleRequestSort = (event, property) => {
        const { data, orderBy, order } = this.state;
        const handleOrderBy = property;
        let handleOrder = "desc";

        if (orderBy === property && order === "desc") {
            handleOrder = "asc";
        }

        const newData =
            handleOrder === "desc"
                ? data.sort(
                      (a, b) => (b[handleOrderBy] < a[handleOrderBy] ? -1 : 1)
                  )
                : data.sort(
                      (a, b) => (a[handleOrderBy] < b[handleOrderBy] ? -1 : 1)
                  );

        this.setState({ data: newData, handleOrder, handleOrderBy });
    };

    handleChangePage = (event, page) => {
        this.setState({ page });
    };

    handleChangeRowsPerPage = event => {
        this.setState({ rowsPerPage: event.target.value });
    };

    handleClickOpen = () => {
        this.setState({ open: true });
    };

    handleClose = () => {
        this.setState({ open: false });
    };

    isSelected = id => this.state.selected.indexOf(id) !== -1;

    render() {
        const { classes } = this.props;
        const {
            data,
            order,
            orderBy,
            selected,
            rowsPerPage,
            page,
            open
        } = this.state;
        const emptyRows =
            rowsPerPage -
            Math.min(rowsPerPage, data.length - page * rowsPerPage);

        return (
            <>
                <Paper className={classes.root}>
                    <TableToolbar
                        onOpen={this.handleClickOpen}
                        numSelected={selected.length}
                    />
                    <div className={classes.tableWrapper}>
                        <Table className={classes.table}>
                            <TableHeader
                                rowClassName={classes.header}
                                cellClassName={classes.cell}
                                numSelected={selected.length}
                                order={order}
                                orderBy={orderBy}
                                onRequestSort={this.handleRequestSort}
                                rowCount={data.length}
                            />
                            <TableBody>
                                {data
                                    .slice(
                                        page * rowsPerPage,
                                        page * rowsPerPage + rowsPerPage
                                    )
                                    .map(n => (
                                        <TableRow
                                            className={classes.rowHover}
                                            key={n.id}
                                        >
                                            <TableCell className={classes.cell}>
                                                {n.number}
                                            </TableCell>
                                            <TableCell className={classes.cell}>
                                                {n.siteName}
                                            </TableCell>
                                            <TableCell className={classes.cell}>
                                                {n.date}
                                            </TableCell>
                                            <TableCell className={classes.cell}>
                                                {n.processingTime}
                                            </TableCell>
                                            <TableCell className={classes.cell}>
                                                {n.currentStage}
                                            </TableCell>
                                            <TableCell className={classes.cell}>
                                                <InsertDriveFileIcon />
                                            </TableCell>
                                            <TableCell className={classes.cell}>
                                                {n.extracted}
                                            </TableCell>
                                            <TableCell className={classes.cell}>
                                                {n.delegated}
                                            </TableCell>
                                        </TableRow>
                                    ))}
                                {emptyRows > 0 && (
                                    <TableRow
                                        style={{ height: 49 * emptyRows }}
                                    >
                                        <TableCell colSpan={6} />
                                    </TableRow>
                                )}
                            </TableBody>
                            <TableFooter>
                                <TableRow>
                                    <TablePagination
                                        colSpan={8}
                                        count={data.length}
                                        rowsPerPage={rowsPerPage}
                                        page={page}
                                        labelRowsPerPage="Показывать на странице:"
                                        labelDisplayedRows={({
                                            from,
                                            to,
                                            count
                                        }) => `${from}-${to} из ${count}`}
                                        backIconButtonProps={{
                                            "aria-label": "Предыдущая страница"
                                        }}
                                        nextIconButtonProps={{
                                            "aria-label": "Следующая страница"
                                        }}
                                        onChangePage={this.handleChangePage}
                                        onChangeRowsPerPage={
                                            this.handleChangeRowsPerPage
                                        }
                                    />
                                </TableRow>
                            </TableFooter>
                        </Table>
                    </div>
                </Paper>
                {/* Модальное окно "Фильтры" */}
                <Filters
                    classes={classes}
                    open={open}
                    handleClose={this.handleClose}
                />
            </>
        );
    }
}

ProcessingTasksTable.propTypes = {
    classes: PropTypes.object.isRequired
};

export default withStyles(styles)(ProcessingTasksTable);
