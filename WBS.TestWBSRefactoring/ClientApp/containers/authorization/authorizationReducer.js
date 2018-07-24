import TYPE from './authorizationActionsTypes';
import { getItem, setItem } from '../../utils/localStorageTools';
import SETTINGS from '../../settings/settings';

const initialState = getItem(SETTINGS.AUTH_KEY) || {};

export const reducer = (state = initialState, action) => {
    console.log(action);
    switch (action.type) {
        case TYPE.GET_AUTH_TOKEN_SUCCESS:
            setItem(SETTINGS.AUTH_KEY, action.payload);
            return {
                ...action.payload,
            };
        case TYPE.GET_AUTH_TOKEN_ERROR:
            return {
                ...action,
            };
        case TYPE.CLEAR_AUTH_TOKEN:
            setItem(SETTINGS.AUTH_KEY, {});
            return {};
        default:
            return state;
    }
};