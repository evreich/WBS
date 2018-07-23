import { addTask } from 'domain-task';
import { AuthorizationActions, Constants } from '../constants';
import { fetch } from '../utils';
import formActions from './form'

const actionsCreators = {
    authorization: (loginPassword) => (dispatch) => {
        let fetchTask = fetch(Constants.LOGIN_API_URL, {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' },
                    body: JSON.stringify(loginPassword),
                },
                dispatch)
            .then(response => {
                if (response.ok) {
                    response.json()
                        .then(result => {
                            if (result.access_token) {
                                dispatch({ type: AuthorizationActions.AUTHORIZATION, payload: result });
                            }
                        })
                } else
                    response.json()
                    .then(result => {
                        alert(response.error)
                        dispatch({ type: AuthorizationActions.AUTHORIZATION, payload: {} });
                        formActions.setError(result)
                    })
            })
            .catch(response => {
                response.json().then(result => {
                    formActions.setError(result)
                });
            })
        addTask(fetchTask) //чтобы асинхронные запросы работали с серверрендерингом, все запросы оборачиваются в addTask
    },
    logout: () => ({ type: AuthorizationActions.LOGOUT }),
}

export const reducer = (state, action) => {
    switch (action.type) {
        case AuthorizationActions.AUTHORIZATION:
            return {
                ...action.payload,
                privateRoutes: action.privateRoutes && action.privateRoutes.split(';#'),
            };
        case AuthorizationActions.LOGOUT:
            return {};
        default:
            return state || {};
    }
};

export default actionsCreators;