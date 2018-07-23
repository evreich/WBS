import { TableActions, Prefix, Constants } from '../constants';
import { paginationReducerFor, setPaginationFor } from './Pagination'
import { sortingReducerFor, setSortingFor } from './Sorting'
import { combineReducers } from 'redux';
import actions, { tableDataReducerFor, updatingItemFor, modelInfoFor, modelChangeFor } from './TableData'

const makeFormatObj = (obj) => ({
    ...obj
})


const changeFormatPagination = (pagination) => (dispatch) => {
    dispatch(setPaginationFor(Prefix.FOR_FORMATS)(pagination));
}

const changeFormatSorting = (sorting, sortedData) => (dispatch) => {
    dispatch(setSortingFor(Prefix.FOR_FORMATS)(sorting));
    dispatch({
        type: Prefix.FOR_FORMATS + TableActions.SORT_DATA_TABLE,
        payload: sortedData,
    });
}



//собираем редьюсер Поставщиков
export const reducer = combineReducers({
    data: tableDataReducerFor(Prefix.FOR_FORMATS),
    updatingDataItem: updatingItemFor(Prefix.FOR_FORMATS),
    paginationData: paginationReducerFor(Prefix.FOR_FORMATS),
    sortingData: sortingReducerFor(Prefix.FOR_FORMATS),
    modelInfoIsOpening: modelInfoFor(Prefix.FOR_FORMATS),
    modelChangingIsOpening: modelChangeFor(Prefix.FOR_FORMATS),
});



const actionsCreators = {
    getDataTable: actions.GetDataTableFor(Prefix.FOR_FORMATS, Constants.FORMAT_CONTROLLER_URL),
    updateDataTable: (Item) => actions.setUpdateDataTableFor(Prefix.FOR_FORMATS, Constants.FORMAT_CONTROLLER_URL)(makeFormatObj(Item)),
    deleteDataTable: actions.DeleteDataTableFor(Prefix.FOR_FORMATS, Constants.FORMAT_CONTROLLER_URL),
    createDataTable: (Item) => actions.createDataTableFor(Prefix.FOR_FORMATS, Constants.FORMAT_CONTROLLER_URL)(makeFormatObj(Item)),
    changeFormatPagination,
    changeFormatSorting,
    setUpdatingItem: (Item) => actions.setUpdatingItemFor(Prefix.FOR_FORMATS)(makeFormatObj(Item)),
    setModelInfoIsOpening: (status) => actions.setModelInfoFor(Prefix.FOR_FORMATS)(status),
    setModelChangeIsOpening: (status) => actions.setModelChangeFor(Prefix.FOR_FORMATS)(status)
};


export default actionsCreators;