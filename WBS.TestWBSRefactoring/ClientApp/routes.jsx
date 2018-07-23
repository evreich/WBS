import React from 'react';
import { Route } from 'react-router-dom';

import Layout from './components/Commons/Layout';
import AuthorizationForm from './components/AuthorizationForm/AuthorizationForm'
import Home from './components/Home';

const routes = ( 
    <Layout>
        <Route exact path="/" component={AuthorizationForm} />
        <Route path="/Home" component={Home} />
    </Layout>
);

export default routes;
