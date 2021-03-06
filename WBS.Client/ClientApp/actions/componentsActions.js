﻿import TYPE from 'constants/actionTypes';
import { GET } from 'utils/fetchUtil';
import api from 'constants/api';

export function getItemsForSelection(route, component, params) {
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

export function clearComponentData(component) {
    return {
        type: TYPE.CLEAR_COMPONENT_DATA,
        component
    }
}

export function getDataForModalForm(route, component, id) {
    //const params = { id };
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

        GET(`${route}${id}`, onSuccess, onError/*, params*/);
        
    }
}

export function getDescriptorsForModalForm(component, objectType, id) {
    const params = { objectType };
    if (id)
        params.id = id;

    return (dispatch) => {
        dispatch({
            type: TYPE.REQUEST_IS_FETCHING,
            component
        })

        const onSuccess = (descriptors) =>
            dispatch({
                type: TYPE.DESCRIPTORS_IS_FETCHED,
                component,
                descriptors
            });

        const onError = (/*error*/) => {
            //TODO:
        }

        GET(api.descriptors, onSuccess, onError, params);
    }
}

