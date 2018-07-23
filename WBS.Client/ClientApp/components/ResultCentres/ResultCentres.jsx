import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from 'material-ui/styles';
import Table, {
    TableBody,
    TableCell,
    TableFooter,
    TablePagination,
    TableRow,
} from 'material-ui/Table';
import Paper from 'material-ui/Paper';
import { connect } from 'react-redux';
import actionsCreators from '../../reducers/ResultCentres';
import TablePaginationActionsWrapped from '../Commons/Pagination'
import SortedTableHead from '../Commons/Table/SortedTableHead'
import {styles} from '../Commons/Table/TableStyles.css'
import {SortingActions } from '../../constants';
import {columnTitle, Colums} from './ColumnTitle'
import {sortOn} from '../../helpers/sortinngFunctions'
import ChangeItemForm from './ResultCentresChangeItemForm'
import {SimpleRow} from './ResultCentresSimpleRow'
import TableToolbar from '../Commons/Table/Toolbar'
import {InformationForm} from './InformationForm'

class ResultCentres extends Component {
    closeChangeModelForm = () => {        
        const {setModelChangeIsOpening} = this.props        
        setModelChangeIsOpening(false);           
    }
    closeInfoModelForm = () => {        
        const {setUpdatingItem, setModelInfoIsOpening} = this.props
        setUpdatingItem({});
        setModelInfoIsOpening(false); 
              
    }

    
    handleChangePage = (event, page) => {
        const { getDataTable, changePagination, paginationData} = this.props
        changePagination({ ...paginationData, currentPage: page });
        getDataTable();
    };

    handleChangeRowsPerPage = event => {
        const { getDataTable,
            changePagination,
            paginationData} = this.props
        changePagination({ ...paginationData, elementsPerPage: event.target.value });
        getDataTable();
    };

    componentDidMount() {
        const { getDataTable } = this.props
        getDataTable();
    }

    handleDeleteButtonClick = (id) => {
        const { deleteDataTable } = this.props
        deleteDataTable(id);
    }

    handleInfoButtonClick = (item) => {
        const {setUpdatingItem, setModelInfoIsOpening} = this.props
        setUpdatingItem(item)
        setModelInfoIsOpening(true)
    }

    handleCreateOrUpdateButtonClick = () => {
        const {setModelChangeIsOpening} = this.props   
        setModelChangeIsOpening(true);      
    }


    handleRequestSort = (event, property) => {
       
        const { sortingData, changeSorting } = this.props;
        let newOrder = SortingActions.SORT_DESC;

        if (sortingData.sortBy === property && sortingData.sort === SortingActions.SORT_DESC) {
            newOrder = SortingActions.SORT_ASC;
        }

        const newData = this.sortData(property, newOrder);           
        changeSorting({sort: newOrder, sortBy: property}, newData);
    };

    sortData = (property, order) => {
         const {data} = this.props;

           //if sorting on field with type NUMBER
        if(property === Colums.CODE){
            return data.sort(sortOn(property, 'number', order))
        }
        //if sorting on field with type STRING
        return data.sort(sortOn(property, 'string', order))

    }

    render() {
        const { classes, paginationData, data, sortingData, updatingDataItem, updateDataTable, createDataTable, modelChangingIsOpening, modelInfoIsOpening } = this.props;    
        const { currentPage, elementsPerPage, elementsCount} = paginationData;
        const emptyRows = elementsPerPage - Math.min(elementsPerPage, elementsCount - currentPage * elementsPerPage);

        return (
            <Paper className={classes.root}>
                <TableToolbar onCreate={this.handleCreateOrUpdateButtonClick} title={'Центры результатов'} />            
                {modelInfoIsOpening && <InformationForm elem = {updatingDataItem} cancel={this.closeInfoModelForm} handleDeleteButtonClick={this.handleDeleteButtonClick} handleUpdateButtonClick={this.handleCreateOrUpdateButtonClick} />}          
                {modelChangingIsOpening && updatingDataItem.id && <ChangeItemForm save={updateDataTable} header={"Редактирование"} cancel={this.closeChangeModelForm}/>}       
                {modelChangingIsOpening && !updatingDataItem.id && <ChangeItemForm save={createDataTable} header={"Создание"} cancel={this.closeChangeModelForm}/>}       
                  <div className={classes.tableWrapper}>
                    <Table className={classes.table}>
                        <SortedTableHead
                            rowClassName={classes.header}
                            cellClassName={classes.cell} 
                            order={sortingData.sort}
                            orderBy={sortingData.sortBy}                          
                            onRequestSort={this.handleRequestSort}
                            columnData={columnTitle} />
                        <TableBody>
                            {data && data.map(f =>
                                <SimpleRow key={f.id} classes={classes} row={f} handleInfoButtonClick={this.handleInfoButtonClick} /> 
                            )}
                            {emptyRows > 0 && (
                                <TableRow style={{ height: 48 * emptyRows }}>
                                    <TableCell colSpan={2} />
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
                            onChangePage={this.handleChangePage}
                            onChangeRowsPerPage={this.handleChangeRowsPerPage}
                            Actions={TablePaginationActionsWrapped}
                        />
                            </TableRow>
                        </TableFooter>
                    </Table>
                </div>
            </Paper>
        );
    }
}

ResultCentres.propTypes = {
    classes: PropTypes.object.isRequired,
    getDataTable: PropTypes.func.isRequired,
    deleteDataTable: PropTypes.func.isRequired,
    createDataTable: PropTypes.func.isRequired,
    updateDataTable: PropTypes.func.isRequired,
    changePagination: PropTypes.func.isRequired,
    changeSorting:  PropTypes.func.isRequired,
    setUpdatingItem: PropTypes.func.isRequired,
    data: PropTypes.array.isRequired,     
    sortingData: PropTypes.object.isRequired,
    paginationData: PropTypes.object.isRequired,
    updatingDataItem: PropTypes.object.isRequired, 
    setModelInfoIsOpening: PropTypes.object.isRequired, 
    setModelChangeIsOpening: PropTypes.object.isRequired,
    modelInfoIsOpening: PropTypes.object.isRequired,
    modelChangingIsOpening: PropTypes.object.isRequired,
};

const mapStateToProps = state => state.resultCentres;
const mapDispatchToProps = { ...actionsCreators };

export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(ResultCentres));



