import DATA_TYPE from 'constants/contentTypes';
import { getItem } from 'utils/localStorageTools';
import SETTINGS from 'constants/settings';
import REQUEST_METHOD from "constants/httpMethods";

const defaultConfig = {
    contentType: DATA_TYPE.JSON_DATA
};

function ConvertDataToRequest(contentType, data) {
    if (!data) return null;

    switch (contentType) {
        case DATA_TYPE.JSON_DATA:
            return JSON.stringify(data);
        case DATA_TYPE.TEXT_HTML_DATA:
            return data;
        default:
            return null;
    }
}

function ConvertDataFromResponse(contentType, response) {
    switch (contentType) {
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
        auth = { Authorization: `Bearer ${token.accessToken}` };

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

export const GET = (currRoute, onSuccess, onError, params) => {
    if (!currRoute) throw new Error("Can't resolve URI");

    const queryPath = concatParamsToPath(params);
    const allPath = queryPath ? `${currRoute}${queryPath}` : currRoute;
    request(
        {
            method: REQUEST_METHOD.HTTP_GET,
            route: allPath
        },
        data => onSuccess(data),
        ex => onError(ex)
    );
};

export const concatParamsToPath = queryParams =>
    queryParams &&
    '?' + Object.keys(queryParams).map(key => `${key}=${queryParams[key]}`).join('&');
