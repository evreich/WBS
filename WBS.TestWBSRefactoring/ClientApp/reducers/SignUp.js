import { addTask } from 'domain-task';
import { Constants, SignUpActions } from '../constants';
import { fetch } from '../utils';

const saveRequest = () => (dispatch) => dispatch({
    type: SignUpActions.SIGN_UP_SAVE_REQUEST
});

const succeed = (response) => (dispatch) => dispatch({
    type: SignUpActions.SIGN_UP_SAVE_SUCCEED,
    payload: response
});

const failed = (error) => (dispatch) => dispatch({
    type: SignUpActions.SIGN_UP_SAVE_FAILED,
    payload: error
});


const actionsCreators = {
    signUp: data => (dispatch, getState) => {
        saveRequest();
        
        const signupTask = fetch(Constants.SIGNUP_API_URL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        }, dispatch, getState().auth)
            .then(result => result &&
                result.json().then(response => {
                alert(response);
                response.error === SignUpActions.ERROR_CANNOT_CREATE_USER ? failed(response.error): succeed(response)            
                }))
            .catch(error => {
                alert(error);
                failed(error);
            });
        addTask(signupTask);
    },
};

export const reducer = (state, action) => {
    switch (action.type) {
        case SignUpActions.SIGN_UP_SAVE_REQUEST:
            return {
                loading: true,
                payload: {}
            };
        case SignUpActions.SIGN_UP_SAVE_SUCCEED:
            return {
                loading: false,
                payload: action.payload
            };
        case SignUpActions.SIGN_UP_SAVE_FAILED:
            return {
                loading: false,
                payload: action.payload
            };
        default:
            return state || {};
    }
};

export default actionsCreators;