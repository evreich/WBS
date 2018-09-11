import TYPE from '../../constants/authorizationActionsTypes';
import request from '../../utils/fetchUtil';
import REQUEST_METHOD from '../../settings/httpMethods.js';

const api = document.api;

export const authorization = (login, password) => (dispatch) => {
    request(
        {
            method: REQUEST_METHOD.HTTP_POST,
            route: api.auth,
            data: {
                login: login,
                password: password
            }
        },
        response => {
            dispatch({
                type: TYPE.AUTHORIZATION,
                payload: response
            })
        },
        response => {
            response.json().then(result => {
                console.log(result);
            });
        })
}

export function logout() {
    return {
        type: TYPE.LOGOUT
    }
}



