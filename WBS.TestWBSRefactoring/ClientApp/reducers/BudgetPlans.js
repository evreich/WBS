import { TableActions, Prefix, Constants } from "../constants";
import { paginationReducerFor, setPaginationFor } from "./Pagination";
import { sortingReducerFor, setSortingFor } from "./Sorting";
import { combineReducers } from "redux";
import actions, {
    tableDataReducerFor,
    updatingItemFor,
    modelInfoFor,
    modelChangeFor
} from "./TableData";

import { reducer as detalizationOfBPReducer } from "./DetalizationOfBudgetPlans";

const makeFormatObj = obj => ({
    ...obj
});

const changeFormatPagination = pagination => dispatch => {
    dispatch(setPaginationFor(Prefix.FOR_BUDGET_PLANS)(pagination));
};

const changeFormatSorting = (sorting, sortedData) => dispatch => {
    dispatch(setSortingFor(Prefix.FOR_BUDGET_PLANS)(sorting));
    dispatch({
        type: Prefix.FOR_BUDGET_PLANS + TableActions.SORT_DATA_TABLE,
        payload: sortedData
    });
};

//собираем редьюсер
export const reducer = combineReducers({
    data: tableDataReducerFor(Prefix.FOR_BUDGET_PLANS),
    updatingDataItem: updatingItemFor(Prefix.FOR_BUDGET_PLANS),
    paginationData: paginationReducerFor(Prefix.FOR_BUDGET_PLANS),
    sortingData: sortingReducerFor(Prefix.FOR_BUDGET_PLANS),
    modelInfoIsOpening: modelInfoFor(Prefix.FOR_BUDGET_PLANS),
    modelChangingIsOpening: modelChangeFor(Prefix.FOR_BUDGET_PLANS),
    detalizationOfSelectedBP: detalizationOfBPReducer
});

const actionsCreators = {
    getDataTable: actions.GetDataTableFor(
        Prefix.FOR_BUDGET_PLANS,
        Constants.BUDGET_PLANS_CONTROLLER_URL
    ),
    updateDataTable: (Item, resolve, reject) =>
        actions.setUpdateDataTableFor(
            Prefix.FOR_BUDGET_PLANS,
            Constants.BUDGET_PLANS_CONTROLLER_URL
        )(makeFormatObj(Item), resolve, reject),
    deleteDataTable: actions.DeleteDataTableFor(
        Prefix.FOR_BUDGET_PLANS,
        Constants.BUDGET_PLANS_CONTROLLER_URL
    ),
    createDataTable: (Item, resolve, reject) =>
        actions.createDataTableFor(
            Prefix.FOR_BUDGET_PLANS,
            Constants.BUDGET_PLANS_CONTROLLER_URL
        )(makeFormatObj(Item), resolve, reject),
    changeFormatPagination,
    changeFormatSorting,
    setUpdatingItem: Item =>
        actions.setUpdatingItemFor(Prefix.FOR_BUDGET_PLANS)(
            makeFormatObj(Item)
        ),
    setModelInfoIsOpening: status =>
        actions.setModelInfoFor(Prefix.FOR_BUDGET_PLANS)(status),
    setModelChangeIsOpening: status =>
        actions.setModelChangeFor(Prefix.FOR_BUDGET_PLANS)(status)
};

export default actionsCreators;
