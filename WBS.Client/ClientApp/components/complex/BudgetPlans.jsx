import React from "react";
import PropTypes from "prop-types";

//import SiteSelect from 'containers/textFields/selects/SiteSelect';
import BudgetPlansTable from '../../containers/tables/BudgetPlans/BudgetPlans';
import SiteComplex from './SiteSelectAndDetalization';

class BudgetPlans extends React.Component{

    render() {
        //const { siteId, budgetPlanId } = this.state;
        return <div>
            <BudgetPlansTable />
            {this.props.updatingItem && <SiteComplex budgetPlanId = {this.props.updatingItem} />} 
        </div>;
    }
}

BudgetPlans.propTypes = {
    updatingItem: PropTypes.object.isRequired
};

export default BudgetPlans;