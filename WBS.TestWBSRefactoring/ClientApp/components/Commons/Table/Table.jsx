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
import SortingActions from "constants/sortingActions";
import { sortOn } from "helpers/sortinngFunctions";
import TableToolbar from "./Toolbar";
import CommonChangeItemModalWindow from "../ModalWindows/ChangeItemModalWindow";
import CommonInformationModalWindow from "../ModalWindows/InformationModalWindow";
import CommonTableRow from "./TableRow";

//заголовки диалоговых окон
const createTitleModalWindow = "Создание";
const editTitleModalWindow = "Редактирование";

const СreateTable = ({
    dataFiledsInfo,
    AddItemDialogBodyComponent,
    ChangeItemDialogBodyComponent,
    RowComponent = CommonTableRow,
    InformationModalWindow = CommonInformationModalWindow,
    ChangeItemModalWindow = CommonChangeItemModalWindow,
    isNeedFillEmptyRow = true,
    isNeedTableFooter = true,
    tableStyles = {}
}) =>
    withStyles(() => ({ ...styles, ...tableStyles }))(
        class CommonTable extends React.PureComponent {
            constructor(props) {
                super(props);
                this.state = {
                    modalWindowInfoIsOpening: false,
                    modalWindowChangingIsOpening: false,
                    updatingDataItem: null,
                    changeModalWindowTitle: createTitleModalWindow,
                    dataFiledsCount: Object.keys(dataFiledsInfo.tableHeaders).length
                };

                this.sortingData = {
                    sort: SortingActions.SORT_DESC,
                    sortBy: ""
                };
            }

            static propTypes = {
                classes: PropTypes.object.isRequired,
                getDataTable: PropTypes.func.isRequired,
                clearTable: PropTypes.func.isRequired,
                updateTable: PropTypes.func.isRequired,
                changeData: PropTypes.func.isRequired,
                data: PropTypes.array.isRequired,
                pagination: PropTypes.object.isRequired,
                deleteData: PropTypes.func,
                queryParams: PropTypes.object,
                showToolbar: PropTypes.bool
            };

            static defaultProps = {
                pagination: {
                    currentPage: 0,
                    elementsPerPage: 5,
                    elementsCount: 0
                },
                data: [],
                showToolbar: true
            };

            //lifecycle hooks
            componentDidMount() {
                const { getDataTable, queryParams } = this.props;
                getDataTable(undefined, undefined, queryParams);
            }

            componentWillUnmount() {
                const clearTable = this.props.clearTable;
                clearTable();
            }

            //handlers
            handleCloseChangeModalWindow = item => {
                const updatingDataItem = this.state.updatingDataItem;
                const currItem = item.id ? item : updatingDataItem;

                this.setState({
                    modalWindowChangingIsOpening: false,
                    updatingDataItem: currItem
                });
            };

            handleOpenOnCreateChangeModalWindow = () => {
                this.setState({
                    modalWindowChangingIsOpening: true,
                    changeModalWindowTitle: createTitleModalWindow
                });
            };

            handleOpenOnEditChangeModalWindow = () => {
                this.setState({
                    modalWindowChangingIsOpening: true,
                    changeModalWindowTitle: editTitleModalWindow
                });
            };

            handleCloseInformationModalWindow = () => {
                this.setState({
                    modalWindowInfoIsOpening: false
                });
            };

            handleExitInformationModalWindow = () => {
                this.setState({
                    updatingDataItem: null
                });
            };

            handleOpenInformationModalWindow = item => {
                this.setState({
                    modalWindowInfoIsOpening: true,
                    updatingDataItem: item
                });
            };

            handleChangePage = (event, page) => {
                const { getDataTable, pagination } = this.props;

                getDataTable(page, pagination.elementsPerPage);
            };

            handleChangeRowsPerPage = event => {
                const { getDataTable, pagination } = this.props;

                getDataTable(pagination.currentPage, event.target.value);
            };

            handleDeleteButtonClick = data => {
                const { pagination, deleteData } = this.props;

                deleteData(
                    pagination.currentPage,
                    pagination.elementsPerPage,
                    data
                );
            };

            handleSortByHeaderClick = sortColumnId => {
                const sortingData = this.sortingData;
                const updateTable = this.props.updateTable;

                let newOrder = SortingActions.SORT_DESC;

                if (
                    sortingData.sortBy === sortColumnId &&
                    sortingData.sort === SortingActions.SORT_DESC
                )
                    newOrder = SortingActions.SORT_ASC;

                const newData = this.sortData(sortColumnId, newOrder);

                this.sortingData = { sort: newOrder, sortBy: sortColumnId };
                updateTable(newData);
            };

            sortData = (sortColumnId, order) => {
                const data = this.props.data;
                const typeOfSortData =
                    dataFiledsInfo.tableHeaders[sortColumnId].type;

                return data
                    .sort(sortOn(sortColumnId, typeOfSortData, order))
                    .slice(0);
            };

            fillingEmptyRows = emptyRows =>
                emptyRows > 0 && (
                    <TableRow style={{ height: 48 * emptyRows }}>
                        <TableCell colSpan={this.state.dataFiledsCount} />
                    </TableRow>
                );

            render() {
                const { classes, pagination, data, changeData, showToolbar } = this.props;
                const {
                    modalWindowInfoIsOpening,
                    modalWindowChangingIsOpening,
                    updatingDataItem,
                    changeModalWindowTitle,
                    dataFiledsCount
                } = this.state;
                const {
                    currentPage,
                    elementsPerPage,
                    elementsCount
                } = pagination;

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
                            colSpan={dataFiledsCount}
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

                const {
                    infoWindowModel,
                    createWindowFields,
                    editWindowFields,
                    tableHeaders,
                    titleTable,
                    tableId
                } = dataFiledsInfo;

                const isExistsDialogBodies =
                    AddItemDialogBodyComponent && ChangeItemDialogBodyComponent
                        ? true
                        : false;
                return (
                    <>
                    <Paper className={classes.root} id={tableId}>
                        {/*Таблица*/}
                        <TableToolbar
                            onCreate={
                                this.handleOpenOnCreateChangeModalWindow
                            }
                            title={titleTable}
                        />
                        <Table className={classes.table}>
                            <SortedTableHead
                                order={this.sortingData.sort}
                                orderBy={this.sortingData.sortBy}
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

                        {/* Модальные окна */ }
                <InformationModalWindow
                    open={modalWindowInfoIsOpening}
                    onExited={this.handleExitInformationModalWindow}
                    formData={updatingDataItem}
                    cancel={this.handleCloseInformationModalWindow}
                    formFieldNames={Object.values(infoWindowModel)}
                    handleDeleteButtonClick={
                        this.handleDeleteButtonClick
                    }
                    handleUpdateButtonClick={
                        this.handleOpenOnEditChangeModalWindow
                    }
                />

                    <ChangeItemModalWindow
                        open={modalWindowChangingIsOpening}
                        save={changeData}
                        formFields={
                            updatingDataItem
                                ? editWindowFields
                                : createWindowFields
                        }
                        data={updatingDataItem}
                        cancel={this.handleCloseChangeModalWindow}
                        currentPage={currentPage}
                        elementsPerPage={elementsPerPage}
                        header={changeModalWindowTitle}
                    >
                        {/*отправляем тело диалогового окна в качестве children */}
                        {isExistsDialogBodies ? (
                            updatingDataItem ? (
                                <ChangeItemDialogBodyComponent />
                            ) : (
                                    <AddItemDialogBodyComponent />
                                )
                        ) : null}
                    </ChangeItemModalWindow>
                    </>
                );
            }
        }
    );

export default СreateTable;
