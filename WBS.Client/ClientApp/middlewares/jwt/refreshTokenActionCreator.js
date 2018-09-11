import TYPE from 'constants/actionTypes';
import { updateJWT } from 'utils/updateJWT';

//TODO: переместить в другое место
export function refreshToken(dispatch, refreshToken) {

    const freshTokenPromise = updateJWT(refreshToken)
        .then(auth => {
            //TODO: перенести в отдельную функцию
            dispatch({ type: TYPE.AUTHORIZATION, payload: auth });
            return auth.accessToken ? Promise.resolve(auth.accessToken) : Promise.reject({
                message: 'could not refresh token'
            });
        })
        .catch(error => {
            console.log('error refreshing token', error);
            //время действия refresh токена истекло - редирект на логин форму
            dispatch({ type: TYPE.LOGOUT });
            return Promise.reject(error);
        });

    dispatch({
        type: TYPE.REFRESHING_TOKEN,
        // we want to keep track of token promise in the state so that we don't try to refresh
        // the token again while refreshing is in process
        freshTokenPromise
    });

    return freshTokenPromise;
}