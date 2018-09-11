import request from "../utils/fetchUtil";
import REQUEST_METHOD from "../settings/httpMethods";

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
    Object.values(queryParams).reduce(
        (path, currParam) => (path = path.concat(currParam, "/")),
        ""
    );
