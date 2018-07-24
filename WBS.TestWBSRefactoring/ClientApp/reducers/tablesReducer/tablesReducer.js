import TYPE from './actionsTypes.js';


const initialState = { errors: [] };

const tablesReducer = (state = initialState, action) => {
    switch(action.type){
        case TYPE.GET_TABLE_SUCCESS: {
            state[action.title] = action.data;
            return state;
        }
        case TYPE.GET_TABLE_ERROR: {
            state.errors = ['something went wrong'];
            return state;
        }
        default:
            return state;
    }
} 


export default tablesReducer;