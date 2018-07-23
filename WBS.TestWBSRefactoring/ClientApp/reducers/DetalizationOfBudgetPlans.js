import { TableActions, Prefix, Constants } from '../constants';
import { paginationReducerFor, setPaginationFor } from './Pagination'
import { sortingReducerFor, setSortingFor } from './Sorting'
import { combineReducers } from 'redux';
import actions, { tableDataReducerFor, updatingItemFor, modelInfoFor, modelChangeFor } from './TableData'

const makeObj = obj => ({
    ...obj
});

const changePagination = (pagination) => (dispatch) => {
    dispatch(setPaginationFor(Prefix.FOR_ITEMS_OF_BUDGET_PLAN)(pagination));
}

const changeSorting = (sorting, sortedData) => (dispatch) => {
    dispatch(setSortingFor(Prefix.FOR_ITEMS_OF_BUDGET_PLAN)(sorting));
    dispatch({
        type: Prefix.FOR_ITEMS_OF_BUDGET_PLAN + TableActions.SORT_DATA_TABLE,
        payload: sortedData,
    });
}

export const reducer = combineReducers({
    data: tableDataReducerFor(Prefix.FOR_ITEMS_OF_BUDGET_PLAN),
    updatingDataItem: updatingItemFor(Prefix.FOR_ITEMS_OF_BUDGET_PLAN),
    paginationData: paginationReducerFor(Prefix.FOR_ITEMS_OF_BUDGET_PLAN),
    sortingData: sortingReducerFor(Prefix.FOR_ITEMS_OF_BUDGET_PLAN),
    modelInfoIsOpening: modelInfoFor(Prefix.FOR_ITEMS_OF_BUDGET_PLAN),
    modelChangingIsOpening: modelChangeFor(Prefix.FOR_ITEMS_OF_BUDGET_PLAN),
});

const actionsCreators = {
    getDataTable:(siteId, budgetPlan) => (actions.GetDataTableFor(Prefix.FOR_ITEMS_OF_BUDGET_PLAN, Constants.GET_ITEMS_OF_BUDGET_PLAN)({
        siteId, budgetPlan
    })),
    updateDataTable: (Item, resolve, reject) => actions.setUpdateDataTableFor(Prefix.FOR_ITEMS_OF_BUDGET_PLAN, Constants.ITEMS_OF_BUDGET_PLAN_CONTROLLER_URL)(makeObj(Item), resolve, reject),
    deleteDataTable: actions.DeleteDataTableFor(Prefix.FOR_ITEMS_OF_BUDGET_PLAN, Constants.ITEMS_OF_BUDGET_PLAN_CONTROLLER_URL),
    createDataTable: (Item, resolve, reject) => actions.createDataTableFor(Prefix.FOR_ITEMS_OF_BUDGET_PLAN, Constants.ITEMS_OF_BUDGET_PLAN_CONTROLLER_URL)(makeObj(Item), resolve, reject),
    changePagination,
    changeSorting,
    setUpdatingItem: (Item) => actions.setUpdatingItemFor(Prefix.FOR_ITEMS_OF_BUDGET_PLAN)(makeObj(Item)),
    setModelInfoIsOpening: (status) => actions.setModelInfoFor(Prefix.FOR_ITEMS_OF_BUDGET_PLAN)(status),
    setModelChangeIsOpening: (status) => actions.setModelChangeFor(Prefix.FOR_ITEMS_OF_BUDGET_PLAN)(status)
};

export default actionsCreators;