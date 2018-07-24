import React from 'react';
import { Route } from 'react-router-dom';

import Layout from './components/Commons/Layout';
import AuthorizationForm from './containers/authorization/authorizationContainer';
import Home from './components/Home';
import CategoriesOfEquipment from './components/CategoriesOfEquipment';

const routes = ( 
    <Layout>
        <Route exact path="/" component={AuthorizationForm} />
        <Route path="/CategoriesOfEquipment" component={CategoriesOfEquipment} /> 
        <Route path="/Home" component={Home} />
    </Layout>
);

export default routes;
