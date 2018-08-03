import request from '../../../utils/fetchUtil';
import REQUEST_METHOD from '../../../settings/httpMethods';
import { getTable, errorsReceive } from '../tablesActions';

export function markOnDeleteData(currentPage = 0, elementsPerPage = 5, data, baseRoute, markRoute, title) {
    return (dispatch) => {

        if (!markRoute || !baseRoute) throw new Error("Can't resolve URI");

        request(
            {
                method: REQUEST_METHOD.HTTP_PUT,
                route: markRoute,
                data
            }, 
            () => dispatch(getTable(currentPage, elementsPerPage, baseRoute, title)),
            (ex) => dispatch(errorsReceive(ex))
        );
    }
}