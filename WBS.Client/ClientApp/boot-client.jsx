import '@babel/polyfill';

import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux'
import { createBrowserHistory } from 'history';
import { ConnectedRouter } from 'react-router-redux';

import configureStore from './configureStore';
import routes from './routes';
import { Constants } from './constants';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const history = createBrowserHistory({ basename: baseUrl });

// window.initialReduxState ||
const initialState = localStorage.getItem(Constants.STORE_KEY) ? JSON.parse(localStorage.getItem(Constants.STORE_KEY)) : {};
const store = configureStore(history, initialState);
store.subscribe(() => {
    localStorage.setItem(Constants.STORE_KEY, JSON.stringify(store.getState()));
});

function renderApp(routes) {
    ReactDOM.render(
        <Provider store={store}>
            <ConnectedRouter history={history} children={routes} />
        </Provider>,
        document.getElementById('react-app')
    );
}

renderApp(routes);

if (module.hot) {
    module.hot.accept('./routes', () => {
        const newRoutes = require('./routes').default;
        renderApp(newRoutes);
    });
}

