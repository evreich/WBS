import {
    refreshToken
} from './refreshTokenActionCreator';

export function jwt({
    dispatch,
    getState
}) {
    return (next) => (action) => {

        // only worry about expiring token for async actions
        if (typeof action === 'function') {

            const tokenExpiration = getState().auth && getState().auth.expiresIn ? getState().auth.expiresIn : null
            if (tokenExpiration && (tokenExpiration - Date.now() < 5000)) {
                // make sure we are not already refreshing the token
                if (!getState().auth.freshTokenPromise) {
                    return refreshToken(dispatch, getState().auth.refreshToken)
                        .then(
                            () => next(action)
                        );
                } else {
                    return getState().auth.freshTokenPromise.then(() => next(action));
                }
            }

        }
        return next(action);
    };
}