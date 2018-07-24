import TYPE from './actionsTypes'
import { request } from '../../api/api';
import REQUEST_METHOD from '../../settings/httpMethods';


export function receiveTable(data) {
    return {
        type: TYPE.GET_TABLE_SUCCESS,
        ...data
    }
}

export function errorsReceive(err) {
    return {
        type: TYPE.GET_TABLE_ERROR,
        errors: err
    }
}

export function getTable(pageIndex = 1, pageSize = 4, route) {
    return (dispatch) => {

        if (!route) throw new Error("Can't resolve URI");

        request(
            {
                method: REQUEST_METHOD.HTTP_GET,
                route: route + `${pageIndex}/${pageSize}`,
            }, 
            (data) => dispatch(receiveTable(data)),
            (ex) => dispatch(errorsReceive(ex))
        );

    }
}