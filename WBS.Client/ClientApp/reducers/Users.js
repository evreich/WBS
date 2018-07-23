import { Constants, UsersActions } from '../constants';
import { fetch } from '../utils';



const actionsCreators = {
    getUsers: () => (dispatch, getState) => {
        fetch(Constants.GET_USERS_API_URL, {
                method: 'GET'
            }, dispatch, getState().auth)
            .then(response =>

                response.json()
                .then(result => {
                    dispatch({
                        type: UsersActions.FETCH_USERS,
                        users: result
                    });
                })
            )

        .catch(error => {
            alert(error);
        });

    },
};

export const reducer = (state = [], action) => {
    switch (action.type) {
        case UsersActions.FETCH_USERS:
            return action.users
        default:
            return state;
    }
};





export default actionsCreators;