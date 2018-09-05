import TYPE from './tablesActionTypes.js';

const initialState = { errors: [] };

export const reducer = (state = initialState, action) => {
    switch(action.type){
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
        default:
            return state;
    }
} 