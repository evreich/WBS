import TYPE from 'constants/actionTypes.js';

const initialState = {};

export const reducer = (state = initialState, action) => {
    const { type } = action;
    switch (type) {
        case TYPE.REQUEST_IS_FETCHING:
            return {
                ...state,
                [action.component]: {
                    isFetching: true,
                    isFetched: false
                }
            }
        case TYPE.REQUEST_IS_FETCHED:
            return {
                ...state,
                [action.component]: {
                    isFetching: false,
                    isFetched: true,
                    data: action.data
                }
            }
        case TYPE.CLEAR_COMPONENT_DATA: {
            const newState = { ...state };
            if (newState[action.component])
                delete newState[action.component];
            return newState;
        }
        case TYPE.DESCRIPTORS_IS_FETCHED: {
            return {
                ...state,
                [action.component]: {
                    isFetching: false,
                    isFetched: true,
                    descriptors: action.data
                }
            }
        }
        default:
            return state;
    }
} 