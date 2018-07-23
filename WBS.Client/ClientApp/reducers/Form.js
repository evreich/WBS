import { FormActions } from '../constants'
import { combineReducers } from 'redux';

const errors = (state = {}, action) => {
    switch (action.type) {
        case FormActions.SET_SERVER_ERROR:
            return action.error
        case FormActions.CLEAR_SERVER_ERROR:
            return {};
        default:
            return state;
    }
}

export const reducer = combineReducers({
    errors
})


const setError = (error) => (dispatch) => dispatch({ type: FormActions.SET_SERVER_ERROR, error: error })
const clearError = () => (dispatch) => dispatch({ type: FormActions.SET_SERVER_ERROR, error: {} })

const actionsCreators = {
    setError,
    clearError
}
export default actionsCreators