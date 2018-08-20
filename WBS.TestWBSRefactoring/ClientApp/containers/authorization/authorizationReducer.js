import TYPE from '../../constants/authorizationActionsTypes';
import { getItem, setItem } from '../../utils/localStorageTools';
import SETTINGS from '../../settings/settings';

const initialState = getItem(SETTINGS.AUTH_KEY) || {};

export const reducer = (state = initialState, action) => {
    switch (action.type) {
        case TYPE.AUTHORIZATION:
            setItem(SETTINGS.AUTH_KEY, action.payload);
            return {
                ...action.payload,
                privateRoutes: action.privateRoutes && action.privateRoutes.split(';#'),
                freshTokenPromise: null,
            };
        case TYPE.REFRESHING_TOKEN:
            return {
                ...state,
                freshTokenPromise: action.freshTokenPromise,
            };
        case TYPE.LOGOUT:
            return {};
        default:
            return state || {};
    }
};