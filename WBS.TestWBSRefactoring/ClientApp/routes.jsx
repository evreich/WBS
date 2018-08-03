import React from 'react';
import { Route } from 'react-router-dom';

import Layout from './components/Commons/Layout';
import AuthorizationForm from './containers/authorization/authorizationContainer';
import Home from './components/Home';
import CategoriesOfEquipment from './components/tables/CategoriesOfEquipment';
import CategoryGroups from './components/tables/CategoryGroups'
import BudgetPlans from './components/tables/BudgetPlans';
import TypeOfInvestments from './components/tables/TypesOfInvestment';
import ResultCentres from './components/tables/ResultCentres';
import Providers from './components/tables/Providers';
import Sits from './components/tables/Sits';
import Formats from './components/tables/Format';
import Profiles from './components/tables/Profiles';

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
        <Route path="/Home" component={Home} />
    </Layout>
);

export default routes;
