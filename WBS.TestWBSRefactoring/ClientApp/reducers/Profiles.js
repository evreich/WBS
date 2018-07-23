import { TableActions, Prefix, Constants } from '../constants';
import { paginationReducerFor, setPaginationFor } from './Pagination'
import { sortingReducerFor, setSortingFor } from './Sorting'
import { combineReducers } from 'redux';
import actions, { tableDataReducerFor, updatingItemFor, modelInfoFor, modelChangeFor } from './TableData'
import { fetch } from '../utils';

const makeProfileViewModelObj = (obj) => ({
    id: obj.id,
    login: obj.login,
    fio: obj.fio,
    jobPosition: obj.jobPosition,
    department: obj.department,
    deletionMark: obj.deletionMark ? obj.deletionMark : false,
    roles: obj.roles

})

const makeProfileObj = (obj) => ({
    id: obj.id,
    login: obj.login,
    fio: obj.fio,
    jobPosition: obj.jobPosition,
    department: obj.department,
    deletionMark: false,
    roles: obj.roles,
    password: obj.password
})

const changeProfilesPagination = (pagination) => (dispatch) => {
    dispatch(setPaginationFor(Prefix.FOR_PROFILES)(pagination));
}

const changeProfilesSorting = (sorting, sortedData) => (dispatch) => {
    dispatch(setSortingFor(Prefix.FOR_PROFILES)(sorting));
    dispatch({
        type: Prefix.FOR_PROFILES + TableActions.SORT_DATA_TABLE,
        payload: sortedData,
    });
}

const markUserForDeletion = (Item) => (dispatch, getState) => {
    fetch(Constants.PROFILE_SET_DELETION_MARK, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(Item)
        }, dispatch, getState().auth)
        .then(response =>
            response.json()
            .then(result => {
                dispatch({
                    type: Prefix.FOR_PROFILES + TableActions.UPDATE_DATA_TABLE_SUCCESS,
                    payload: result,
                });

            }))
        .catch((error) => alert(error))
};


export const reducer = combineReducers({
    data: tableDataReducerFor(Prefix.FOR_PROFILES),
    updatingDataItem: updatingItemFor(Prefix.FOR_PROFILES),
    paginationData: paginationReducerFor(Prefix.FOR_PROFILES),
    sortingData: sortingReducerFor(Prefix.FOR_PROFILES),
    modelInfoIsOpening: modelInfoFor(Prefix.FOR_PROFILES),
    modelChangingIsOpening: modelChangeFor(Prefix.FOR_PROFILES),
});



const actionsCreators = {
    getDataTable: actions.GetDataTableFor(Prefix.FOR_PROFILES, Constants.PROFILE_CONTROLLER_URL),
    updateDataTable: (Item) => actions.setUpdateDataTableFor(Prefix.FOR_PROFILES, Constants.PROFILE_CONTROLLER_URL)(makeProfileViewModelObj(Item)),
    deleteDataTable: markUserForDeletion,
    createDataTable: (Item) => actions.createDataTableFor(Prefix.FOR_PROFILES, Constants.PROFILE_CONTROLLER_URL)(makeProfileObj(Item)),
    changeProfilesPagination,
    changeProfilesSorting,
    setUpdatingItem: (Item) => actions.setUpdatingItemFor(Prefix.FOR_PROFILES)(makeProfileViewModelObj(Item)),
    setModelInfoIsOpening: (status) => actions.setModelInfoFor(Prefix.FOR_PROFILES)(status),
    setModelChangeIsOpening: (status) => actions.setModelChangeFor(Prefix.FOR_PROFILES)(status)
};


export default actionsCreators;