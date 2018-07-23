import { TableActions, Prefix, Constants } from '../constants';
import { paginationReducerFor, setPaginationFor } from './Pagination'
import { sortingReducerFor, setSortingFor } from './Sorting'
import { combineReducers } from 'redux';
import actions, { tableDataReducerFor, updatingItemFor, modelInfoFor, modelChangeFor } from './TableData'

const makeSitObj = (obj) => ({
    id: obj.id,
    title: obj.title,
    formatId: obj.formatId,
    formatTitle: obj.formatTitle,
    technicalExpertId: obj.technicalExpertId,
    technicalExpertFio: obj.technicalExpertFio,
    kySitId: obj.kySitId,
    kySitFio: obj.kySitFio,
    directorOfSitId: obj.directorOfSitId,
    directorOfSitFio: obj.directorOfSitFio,
    createrOfBudgetId: obj.createrOfBudgetId,
    createrOfBudgetFio: obj.createrOfBudgetFio,
    kyRegionId: obj.kyRegionId,
    kyRegionFio: obj.kyRegionFio,
    operationDirectorId: obj.operationDirectorId,
    operationDirectorFio: obj.operationDirectorFio
})


const changeSitsPagination = (pagination) => (dispatch) => {
    dispatch(setPaginationFor(Prefix.FOR_SITES)(pagination));
}

const changeSitsSorting = (sorting, sortedData) => (dispatch) => {
    dispatch(setSortingFor(Prefix.FOR_SITES)(sorting));
    dispatch({
        type: Prefix.FOR_SITES + TableActions.SORT_DATA_TABLE,
        payload: sortedData,
    });
}


export const reducer = combineReducers({
    data: tableDataReducerFor(Prefix.FOR_SITES),
    updatingDataItem: updatingItemFor(Prefix.FOR_SITES),
    paginationData: paginationReducerFor(Prefix.FOR_SITES),
    sortingData: sortingReducerFor(Prefix.FOR_SITES),
    modelInfoIsOpening: modelInfoFor(Prefix.FOR_SITES),
    modelChangingIsOpening: modelChangeFor(Prefix.FOR_SITES),
});



const actionsCreators = {
    getDataTable: actions.GetDataTableFor(Prefix.FOR_SITES, Constants.SITS_CONTROLLER_URL),
    updateDataTable: (Item, resolve, reject) => actions.setUpdateDataTableFor(Prefix.FOR_SITES, Constants.SITS_CONTROLLER_URL)(makeSitObj(Item), resolve, reject),
    deleteDataTable: actions.DeleteDataTableFor(Prefix.FOR_SITES, Constants.SITS_CONTROLLER_URL),
    createDataTable: (Item, resolve, reject) => actions.createDataTableFor(Prefix.FOR_SITES, Constants.SITS_CONTROLLER_URL)(makeSitObj(Item), resolve, reject),
    changeSitsPagination,
    changeSitsSorting,
    setUpdatingItem: (Item) => actions.setUpdatingItemFor(Prefix.FOR_SITES)(makeSitObj(Item)),
    setModelInfoIsOpening: (status) => actions.setModelInfoFor(Prefix.FOR_SITES)(status),
    setModelChangeIsOpening: (status) => actions.setModelChangeFor(Prefix.FOR_SITES)(status)
};


export default actionsCreators;