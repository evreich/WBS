import { TableActions, Prefix, Constants } from '../constants';
import { paginationReducerFor, setPaginationFor } from './Pagination'
import { sortingReducerFor, setSortingFor } from './Sorting'
import { combineReducers } from 'redux';
import actions, { tableDataReducerFor, updatingItemFor, modelChangeFor } from './TableData'

const makeObj = (obj) => ({
    ...obj,
    providers: obj.providers ? obj.providers : [],
    technicalServices: obj.technicalServices ? obj.technicalServices : [],
    approvalOfTechExpertIsRequired: obj.approvalOfTechExpertIsRequired ? obj.approvalOfTechExpertIsRequired : false,
    commentForDirectorGeneral: obj.commentForDirectorGeneral

})



const changePagination = (pagination) => (dispatch) => {
    dispatch(setPaginationFor(Prefix.FOR_DAI_REQUEST)(pagination));
}

const changeSorting = (sorting, sortedData) => (dispatch) => {
    dispatch(setSortingFor(Prefix.FOR_DAI_REQUEST)(sorting));
    dispatch({
        type: Prefix.FOR_DAI_REQUEST + TableActions.SORT_DATA_TABLE,
        payload: sortedData,
    });
}


export const reducer = combineReducers({
    data: tableDataReducerFor(Prefix.FOR_DAI_REQUEST),
    updatingDataItem: updatingItemFor(Prefix.FOR_DAI_REQUEST),
    paginationData: paginationReducerFor(Prefix.FOR_DAI_REQUEST),
    sortingData: sortingReducerFor(Prefix.FOR_DAI_REQUEST),
    modelChangingIsOpening: modelChangeFor(Prefix.FOR_DAI_REQUEST),
});



const actionsCreators = {
    getDataTable: actions.GetDataTableFor(Prefix.FOR_DAI_REQUEST, Constants.DAI_REQUEST_CONTROLLER_URL),
    updateDataTable: (Item, resolve, reject) => actions.setUpdateDataTableFor(Prefix.FOR_DAI_REQUEST, Constants.DAI_REQUEST_CONTROLLER_URL)(makeObj(Item), resolve, reject),
    deleteDataTable: actions.DeleteDataTableFor(Prefix.FOR_DAI_REQUEST, Constants.DAI_REQUEST_CONTROLLER_URL),
    createDataTable: (Item, resolve, reject) => actions.createDataTableFor(Prefix.FOR_DAI_REQUEST, Constants.DAI_REQUEST_CONTROLLER_URL)(makeObj(Item), resolve, reject),
    changePagination,
    changeSorting,
    setUpdatingItem: (Item) => actions.setUpdatingItemFor(Prefix.FOR_DAI_REQUEST)(makeObj(Item)),
    setModelChangeIsOpening: (status) => actions.setModelChangeFor(Prefix.FOR_DAI_REQUEST)(status)
};


export default actionsCreators;