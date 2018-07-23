import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from 'material-ui/styles';
import Table, {
  TableBody,
  TableCell,
  TableFooter,
  TablePagination,
  TableRow
} from 'material-ui/Table';
import { connect } from 'react-redux';
import actionsCreators from '../../../reducers/DAIRequests';
import Paper from 'material-ui/Paper';
import { styles} from '../TableStyles.css';
import columnData from './columnData';
import SortedTableHead from '../../Commons/Table/SortedTableHead'
import {SimpleRow} from './SimpleRow'
import TableToolbar from '../../Commons/Table/Toolbar'
import TablePaginationActionsWrapped from '../../Commons/Pagination/TablePaginationActions'
import ApplicationForInvestmentForm from '../ApplicationForInvestmentForm/ApplicationForInvestmentForm'
import {SortingActions } from '../../../constants';
import {sortOn} from '../../../helpers/sortinngFunctions'

class NewRequestsTable extends React.Component {
  closeChangeModelForm = () => {        
        const {setModelChangeIsOpening, setUpdatingItem} = this.props  
        setUpdatingItem({});      
        setModelChangeIsOpening(false);           
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

    handleUpdateButtonClick = (item) => {
        const {setUpdatingItem, setModelChangeIsOpening} = this.props
        setUpdatingItem(item);
        setModelChangeIsOpening(true);   
    }

    handleCreateButtonClick = () => {
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
        return data.sort(sortOn(property, 'string', order))

    }

  render(){
    const { classes, paginationData, data, sortingData, updatingDataItem, updateDataTable, createDataTable, modelChangingIsOpening } = this.props;       
    const { currentPage, elementsPerPage, elementsCount} = paginationData;
    const emptyRows = elementsPerPage - Math.min(elementsPerPage, elementsCount - currentPage * elementsPerPage);

    return (
      <Paper className={classes.root}>
      <TableToolbar onCreate={this.handleCreateButtonClick} title={'Новые заявки'} />   
        {modelChangingIsOpening && updatingDataItem.id && <ApplicationForInvestmentForm data={updatingDataItem} save={updateDataTable} cancel={this.closeChangeModelForm} classes={classes}/>}       
        {modelChangingIsOpening && !updatingDataItem.id && <ApplicationForInvestmentForm save={createDataTable} cancel={this.closeChangeModelForm} classes={classes}/>}                                    
        <div className={classes.tableWrapper}>
          <Table className={classes.table}>
          <SortedTableHead
                            rowClassName={classes.header}
                            cellClassName={classes.cell}
                            order={sortingData.sort}
                            orderBy={sortingData.sortBy}                          
                            onRequestSort={this.handleRequestSort}
                            columnData={columnData} />
            <TableBody>
                {data && data.map(f =>
                  <SimpleRow key={f.id} classes={classes} row={f} handleUpdateButtonClick={this.handleUpdateButtonClick} />)}
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

NewRequestsTable.propTypes = {
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
    setModelChangeIsOpening: PropTypes.func.isRequired,
    modelChangingIsOpening: PropTypes.bool.isRequired,
};

const mapStateToProps = state => state.daiRequests;
const mapDispatchToProps = {...actionsCreators};

export default withStyles(styles)(connect(mapStateToProps, mapDispatchToProps)(NewRequestsTable));
