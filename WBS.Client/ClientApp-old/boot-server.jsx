import React from 'react';
import { renderToString } from 'react-dom/server'
import { StaticRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import { replace } from 'react-router-redux';
import { createMemoryHistory } from 'history';
import { createServerRenderer } from 'aspnet-prerendering';

import routes from './routes';
import configureStore from './configureStore';

export default createServerRenderer(params => new Promise((res, rej) => {
    const basename = params.baseUrl.substring(0, params.baseUrl.length - 1);
    const urlAfterBasename = params.url.substring(basename.length);
    const store = configureStore(createMemoryHistory());

    store.dispatch(replace(urlAfterBasename));

    const routerContext = {};
    const app = (
        <Provider store={store}>
            <StaticRouter basename={basename} context={routerContext} location={params.location.path}>
                {routes}
            </StaticRouter>
        </Provider>
    );
    renderToString(app);

    if (routerContext.url) {
        res({ redirectUrl: routerContext.irl });
        return;
    }

    params.domainTasks.then(() => {
        res({
            html: renderToString(app),
            globals: { initialReduxState: store.getState() },
        });
    }, rej);
}));
