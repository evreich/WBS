import { routerReducer } from 'react-router-redux';
import { reducer } from 'redux-form';

export { routerReducer as routing };
export { reducer as form };

export { reducer as auth } from './Authorization';
export { reducer as monolithic }from "./Form"