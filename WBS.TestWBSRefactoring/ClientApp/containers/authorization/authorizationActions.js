import TYPE from './authorizationActionsTypes';
import request from '../../utils/fetchUtil';
import REQUEST_METHOD from '../../settings/httpMethods.js';

const api = document.api;

export function receiveToken(data) {
    return {
        type: TYPE.GET_AUTH_TOKEN_SUCCESS,
        payload: data
    }
}

export function logout(){
    return {
        type: TYPE.CLEAR_AUTH_TOKEN,
    }
}

export function errorsReceive(err) {
    return {
        type: TYPE.GET_AUTH_TOKEN_ERROR,
        errors: err
    }
}

export function getToken(data) {
    return (dispatch) => {

        if (!api.auth) throw new Error("Can't resolve URI");

        request(
            {
                method: REQUEST_METHOD.HTTP_POST,
                route: api.auth,
                data: data
            }, 
            (data) => dispatch(receiveToken(data)),
            (ex) => dispatch(errorsReceive(ex))
        );

    }
}
