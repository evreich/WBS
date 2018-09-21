import PropTypes from "prop-types";
import React from "react";

import { withStyles } from "@material-ui/core/styles";
import MuiTable from "@material-ui/core/Table";
import MuiTablePagination from "@material-ui/core/TablePagination";
import MuiTableCell from "@material-ui/core/TableCell";
import MuiTableRow from "@material-ui/core/TableRow";
import MuiTableFooter from "@material-ui/core/TableFooter";
import MuiTableBody from "@material-ui/core/TableBody";
import Paper from "@material-ui/core/Paper";

import TablePagination from "components/commons/TablePagination";
import SortedTableHead from "components/commons/SortedTableHead";
import { styles } from "./Table.css";
//import SortingActions from "constants/sortingActions";
//import { sortOn } from "helpers/sortinngFunctions";
import TableToolbar from "components/commons/TableToolbar";
import CommonChangeItemModalWindow from "components/commons/modalWindows/ChangeItemModalWindow";
import CommonTableRow from "components/commons/TableRow";
import { paginationPropType } from "propTypes";

//заголовки диалоговых окон
const createTitleModalWindow = "Создание";
const editTitleModalWindow = "Редактирование";

const Table = ({
    metaData,
    RowComponent = CommonTableRow,
    ChangeItemModalWindow = CommonChangeItemModalWindow,
    isNeedFillEmptyRow = true,
    isNeedTableFooter = true,
    tableStyles = {}
}) =>
    withStyles(() => ({ ...styles, ...tableStyles }))(
        class Table extends React.PureComponent {
            constructor(props) {
                super(props);
                this.state = {
                    updatingItemId: null,
                    modalWindowChangingIsOpening: false,
                    updatingDataItem: null,
                    changeModalWindowTitle: createTitleModalWindow,
                    columnsCount: Object.keys(metaData.columns).length
                };

                //TODO
                this.sortingData = {
                    sort: 'desc',//SortingActions.SORT_DESC,
                    sortBy: ""
                };
            }

            static propTypes = {
                getDataTable: PropTypes.func.isRequired,
                getPermissions: PropTypes.func.isRequired,
                clearTable: PropTypes.func.isRequired,
                updateTable: PropTypes.func.isRequired,
                changeData: PropTypes.func.isRequired,
                setUpdatingItem: PropTypes.func.isRequired,
                clearUpdatingItem: PropTypes.func.isRequired,
                deleteData: PropTypes.func,

                data: PropTypes.array.isRequired,
                pagination: paginationPropType.isRequired,
                queryParams: PropTypes.object,
                showToolbar: PropTypes.bool,
                classes: PropTypes.object.isRequired,
                accessToCreate: PropTypes.bool
            };

            static defaultProps = {
                pagination: {
                    currentPage: 0,
                    elementsPerPage: 5,
                    elementsCount: 0
                },
                data: [],
                accessToCreate: false,
                showToolbar: true
            };

            //lifecycle hooks
            componentDidMount() {
                const { getDataTable, queryParams, getPermissions } = this.props;
                //Получаем:
                //дескрипторы на чтение и создание;
                //доступ на CRUD операции над типом.

                //Все кладем в редакс в tables -> конкр. таблица -> соотв поле
                getPermissions();
                getDataTable(undefined, undefined, queryParams);
            }

            componentWillReceiveProps(newProps) {
                console.log(newProps);
                return true;
            }

            componentWillUnmount() {
                const clearTable = this.props.clearTable;
                clearTable();
            }

            //handlers
            handleCloseChangeModalWindow = () => {
                const { clearUpdatingItem } = this.props;
                clearUpdatingItem();

                this.setState({
                    updatingItemId: null,
                    modalWindowChangingIsOpening: false
                });
            };

            handleOpenOnCreateChangeModalWindow = () => {
                this.setState({
                    modalWindowChangingIsOpening: true,
                    changeModalWindowTitle: createTitleModalWindow
                });
            };

            handleOpenOnEditChangeModalWindow = (id) => {
                const { setUpdatingItem } = this.props;
                setUpdatingItem(id);

                this.setState({
                    updatingItemId: id,
                    modalWindowChangingIsOpening: true,
                    //TODO: Если нет прав на редактирование?
                    changeModalWindowTitle: editTitleModalWindow
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

            handleSortByHeaderClick = () => { };

            fillingEmptyRows = emptyRows =>
                emptyRows > 0 && (
                    <MuiTableRow style={{ height: 48 * emptyRows }}>
                        <MuiTableCell colSpan={this.state.columnsCount} />
                    </MuiTableRow>
                );

            render() {
                const {
                    classes,
                    pagination,
                    data,
                    changeData,
                    accessToCreate,
                    showToolbar
                } = this.props;
                const {
                    updatingItemId,
                    modalWindowChangingIsOpening,
                    changeModalWindowTitle,
                    columnsCount
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
                    <MuiTableRow>
                        <MuiTablePagination
                            className={classes.footer}
                            colSpan={columnsCount}
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
                            ActionsComponent={TablePagination}
                        />
                    </MuiTableRow>
                );

                const {
                    columns,
                    title,
                    id
                } = metaData;

                return (
                    <>
                        <Paper className={classes.root} id={id}>
                            {/*Таблица*/}
                            {showToolbar && (
                                <TableToolbar
                                    accessToCreate={accessToCreate}
                                    onCreate={this.handleOpenOnCreateChangeModalWindow}
                                    title={title}
                                />
                            )}
                            <MuiTable className={classes.table}>
                                <SortedTableHead
                                    classes={classes}
                                    order={this.sortingData.sort}
                                    orderBy={this.sortingData.sortBy}
                                    onRequestSort={this.handleSortByHeaderClick}
                                    columnHeaders={Object.values(columns)}
                                />
                                <MuiTableBody>
                                    {data &&
                                        data.map(row => (
                                            <RowComponent
                                                key={row.id}
                                                row={row}
                                                displayedColumns={Object.values(columns)}
                                                classes={classes}
                                                handleEditButtonClick={() => this.handleOpenOnEditChangeModalWindow(row.id)}
                                                handleDeleteButtonClick={this.handleDeleteButtonClick}
                                            />
                                        ))}
                                    {this.fillingEmptyRows(emptyRows)}
                                </MuiTableBody>

                                {/*Футер*/}
                                <MuiTableFooter>{tableFooter}</MuiTableFooter>
                            </MuiTable>
                        </Paper>

                        {/* Модальные окна */}
                        {modalWindowChangingIsOpening &&
                            <ChangeItemModalWindow
                                itemId={updatingItemId}
                                save={changeData}
                                close={this.handleCloseChangeModalWindow}
                                currentPage={currentPage}
                                elementsPerPage={elementsPerPage}
                                header={changeModalWindowTitle}
                            />
                        }
                    </>
                );
            }
        }
    );

export default Table;
