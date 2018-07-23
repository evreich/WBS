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
    dispatch(setPaginationFor(Prefix.FOR_CATEGORY_GROUPS)(pagination));
}

const changeSorting = (sorting, sortedData) => (dispatch) => {
    dispatch(setSortingFor(Prefix.FOR_CATEGORY_GROUPS)(sorting));
    dispatch({
        type: Prefix.FOR_CATEGORY_GROUPS + TableActions.SORT_DATA_TABLE,
        payload: sortedData,
    });
}


export const reducer = combineReducers({
    data: tableDataReducerFor(Prefix.FOR_CATEGORY_GROUPS),
    updatingDataItem: updatingItemFor(Prefix.FOR_CATEGORY_GROUPS),
    paginationData: paginationReducerFor(Prefix.FOR_CATEGORY_GROUPS),
    sortingData: sortingReducerFor(Prefix.FOR_CATEGORY_GROUPS),
    modelInfoIsOpening: modelInfoFor(Prefix.FOR_CATEGORY_GROUPS),
    modelChangingIsOpening: modelChangeFor(Prefix.FOR_CATEGORY_GROUPS),
});



const actionsCreators = {
    getDataTable: actions.GetDataTableFor(Prefix.FOR_CATEGORY_GROUPS, Constants.CATEGORY_GROUPS_CONTROLLER_URL),
    updateDataTable: (Item, resolve, reject) => actions.setUpdateDataTableFor(Prefix.FOR_CATEGORY_GROUPS, Constants.CATEGORY_GROUPS_CONTROLLER_URL)(makeObj(Item), resolve, reject),
    deleteDataTable: actions.DeleteDataTableFor(Prefix.FOR_CATEGORY_GROUPS, Constants.CATEGORY_GROUPS_CONTROLLER_URL),
    createDataTable: (Item, resolve, reject) => actions.createDataTableFor(Prefix.FOR_CATEGORY_GROUPS, Constants.CATEGORY_GROUPS_CONTROLLER_URL)(makeObj(Item), resolve, reject),
    changePagination,
    changeSorting,
    setUpdatingItem: (Item) => actions.setUpdatingItemFor(Prefix.FOR_CATEGORY_GROUPS)(makeObj(Item)),
    setModelInfoIsOpening: (status) => actions.setModelInfoFor(Prefix.FOR_CATEGORY_GROUPS)(status),
    setModelChangeIsOpening: (status) => actions.setModelChangeFor(Prefix.FOR_CATEGORY_GROUPS)(status)
};


export default actionsCreators;