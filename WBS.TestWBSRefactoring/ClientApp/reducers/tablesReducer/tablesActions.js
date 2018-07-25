import TYPE from './actionsTypes';
import request from '../../utils/fetchUtil';
import REQUEST_METHOD from '../../settings/httpMethods';


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

export function getTable(currentPage = 0, elementsPerPage = 5, route, title) {
    return (dispatch) => {

        if (!route) throw new Error("Can't resolve URI");

        request(
            {
                method: REQUEST_METHOD.HTTP_GET,
                route: route + `${currentPage}/${elementsPerPage}`,
            }, 
            (data) => {
                if(!title) throw new Error("Title is undefined");

                dispatch(receiveTable(data, title))
            },
            (ex) => dispatch(errorsReceive(ex))
        );

    }
}