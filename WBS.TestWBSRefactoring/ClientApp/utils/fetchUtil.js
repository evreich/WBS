import { fetch } from 'domain-task';
import { Constants, AuthorizationActions } from '../constants';

const addAuthTokenToOptions = (options, authData) => ({
    ...options,
    headers: {
        ...options.headers,
        Authorization: authData ? `Bearer ${authData.access_token}` : '',
    }
});

const fetchWithToken = (url, options, dispatch, authData) =>
    ajaxToServer(url, options, dispatch, authData)

const updateRefreshToken = (refreshToken, url, options, dispatch) =>
    fetch(Constants.TOKEN_API_URL, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ token: refreshToken })
    }).then(response => {
        if (response.ok) {
            return response.json()
                .then(auth => {
                    // пришел новый access токен, пробуем повторить запрос
                    dispatch({ type: AuthorizationActions.AUTHORIZATION, payload: auth });
                    return ajaxToServer(url, options, dispatch, auth);
                });
        } else {
            return response.json()
                .then(auth => {
                    //время действия refresh токена истекло - редирект на логин форму
                    dispatch({ type: AuthorizationActions.AUTHORIZATION, payload: {} });
                    alert(auth.error);
                    return Promise.reject();
                });
        }
    })
    .catch(response => {
        response.json().then(result => {
            result.error && alert(result.error)
            return Promise.reject();
        });
    });

const ajaxToServer = (url, options, dispatch, authData) =>
    fetch(url, addAuthTokenToOptions(options, authData))
    .then(response => {
        if (response.status === 400) {
            alert("Bad Request")
            return Promise.reject(response);
        } else if (response.status === 401) {
            // не авторизован, возможно протух access токен.
            // пробуем поторить запрос, обновив access токен c помощью refresh токена
            const refreshToken = authData && authData.refresh_token;
            if (refreshToken) {
                return updateRefreshToken(refreshToken, url, options, dispatch)
            } else {
                // refresh токена нет - редирект на логон форму
                dispatch({ type: AuthorizationActions.AUTHORIZATION, payload: {} });
                alert('Refresh токена нет')
                return Promise.reject(response);
            }
            // возможно обработка 403 не нужна, настроить доступ по полю routеs из таблицы роли 
        } else if (response.status === 403) {
            //todo: редирект на Forbidden Page
            alert('редирект на Forbidden Page here')
            return Promise.reject(response);
        } else if (response.status === 500) {
            //todo: редирект на Forbidden Page
            alert('Возникла серверная ошибка! Обратитесь в тех поддержку')
            return Promise.reject(response);
        }
        return response;
    });

export default fetchWithToken;