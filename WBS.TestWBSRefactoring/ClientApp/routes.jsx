import React from 'react';
import { Route } from 'react-router-dom';

import Layout from './components/Commons/Layout';
import AuthorizationForm from './containers/authorization/authorizationContainer';
import Home from './components/Home';
import CategoriesOfEquipment from './components/tables/CategoriesOfEquipment';
import BudgetPlans from './components/tables/BudgetPlans';
const routes = ( 
    <Layout>
        <Route exact path="/" component={AuthorizationForm} />
        <Route path="/CategoriesOfEquipment" component={CategoriesOfEquipment} /> 
        <Route path="/BudgetPlans" component={BudgetPlans} />
        <Route path="/Home" component={Home} />
    </Layout>
);

export default routes;
