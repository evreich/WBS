import DATA_TYPE from '../settings/contentTypes.js'
import { getItem } from '../utils/localStorageTools.js';
import SETTINGS from '../settings/settings.js';

const defaultConfig = {
    contentType: DATA_TYPE.JSON_DATA
};

function ConvertDataToRequest(contentType, data){
    if(!data) return null;

    switch(contentType){
        case DATA_TYPE.JSON_DATA: 
            return JSON.stringify(data);
        case DATA_TYPE.TEXT_HTML_DATA:
            return data;
        default:
            return null;
    }
}

function ConvertDataFromResponse(contentType, response){
    switch(contentType){
        case DATA_TYPE.JSON_DATA: 
            return response.json();
        case DATA_TYPE.TEXT_HTML_DATA:
            return response.body.getReader();
        default:
            return null;
    }
}

function checkStatus(response) { 
    if (response.ok) return Promise.resolve(response);

    return response.json()
        .then(json => {
            const error = new Error(json.message || response.statusText)
            error.errors = json.errors;
            return Promise.reject(Object.assign(error, { response }))
        });
}

/*
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
*/
    
export default function request(config, onSuccess, onError) {

    if (!config.method) throw new Error("Method of request is not defined!");
    if (!config.route) throw new Error("Sorry, I can't make a request without path. May you can do that?")

    config.contentType = config.contentType || defaultConfig.contentType;

    let headers = {
        method: config.method,
        headers: {
            'content-type': config.contentType
        },
    },
    token = getItem(SETTINGS.AUTH_KEY),
    auth = null,
    data = ConvertDataToRequest(config.contentType, config.data);

    if (token)
        auth = { Authorization: `Bearer ${token.access_token}` };

    if (auth)
        headers.headers['Authorization'] = auth.Authorization;

    if (data)
        headers.body = data;

    fetch(config.route, headers)
        .then((response) => checkStatus(response))
        .then((response) => ConvertDataFromResponse(config.contentType, response))
        .then((data) => {
            onSuccess && onSuccess(data);
        }).catch((error) => {
            onError && onError(error);
        });
}
