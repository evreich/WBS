import {
    fetch
} from 'domain-task';

import api from 'constants/api';

//TODO: optimize
export const updateJWT = (refreshToken) =>
    fetch(`${api.token}?refreshToken=${refreshToken}`, {
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