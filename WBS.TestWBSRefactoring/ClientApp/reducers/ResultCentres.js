import { TableActions, Prefix, Constants } from '../constants';
import { paginationReducerFor, setPaginationFor } from './Pagination'
import { sortingReducerFor, setSortingFor } from './Sorting'
import { combineReducers } from 'redux';
import actions, { tableDataReducerFor, updatingItemFor, modelInfoFor, modelChangeFor } from './TableData'

const makeObj = (obj) => ({
    id: obj.id,
    title: obj.title,
    code: obj.code,

})


const changePagination = (pagination) => (dispatch) => {
    dispatch(setPaginationFor(Prefix.FOR_RESULT_CENTRE)(pagination));
}

const changeSorting = (sorting, sortedData) => (dispatch) => {
    dispatch(setSortingFor(Prefix.FOR_RESULT_CENTRE)(sorting));
    dispatch({
        type: Prefix.FOR_RESULT_CENTRE + TableActions.SORT_DATA_TABLE,
        payload: sortedData,
    });
}


export const reducer = combineReducers({
    data: tableDataReducerFor(Prefix.FOR_RESULT_CENTRE),
    updatingDataItem: updatingItemFor(Prefix.FOR_RESULT_CENTRE),
    paginationData: paginationReducerFor(Prefix.FOR_RESULT_CENTRE),
    sortingData: sortingReducerFor(Prefix.FOR_RESULT_CENTRE),
    modelInfoIsOpening: modelInfoFor(Prefix.FOR_RESULT_CENTRE),
    modelChangingIsOpening: modelChangeFor(Prefix.FOR_RESULT_CENTRE),
});



const actionsCreators = {
    getDataTable: actions.GetDataTableFor(Prefix.FOR_RESULT_CENTRE, Constants.RESULT_CENTRE_CONTROLLER_URL),
    updateDataTable: (Item, resolve, reject) => actions.setUpdateDataTableFor(Prefix.FOR_RESULT_CENTRE, Constants.RESULT_CENTRE_CONTROLLER_URL)(makeObj(Item), resolve, reject),
    deleteDataTable: actions.DeleteDataTableFor(Prefix.FOR_RESULT_CENTRE, Constants.RESULT_CENTRE_CONTROLLER_URL),
    createDataTable: (Item, resolve, reject) => actions.createDataTableFor(Prefix.FOR_RESULT_CENTRE, Constants.RESULT_CENTRE_CONTROLLER_URL)(makeObj(Item), resolve, reject),
    changePagination,
    changeSorting,
    setUpdatingItem: (Item) => actions.setUpdatingItemFor(Prefix.FOR_RESULT_CENTRE)(makeObj(Item)),
    setModelInfoIsOpening: (status) => actions.setModelInfoFor(Prefix.FOR_RESULT_CENTRE)(status),
    setModelChangeIsOpening: (status) => actions.setModelChangeFor(Prefix.FOR_RESULT_CENTRE)(status)
};


export default actionsCreators;