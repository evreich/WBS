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

const makeObj = obj => ({
    ...obj});

const changePagination = pagination => dispatch => {
    dispatch(setPaginationFor(Prefix.FOR_CATEGORIES_OF_EQUIP)(pagination));
};

const changeSorting = (sorting, sortedData) => dispatch => {
    dispatch(setSortingFor(Prefix.FOR_CATEGORIES_OF_EQUIP)(sorting));
    dispatch({
        type: Prefix.FOR_CATEGORIES_OF_EQUIP + TableActions.SORT_DATA_TABLE,
        payload: sortedData
    });
};

export const reducer = combineReducers({
    data: tableDataReducerFor(Prefix.FOR_CATEGORIES_OF_EQUIP),
    updatingDataItem: updatingItemFor(Prefix.FOR_CATEGORIES_OF_EQUIP),
    paginationData: paginationReducerFor(Prefix.FOR_CATEGORIES_OF_EQUIP),
    sortingData: sortingReducerFor(Prefix.FOR_CATEGORIES_OF_EQUIP),
    modelInfoIsOpening: modelInfoFor(Prefix.FOR_CATEGORIES_OF_EQUIP),
    modelChangingIsOpening: modelChangeFor(Prefix.FOR_CATEGORIES_OF_EQUIP)
});

const actionsCreators = {
    getDataTable: actions.GetDataTableFor(
        Prefix.FOR_CATEGORIES_OF_EQUIP,
        Constants.CATEGORIES_OF_EQUIP_CONTROLLER_URL
    ),
    updateDataTable: (Item, resolve, reject) =>
        actions.setUpdateDataTableFor(
            Prefix.FOR_CATEGORIES_OF_EQUIP,
            Constants.CATEGORIES_OF_EQUIP_CONTROLLER_URL
        )(makeObj(Item), resolve, reject),
    deleteDataTable: actions.DeleteDataTableFor(
        Prefix.FOR_CATEGORIES_OF_EQUIP,
        Constants.CATEGORIES_OF_EQUIP_CONTROLLER_URL
    ),
    createDataTable: (Item, resolve, reject) =>
        actions.createDataTableFor(
            Prefix.FOR_CATEGORIES_OF_EQUIP,
            Constants.CATEGORIES_OF_EQUIP_CONTROLLER_URL
        )(makeObj(Item), resolve, reject),
    changePagination,
    changeSorting,
    setUpdatingItem: Item =>
        actions.setUpdatingItemFor(Prefix.FOR_CATEGORIES_OF_EQUIP)(
            makeObj(Item)
        ),
    setModelInfoIsOpening: status =>
        actions.setModelInfoFor(Prefix.FOR_CATEGORIES_OF_EQUIP)(status),
    setModelChangeIsOpening: status =>
        actions.setModelChangeFor(Prefix.FOR_CATEGORIES_OF_EQUIP)(status)
};

export default actionsCreators;
