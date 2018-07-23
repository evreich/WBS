import { TableActions, Prefix, Constants } from '../constants';
import { paginationReducerFor, setPaginationFor } from './Pagination'
import { sortingReducerFor, setSortingFor } from './Sorting'
import { combineReducers } from 'redux';
import actions, { tableDataReducerFor, updatingItemFor, modelInfoFor, modelChangeFor } from './TableData'

const makeVendorsObj = (obj) => ({
    id: obj.id,
    title: obj.title,
    profile: obj.profile
})


const changeVendorsPagination = (pagination) => (dispatch) => {
    dispatch(setPaginationFor(Prefix.FOR_VENDORS)(pagination));
}

const changeVendorsSorting = (sorting, sortedData) => (dispatch) => {
    dispatch(setSortingFor(Prefix.FOR_VENDORS)(sorting));
    dispatch({
        type: Prefix.FOR_VENDORS + TableActions.SORT_DATA_TABLE,
        payload: sortedData,
    });
}


export const reducer = combineReducers({
    data: tableDataReducerFor(Prefix.FOR_VENDORS),
    updatingDataItem: updatingItemFor(Prefix.FOR_VENDORS),
    paginationData: paginationReducerFor(Prefix.FOR_VENDORS),
    sortingData: sortingReducerFor(Prefix.FOR_VENDORS),
    modelInfoIsOpening: modelInfoFor(Prefix.FOR_VENDORS),
    modelChangingIsOpening: modelChangeFor(Prefix.FOR_VENDORS),
});



const actionsCreators = {
    getDataTable: actions.GetDataTableFor(Prefix.FOR_VENDORS, Constants.PROVIDER_CONTROLLER_URL),
    getFilteredDataTable: actions.GetDataTableFor(Prefix.FOR_VENDORS, Constants.GET_FILTERED_PROVIDERS),
    updateDataTable: (Item, resolve, reject) => actions.setUpdateDataTableFor(Prefix.FOR_VENDORS, Constants.PROVIDER_CONTROLLER_URL)(makeVendorsObj(Item), resolve, reject),
    deleteDataTable: actions.DeleteDataTableFor(Prefix.FOR_VENDORS, Constants.PROVIDER_CONTROLLER_URL),
    createDataTable: (Item, resolve, reject) => actions.createDataTableFor(Prefix.FOR_VENDORS, Constants.PROVIDER_CONTROLLER_URL)(makeVendorsObj(Item), resolve, reject),
    changeVendorsPagination,
    changeVendorsSorting,
    setUpdatingItem: (Item) => actions.setUpdatingItemFor(Prefix.FOR_VENDORS)(makeVendorsObj(Item)),
    setModelInfoIsOpening: (status) => actions.setModelInfoFor(Prefix.FOR_VENDORS)(status),
    setModelChangeIsOpening: (status) => actions.setModelChangeFor(Prefix.FOR_VENDORS)(status)
};


export default actionsCreators;