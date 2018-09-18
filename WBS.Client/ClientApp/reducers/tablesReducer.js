import TYPE from 'constants/actionTypes.js';

const initialState = { errors: [] };

export const reducer = (state = initialState, action) => {
    switch (action.type) {
        case TYPE.GET_TABLE_SUCCESS: {
            return {
                ...state,
                [action.title]: action.data
            };
        }
        case TYPE.GET_TABLE_ERROR: {
            state.errors = ['something went wrong'];
            return state;
        }
        case TYPE.CLEAR_TABLE: {
            delete state[action.title];
            return {
                ...state,
            };
        }
        case TYPE.UPDATE_TABLE: {
            let newState = { ...state };
            newState[action.title].data = action.data;
            return newState;
        }
        case TYPE.SET_UPDATING_ITEM: {
            let newState = { ...state };
            newState[action.title].updatingItem = action.updatingItem;
            return newState;
        }
        case TYPE.CLEAR_UPDATING_ITEM: {
            let newState = { ...state };
            delete newState[action.title].updatingItem;
            return newState;
        }
        case TYPE.PERMISSIONS_IS_FETCHED: {
            return {
                ...state,
                [action.title]: {
                    ...state[action.component],
                    descriptors: action.descriptors
                }
            };
        }
        default:
            return state;
    }
} 