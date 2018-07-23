import React from 'react'
import Table, {
  TableBody,
  TableCell,
  TableRow,
  TableFooter,
  TablePagination
} from 'material-ui/Table';
import TablePaginationActionsWrapped from '../../../Commons/Pagination'
import SortedTableHead from '../../../Commons/Table/SortedTableHead'
import {columnTitle} from '../../../Vendors/ColumnTitle'
import Add from 'material-ui-icons/Add';
import IconButton from 'material-ui/IconButton';

const columns = columnTitle.slice()
columns.push({act:""})

const VendorsTable = ({classes, data, sortingData, paginationData : {elementsCount, elementsPerPage, currentPage }, emptyRows, actions: {handleRequestSort, handleChangePage, handleChangeRowsPerPage} , add}) => 
    data && <Table lassName={classes.table}>
                        <SortedTableHead                         
                            order={sortingData.sort}
                            orderBy={sortingData.sortBy}  
                            rowClassName={classes.header}
                            cellClassName={classes.cell}                        
                            onRequestSort={handleRequestSort}
                            columnData={columns}
                            className={classes.header} />
                        <TableBody>
                            {data && data.map(d =>
                                <TableRow className={classes.rowHover} key={d.id}>
                                    <TableCell className={classes.cell}>{d.title}</TableCell> 
                                    <TableCell className={classes.cell}>{d.profile}</TableCell> 
                                    <TableCell>
                                    <IconButton style={{ float: 'right' }} color="action" onClick={() => add(d)} >
                                        <Add />
                                    </IconButton>
                                    </TableCell>                                     
                                </TableRow>      
                            )}
                            {emptyRows > 0 && (
                                <TableRow className={classes.rowHover} style={{ height: 48 * emptyRows }}>
                                    <TableCell className={classes.cell} colSpan={2} />
                                </TableRow>
                            )}
                        </TableBody>
                        <TableFooter>
                            <TableRow>
                                <TablePagination
                                    style={{'fontSize':'14px'}}
                                    colSpan={2}
                                    count={elementsCount}
                                    rowsPerPage={elementsPerPage}                                 
                                    page={currentPage}
                                    labelRowsPerPage="Показывать на странице:"
                                    labelDisplayedRows={({ from, to, count }) => `${from}-${to} из ${count}`}
                                    backIconButtonProps={{
                                    'aria-label': 'Предыдущая страница',
                                    }}
                                    nextIconButtonProps={{
                                    'aria-label': 'Следующая страница',
                                    }}
                                    onChangePage={handleChangePage}
                                    onChangeRowsPerPage={handleChangeRowsPerPage}
                                    Actions={TablePaginationActionsWrapped}
                                />
                            </TableRow>
                        </TableFooter>
                    </Table>


export default VendorsTable;

