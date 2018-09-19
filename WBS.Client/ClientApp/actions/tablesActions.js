import TYPE from 'constants/actionTypes';
import request, { GET } from 'utils/fetchUtil';
import REQUEST_METHOD from 'constants/httpMethods';
import { concatParamsToPath } from 'utils/apiRequestUtil';
import api from 'constants/api';

export function receiveTable(data, title) {
    return {
        type: TYPE.GET_TABLE_SUCCESS,
        title,
        data
    }
}

export function updateTable(data, title) {
    return {
        type: TYPE.UPDATE_TABLE,
        title,
        data
    }
}

export function clearTable(title) {
    return {
        type: TYPE.CLEAR_TABLE,
        title
    }
}

export function errorsReceive(err) {
    return {
        type: TYPE.GET_TABLE_ERROR,
        errors: err
    }
}

export function setUpdatingItem(id, title) {
    return {
        type: TYPE.SET_UPDATING_ITEM,
        title,
        updatingItem: id
    }
}

export function clearUpdatingItem(title) {
    return {
        type: TYPE.CLEAR_UPDATING_ITEM,
        title
    }
}

//TODO
export function getTable(currentPage = 0, elementsPerPage = 5, route, title, queryParams) {
    return (dispatch) => {
        if (!route) throw new Error("Can't resolve URI");

        const queryPath = concatParamsToPath(queryParams);
        const commonPath = `${currentPage}/${elementsPerPage}`;
        const allPath = queryPath ? queryPath.concat(commonPath) : commonPath

        request(
            {
                method: REQUEST_METHOD.HTTP_GET,
                route: route + allPath,
            },
            (data) => {
                if (!title) throw new Error("Title is undefined");

                dispatch(receiveTable(data, title))
            },
            (ex) => dispatch(errorsReceive(ex))
        );

    }
}

export function changeData(currentPage = 0, elementsPerPage = 5, method, data, route, title) {
    return (dispatch) => {

        if (!route) throw new Error("Can't resolve URI");

        request(
            {
                method,
                route,
                data
            },
            () => dispatch(getTable(currentPage, elementsPerPage, route, title)),
            (ex) => dispatch(errorsReceive(ex))
        );

    }
}

export function deleteData(currentPage = 0, elementsPerPage = 5, id, route, title) {
    return (dispatch) => {

        if (!route) throw new Error("Can't resolve URI");

        request(
            {
                method: REQUEST_METHOD.HTTP_DELETE,
                route: route + `${id}/`,
            },
            () => dispatch(getTable(currentPage, elementsPerPage, route, title)),
            (ex) => dispatch(errorsReceive(ex))
        );

    }
}

export function getPermissions(title, objectType) {
    const params = { objectType };

    return (dispatch) => {
        /*dispatch({
            type: TYPE.REQUEST_IS_FETCHING,
            title
        })*/

        const onSuccess = (permissions) =>
            dispatch({
                type: TYPE.PERMISSIONS_IS_FETCHED,
                title,
                permissions
            });

        const onError = (/*error*/) => {
            //TODO:
        }

        GET(api.permissions, onSuccess, onError, params);
    }
}