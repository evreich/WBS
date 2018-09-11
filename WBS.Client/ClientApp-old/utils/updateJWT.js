import {
    fetch
} from 'domain-task';

const ROUTE = document.api;

//TODO: optimize
export const updateJWT = (refreshToken) =>
    fetch(`${ROUTE.token}?refreshToken=${refreshToken}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(response => {
        if (response.ok) {
            return response.json()
        } else {
            return response.json()
                .then(auth => Promise.reject(auth))
        }
    })
        .catch(() => Promise.reject());