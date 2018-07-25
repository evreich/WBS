import TYPE from './actionsTypes.js';


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
        default:
            return state;
    }
} 