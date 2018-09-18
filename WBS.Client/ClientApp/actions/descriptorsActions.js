import TYPE from 'constants/actionTypes';
import { GET } from 'utils/fetchUtil';

export function getDescriptors(route, component, params) {
    return (dispatch) => {
        dispatch({
            type: TYPE.REQUEST_IS_FETCHING,
            component
        })

        const onSuccess = (data) =>
            dispatch({
                type: TYPE.REQUEST_IS_FETCHED,
                component,
                data
            });

        const onError = (/*error*/) => {
            //TODO:
        }

        GET(route, onSuccess, onError, params);
    }
}