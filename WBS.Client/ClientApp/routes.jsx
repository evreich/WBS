import React from 'react';
import { Route } from 'react-router-dom';
import Layout from './components/Commons/Layout';
import Vendors from './components/Vendors/Vendors';
import Format from './components/Format/Format';
import Profiles from './components/Profiles/Profiles';
import Sits from './components/Sits/Sits';
import DateRangePicker from './components/DAIRequests';
import AuthorizationForm from './components/AuthorizationForm/AuthorizationForm'
import TypesOfInvestment from './components/TypesOfInvestment/TypesOfInvestment';
import ResultCentres from './components/ResultCentres/ResultCentres';
import CategoryGroups from './components/CategoryGroups/CategoryGroups';
import CategoriesOfEquipment from './components/CategoriesOfEquipment';
import DAIRequests from './components/DAIRequestsClient';
import BudgetPlans from './components/BudgetPlans'
import Home from './components/Home';

const routes = ( 
    <Layout>
        <Route exact path="/" component={AuthorizationForm} />
        <Route path="/Vendors" component={Vendors} />
        <Route path="/Formats" component={Format} />
        <Route path="/DateRangePicker" component={DateRangePicker} />
        <Route path="/Profiles" component={Profiles} /> 
        <Route path="/Sits" component={Sits} /> 
        <Route path="/Investment" component={TypesOfInvestment} /> 
        <Route path="/ResultCentres" component={ResultCentres} /> 
        <Route path="/CategoryGroups" component={CategoryGroups} /> 
        <Route path="/CategoriesOfEquipment" component={CategoriesOfEquipment} /> 
        <Route path="/DAIRequests" component={DAIRequests} /> 
        <Route path="/BudgetPlans" component={BudgetPlans} />
        <Route path="/Home" component={Home} />
    </Layout>
);

export default routes;
