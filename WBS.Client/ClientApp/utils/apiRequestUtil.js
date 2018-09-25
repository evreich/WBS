import request from "../utils/fetchUtil";
import REQUEST_METHOD from "constants/httpMethods";

export const rootRequest = (currRoute, onSuccess, onError, params) => {
    if (!currRoute) throw new Error("Can't resolve URI");

    const queryPath = concatParamsToPath(params);
    const allPath = queryPath ? currRoute + queryPath : currRoute;
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
    Object.keys(queryParams).reduce(
        (path, currKey) => {
            let currParam = typeof queryParams[currKey] === 'object' ? JSON.stringify(queryParams[currKey]) : queryParams[currKey];
            return path.concat(currKey, "=", currParam, ";")
        },
        "?"
    );
