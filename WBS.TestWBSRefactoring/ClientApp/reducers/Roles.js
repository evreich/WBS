import { addTask } from 'domain-task';
import { Constants, RolesActions} from '../constants';
import { fetch } from '../utils';



const actionsCreatorsRoles = {
    getRoles: () => (dispatch, getState) => {
        const rolesTask = fetch(Constants.GET_ROLES_API_URL, {
            method: 'GET'        
        }, dispatch, getState().auth)
            .then(response =>

                response.json()
                    .then(result => {
                        dispatch({
                            type: RolesActions.FETCH_ROLES,
                            roles: result
                        });
                    })
            )
        
            .catch(error => {
                alert(error);               
            });
        addTask(rolesTask);
    },
};

export const reducer = (state=[], action) => {
    switch (action.type) {
        case RolesActions.FETCH_ROLES:
            return action.roles
        default:
            return state;
    }
};

export default actionsCreatorsRoles;