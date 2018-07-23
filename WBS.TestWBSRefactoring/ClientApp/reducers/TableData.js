import { TableActions, Prefix } from '../constants';
import { setPaginationFor } from './Pagination'
import { fetch } from '../utils';
import formActions from './form';
import { makeURL } from '../helpers/urlHelper';

//основной универсальный редьюсер для компонента, представляющего собой таблицу с crud 
export const tableDataReducerFor = (prefix, initialState = []) => {
    const tableDataReducer = (state = initialState, action) => {
        switch (action.type) {
            case prefix + TableActions.FETCH_DATA_TABLE_SUCCESS:
                return action.payload
            case prefix + TableActions.DELETE_DATA_TABLE_SUCCESS:
                return state && state.filter(item => item.id !== action.payload.id);

            case prefix + TableActions.CREATE_DATA_TABLE_SUCCESS:
                return [
                    ...state,
                    action.payload,
                ]
            case prefix + TableActions.UPDATE_DATA_TABLE_SUCCESS:
                return state && state.map(item => (item.id === action.payload.id ? action.payload : item))
            case prefix + TableActions.SORT_DATA_TABLE:
                return action.payload
            default:
                return state;
        }
    }
    return tableDataReducer;

};

export const updatingItemFor = (prefix) => {
    const updatingItem = (state = {}, action) => {
        switch (action.type) {
            case prefix + TableActions.SET_UPDATING_ITEM:
                return action.item
            default:
                return state;
        }
    }
    return updatingItem;
}

export const modelInfoFor = (prefix) => {
    const modelInfo = (state = false, action) => {
        switch (action.type) {
            case prefix + TableActions.CLOSE_OR_OPEN_MODEL_INFO:
                return action.status
            default:
                return state;
        }
    }
    return modelInfo;
}

// получение данных от сервера GET запросом и сохранение их в сторе приложения
// params - необязательный параметр, представляющий собой объект, содержащий набор передаваемых параметров
const GetDataTableFor = (prefix, pathLocation) => {
    const getDataTable = (params = {}) => (dispatch, getState) => {
        const {
            currentPage,
            elementsPerPage
        } = getCurrentPaginationFor(prefix, getState)

        const url = makeURL(pathLocation, params);
        url.searchParams.append('currentPage', currentPage);
        url.searchParams.append('pageSize', elementsPerPage);

        fetch(url.href, {
            method: 'GET',
        }, dispatch, getState().auth)
            .then(response =>
                response.json()
                    .then(result => {
                        dispatch({
                            type: prefix + TableActions.FETCH_DATA_TABLE_SUCCESS,
                            payload: result.data,
                        });

                        dispatch(setPaginationFor(prefix)({
                            currentPage,
                            elementsPerPage,
                            elementsCount: result.pagination.elementsCount
                        }));

                    })
            )
            .catch(response => {
                response.json()
                    .then(result => {
                        formActions.setError(result)(dispatch)
                        alert(result);
                    })
            });
    };
    return getDataTable;
}

// удаление данных на сервере по id записи  DELETE запросом и обновление стора приложения
const DeleteDataTableFor = (prefix, url) => {
    const deleteDataTable = (Id) => (dispatch, getState) => {
        fetch(`${url}/${Id}`, {
            method: 'DELETE',
        }, dispatch, getState().auth)
            .then(response =>
                response.json()
                    .then(
                        GetDataTableFor(prefix, url)()(dispatch, getState)
                    ))
            .catch(response => {
                response.json()
                    .then(result => {
                        formActions.setError(result)(dispatch)
                        alert(result);
                    })

            });
    }
    return deleteDataTable;
}

// создание записи на сервере POST запросом и обновление стора приложения
const createDataTableFor = (prefix, url) => {
    const createDataTable = (Item) => (dispatch, getState) => {
        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(Item)
        }, dispatch, getState().auth)
            .then(response =>
                response.json()
                    .then(
                        GetDataTableFor(prefix, url)()(dispatch, getState),
                        setModelChangeFor(prefix)(false)(dispatch)

                    ))
            .catch(response => {
                response.json()
                    .then(result => {
                        formActions.setError(result)(dispatch)
                        alert(result);
                    })
            })

    };
    return createDataTable;
}

const setUpdatingItemFor = (prefix) => {
    const setUpdatingItem = (item) => (dispatch) => {
        dispatch({
            type: prefix + TableActions.SET_UPDATING_ITEM,
            item: item
        });
    }
    return setUpdatingItem
}

const setUpdateDataTableFor = (prefix, url) => {
    const updateDataTable = (Item) => (dispatch, getState) => {
        fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(Item)
        }, dispatch, getState().auth)
            .then(response => {
                if (response.ok) {
                    return response.json()
                        .then(result => {
                            dispatch({
                                type: prefix + TableActions.UPDATE_DATA_TABLE_SUCCESS,
                                payload: result,
                            });
                            setUpdatingItemFor(prefix)(result)(dispatch);
                            setModelChangeFor(prefix)(false)(dispatch);
                        })
                }
                formActions.clearError(dispatch)
            })
            .catch(response => {
                response.json()
                    .then(result => {
                        formActions.setError(result)(dispatch)
                        alert(result);
                    })
            })
    };

    return updateDataTable;
};


const setModelInfoFor = (prefix) => {
    const setModelInfo = (status) => (dispatch) => {
        dispatch({
            type: prefix + TableActions.CLOSE_OR_OPEN_MODEL_INFO,
            status: status
        });
    }
    return setModelInfo
}
export const modelChangeFor = (prefix) => {
    const modelChange = (state = false, action) => {
        switch (action.type) {
            case prefix + TableActions.CLOSE_OR_OPEN_MODEL_CHANGE:
                return action.status
            default:
                return state;
        }
    }
    return modelChange;
}
const setModelChangeFor = (prefix) => {
    const setModelChange = (status) => (dispatch) => {
        dispatch({
            type: prefix + TableActions.CLOSE_OR_OPEN_MODEL_CHANGE,
            status: status
        });
    }
    return setModelChange
}

const actionsCreators = {
    setUpdateDataTableFor,
    setUpdatingItemFor,
    createDataTableFor,
    DeleteDataTableFor,
    GetDataTableFor,
    setModelInfoFor,
    setModelChangeFor
}
export default actionsCreators


function getCurrentPaginationFor(prefix, getState) {
    switch (prefix) {
        case Prefix.FOR_FORMATS:
            return getState().formats.paginationData
        case Prefix.FOR_PROFILES:
            return getState().profiles.paginationData
        case Prefix.FOR_SITES:
            return getState().sits.paginationData
        case Prefix.FOR_BUDGET_PLANS:
            return getState().budgetPlans.paginationData
        case Prefix.FOR_VENDORS:
            return getState().vendors.paginationData
        case Prefix.FOR_INVESTMENT:
            return getState().typesOfInvestment.paginationData
        case Prefix.FOR_RESULT_CENTRE:
            return getState().resultCentres.paginationData
        case Prefix.FOR_CATEGORY_GROUPS:
            return getState().categoryGroups.paginationData
        case Prefix.FOR_CATEGORIES_OF_EQUIP:
            return getState().categoriesOfEquipment.paginationData
        case Prefix.FOR_DAI_REQUEST:
            return getState().daiRequests.paginationData
        case Prefix.FOR_ITEMS_OF_BUDGET_PLAN:
            return getState().budgetPlans.detalizationOfSelectedBP.paginationData
        default:
            return {}
    }
}