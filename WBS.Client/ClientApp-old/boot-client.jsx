import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux'
import { createBrowserHistory } from 'history';
import { ConnectedRouter } from 'react-router-redux';

import configureStore from './configureStore';
import routes from './routes';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const history = createBrowserHistory({ basename: baseUrl });

const store = configureStore(history);

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

