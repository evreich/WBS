import PropTypes from "prop-types";
import React from "react";

import { withStyles } from "material-ui/styles";
import Table, {
    TableBody,
    TableCell,
    TableFooter,
    TablePagination,
    TableRow
} from "material-ui/Table";
import Paper from "material-ui/Paper";

import TablePaginationActionsWrapped from "../Pagination";
import SortedTableHead from "./SortedTableHead";
import { styles } from "./TableStyles.css";
import { SortingActions } from "../../../constants";
import { sortOn } from "../../../helpers/sortinngFunctions";
import TableToolbar from "./Toolbar";
import CommonChangeItemModalWindow from "../ModalWindows/ChangeItemModalWindow";
import CommonInformationModalWindow from "../ModalWindows/InformationModalWindow";
import CommonTableRow from "./TableRow";

const СreateTable = ({
    dataFiledsInfo,
    DialogBodyComponent,
    RowComponent = CommonTableRow,
    InformationModalWindow = CommonInformationModalWindow,
    ChangeItemModalWindow = CommonChangeItemModalWindow,
    isNeedFillEmptyRow = true,
    isNeedTableFooter = true
}) =>
    withStyles(styles)(
        class CommonTable extends React.PureComponent {
            constructor(props) {
                super(props);
                this.state = {
                    modalWindowInfoIsOpening: false,
                    modalWindowChangingIsOpening: false,
                    updatingDataItem: {}
                };
            }

            static propTypes = {
                classes: PropTypes.object.isRequired,
                getDataTable: PropTypes.func.isRequired,
                deleteDataTable: PropTypes.func.isRequired,
                createDataTable: PropTypes.func.isRequired,
                updateDataTable: PropTypes.func.isRequired,
                changePagination: PropTypes.func.isRequired,
                changeSorting: PropTypes.func.isRequired,
                setUpdatingItem: PropTypes.func.isRequired,
                data: PropTypes.array.isRequired,
                sortingData: PropTypes.object.isRequired,
                paginationData: PropTypes.object.isRequired
            };

            //lifecycle hooks
            componentDidMount() {
                const getDataTable = this.props.getDataTable;
                //
                getDataTable(this.title);
            }

            //handlers
            handleCloseChangeModalWindow = (item) => {
                const updatingDataItem = this.state.updatingDataItem;
                const currItem = item.id ? item : updatingDataItem;

                this.setState({
                    modalWindowChangingIsOpening: false,
                    updatingDataItem: currItem
                });
            };

            handleOpenChangeModalWindow = () => {
                this.setState({
                    modalWindowChangingIsOpening: true
                });
            };

            handleCloseInformationModalWindow = () => {
                this.setState({
                    modalWindowInfoIsOpening: false,
                    updatingDataItem: {}
                });
            };

            handleOpenInformationModalWindow = item => {
                this.setState({
                    modalWindowInfoIsOpening: true,
                    updatingDataItem: item
                });
            };

            handleChangePage = (event, page) => {
                const {
                    getDataTable,
                    changePagination,
                    paginationData
                } = this.props;
                changePagination({ ...paginationData, currentPage: page })
                getDataTable()
            };

            handleChangeRowsPerPage = event => {
                const {
                    getDataTable,
                    changePagination,
                    paginationData
                } = this.props;
                changePagination({
                    ...paginationData,
                    elementsPerPage: event.target.value
                });
                getDataTable();
            };

            handleDeleteButtonClick = id => {
                const deleteDataTable = this.props.deleteDataTable;
                deleteDataTable(id);
            };

            handleSortByHeaderClick = sortColumnId => {
                const { sortingData, changeSorting } = this.props;
                let newOrder = SortingActions.SORT_DESC;

                if (
                    sortingData.sortBy === sortColumnId &&
                    sortingData.sort === SortingActions.SORT_DESC
                )
                    newOrder = SortingActions.SORT_ASC;

                const newData = this.sortData(sortColumnId, newOrder);
                changeSorting(
                    { sort: newOrder, sortBy: sortColumnId },
                    newData
                );
            };

            sortData = (sortColumnId, order) => {
                const data = this.props.data;
                const typeOfSortData =
                    dataFiledsInfo.tableHeaders[sortColumnId].type;
                return data.sort(sortOn(sortColumnId, typeOfSortData, order));
            };

            fillingEmptyRows = emptyRows =>
                emptyRows > 0 && (
                    <TableRow style={{ height: 48 * emptyRows }}>
                        <TableCell colSpan={2} />
                    </TableRow>
                );

            render() {
                const {
                    classes,
                    paginationData,
                    data,
                    sortingData,
                    updateDataTable,
                    createDataTable
                } = this.props;
                const {
                    modalWindowInfoIsOpening,
                    modalWindowChangingIsOpening,
                    updatingDataItem
                } = this.state;
                const {
                    currentPage,
                    elementsPerPage,
                    elementsCount
                } = paginationData;

                //Вычисление пустых строк для заполнения таблицы
                const emptyRows = isNeedFillEmptyRow
                    ? elementsPerPage -
                    Math.min(
                        elementsPerPage,
                        elementsCount - currentPage * elementsPerPage
                    )
                    : 0;

                //отрисовка футера таблицы
                const tableFooter = !isNeedTableFooter ? null : (
                    <TableRow>
                        <TablePagination
                            className={classes.footer}
                            colSpan={4}
                            count={elementsCount}
                            rowsPerPage={elementsPerPage}
                            page={currentPage}
                            labelRowsPerPage="Показывать на странице:"
                            labelDisplayedRows={({ from, to, count }) =>
                                `${from}-${to} из ${count}`
                            }
                            backIconButtonProps={{
                                "aria-label": "Предыдущая страница"
                            }}
                            nextIconButtonProps={{
                                "aria-label": "Следующая страница"
                            }}
                            onChangePage={this.handleChangePage}
                            onChangeRowsPerPage={this.handleChangeRowsPerPage}
                            ActionsComponent={TablePaginationActionsWrapped}
                        />
                    </TableRow>
                );

                const { tableHeaders, fieldNames, titleTable } = dataFiledsInfo;
                return (
                    <>
                        <Paper className={classes.root}>
                            {/*Таблица*/}
                            <TableToolbar
                                onCreate={this.handleOpenChangeModalWindow}
                                title={titleTable}
                            />
                            <Table className={classes.table}>
                                <SortedTableHead
                                    order={sortingData.sort}
                                    orderBy={sortingData.sortBy}
                                    onRequestSort={this.handleSortByHeaderClick}
                                    columnHeaders={Object.values(tableHeaders)}
                                />
                                <TableBody>
                                    {data &&
                                        data.map(row => (
                                            <RowComponent
                                                key={row.id}
                                                row={row}
                                                displayedColumns={Object.values(
                                                    tableHeaders
                                                )}
                                                classes={classes}
                                                handleInfoButtonClick={
                                                    this
                                                        .handleOpenInformationModalWindow
                                                }
                                            />
                                        ))}
                                    {this.fillingEmptyRows(emptyRows)}
                                </TableBody>

                                {/*Футер*/}
                                <TableFooter>{tableFooter}</TableFooter>
                            </Table>
                        </Paper>

                        {/*Модальные окна*/}
                        <InformationModalWindow
                            open={modalWindowInfoIsOpening}
                            formData={updatingDataItem}
                            cancel={this.handleCloseInformationModalWindow}
                            formFieldNames={Object.values(fieldNames)}
                            handleDeleteButtonClick={
                                this.handleDeleteButtonClick
                            }
                            handleUpdateButtonClick={
                                this.handleOpenChangeModalWindow
                            }
                        />

                        <ChangeItemModalWindow
                            open={modalWindowChangingIsOpening}
                            save={
                                Object.getOwnPropertyNames(updatingDataItem)
                                    .length !== 0 && updatingDataItem.id
                                    ? updateDataTable
                                    : createDataTable
                            }
                            data={updatingDataItem}
                            cancel={this.handleCloseChangeModalWindow}
                            DialogBodyComponent={DialogBodyComponent}
                        />
                    </>
                );
            }
        }
    );

export default СreateTable;