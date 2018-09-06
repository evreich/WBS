import {
    createStore,
    applyMiddleware,
    compose,
    combineReducers
} from 'redux';
import thunk from 'redux-thunk';
import { routerMiddleware } from 'react-router-redux';

import * as reducers from './reducers';
//import { jwt } from './middlewares/jwt/jwt';


export default (history) => {
    const devTool = typeof window === 'object' && window.__REDUX_DEVTOOLS_EXTENSION__ ?
        window.__REDUX_DEVTOOLS_EXTENSION__ : compose;

    const createStoreWithMiddleware = compose(
        applyMiddleware(/*jwt, */thunk, routerMiddleware(history)),
        devTool ? devTool() : next => next
    )(createStore);

    const rootReducer = combineReducers(reducers);
    const store = createStoreWithMiddleware(rootReducer);

    if (module.hot) {
        module.hot.accept('./reducers', () => {
            const nextReducers = require('./reducers');
            store.replaceReducer(combineReducers(nextReducers));
        })
    }

    return store;
};