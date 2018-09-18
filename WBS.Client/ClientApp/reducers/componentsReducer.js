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
        case TYPE.REQUEST_IS_FETCHED: {
            let newState = { ...state };
            newState[action.component] = {
                ...newState[action.component],
                isFetching: false,
                isFetched: true,
                data: action.data
            }
            return newState;
        }
        case TYPE.CLEAR_COMPONENT_DATA: {
            const newState = { ...state };
            if (newState[action.component])
                delete newState[action.component];
            return newState;
        }
        case TYPE.DESCRIPTORS_IS_FETCHED: {
            let newState = { ...state };
            newState[action.component] = {
                ...newState[action.component],
                isFetching: false,
                isFetched: true,
                descriptors: action.descriptors
            }
            return newState;
        }
        default:
            return state;
    }
} 