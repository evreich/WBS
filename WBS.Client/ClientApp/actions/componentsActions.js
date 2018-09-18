import TYPE from 'constants/actionTypes';
import { GET } from 'utils/fetchUtil';

export function getItemsForSelection(route, component, params) {
    return (dispatch) => {
        dispatch({
            type: TYPE.COMPONENT_DATA_IS_FETCHING,
            component
        })

        const onSuccess = (data) =>
            dispatch({
                type: TYPE.COMPONENT_DATA_IS_FETCHED,
                component,
                data
            });

        const onError = (/*error*/) => {
            //TODO:
        }

        GET(route, onSuccess, onError, params);
    }
}

export function clearItemsForSelection(component) {
    return {
        type: TYPE.CLEAR_COMPONENT_DATA,
        component
    }
}