import TYPE from 'constants/actionTypes';
import api from 'constants/api';
import request from 'utils/fetchUtil';
import REQUEST_METHOD from 'constants/httpMethods';

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



