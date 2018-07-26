import request from '../../utils/fetchUtil';
import REQUEST_METHOD from '../../settings/httpMethods';

const ROUTE = document.api.categoryGroupsSelection;

export function getCategoryGroups(onSuccess, onError) {
    if (!ROUTE) throw new Error("Can't resolve URI");

    request(
        {
            method: REQUEST_METHOD.HTTP_GET,
            route: ROUTE,
        },
        (data) => onSuccess(data),
        (ex) => onError(ex)
    );
}