import React from 'react';
import { Route } from 'react-router-dom';

import Layout from './components/Commons/Layout';
import AuthorizationForm from 'containers/authorization/authorizationContainer';
import Home from './components/Home';
import CategoriesOfEquipment from 'containers/tables/CategoriesOfEquipment';
import CategoryGroups from 'containers/tables/CategoryGroups'
import BudgetPlans from 'containers/tables/BudgetPlans';
import TypeOfInvestments from 'containers/tables/TypesOfInvestment';
import ResultCentres from 'containers/tables/ResultCentres';
import Providers from 'containers/tables/Providers';
import Sits from 'containers/tables/Sits';
import Formats from 'containers/tables/Format';
import Profiles from 'containers/tables/Profiles';
import DAIRequests from 'containers/tables/DAIRequests'

const routes = ( 
    <Layout>
        <Route exact path="/" component={AuthorizationForm} />
        <Route path="/CategoriesOfEquipment" component={CategoriesOfEquipment} /> 
        <Route path="/BudgetPlans" component={BudgetPlans} />
        <Route path="/CategoryGroups" component={CategoryGroups} />
        <Route path="/TypeOfInvestments" component={TypeOfInvestments} />
        <Route path="/ResultCentres" component={ResultCentres} />
        <Route path="/Providers" component={Providers} />
        <Route path="/Sits" component={Sits} />
        <Route path="/Formats" component={Formats} />
        <Route path="/Profiles" component={Profiles} />
        <Route path="/DAIRequests" component={DAIRequests} />
        <Route path="/Home" component={Home} />
    </Layout>
);

export default routes;
