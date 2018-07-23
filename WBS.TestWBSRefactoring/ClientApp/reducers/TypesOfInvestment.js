import { TableActions, Prefix, Constants } from '../constants';
import { paginationReducerFor, setPaginationFor } from './Pagination'
import { sortingReducerFor, setSortingFor } from './Sorting'
import { combineReducers } from 'redux';
import actions, { tableDataReducerFor, updatingItemFor, modelInfoFor, modelChangeFor } from './TableData'

const makeObj = (obj) => ({
    id: obj.id,
    title: obj.title,
    code: obj.code,
    externalCode: obj.externalCode,
})


const changePagination = (pagination) => (dispatch) => {
    dispatch(setPaginationFor(Prefix.FOR_INVESTMENT)(pagination));
}

const changeSorting = (sorting, sortedData) => (dispatch) => {
    dispatch(setSortingFor(Prefix.FOR_INVESTMENT)(sorting));
    dispatch({
        type: Prefix.FOR_INVESTMENT + TableActions.SORT_DATA_TABLE,
        payload: sortedData,
    });
}

export const reducer = combineReducers({
    data: tableDataReducerFor(Prefix.FOR_INVESTMENT),
    updatingDataItem: updatingItemFor(Prefix.FOR_INVESTMENT),
    paginationData: paginationReducerFor(Prefix.FOR_INVESTMENT),
    sortingData: sortingReducerFor(Prefix.FOR_INVESTMENT),
    modelInfoIsOpening: modelInfoFor(Prefix.FOR_INVESTMENT),
    modelChangingIsOpening: modelChangeFor(Prefix.FOR_INVESTMENT),

});



const actionsCreators = {
    getDataTable: actions.GetDataTableFor(Prefix.FOR_INVESTMENT, Constants.INVESTMENT_CONTROLLER_URL),
    updateDataTable: (Item, resolve, reject) => actions.setUpdateDataTableFor(Prefix.FOR_INVESTMENT, Constants.INVESTMENT_CONTROLLER_URL)(makeObj(Item), resolve, reject),
    deleteDataTable: actions.DeleteDataTableFor(Prefix.FOR_INVESTMENT, Constants.INVESTMENT_CONTROLLER_URL),
    createDataTable: (Item, resolve, reject) => actions.createDataTableFor(Prefix.FOR_INVESTMENT, Constants.INVESTMENT_CONTROLLER_URL)(makeObj(Item), resolve, reject),
    changePagination,
    changeSorting,
    setUpdatingItem: (Item) => actions.setUpdatingItemFor(Prefix.FOR_INVESTMENT)(makeObj(Item)),
    setModelInfoIsOpening: (status) => actions.setModelInfoFor(Prefix.FOR_INVESTMENT)(status),
    setModelChangeIsOpening: (status) => actions.setModelChangeFor(Prefix.FOR_INVESTMENT)(status)
};


export default actionsCreators;