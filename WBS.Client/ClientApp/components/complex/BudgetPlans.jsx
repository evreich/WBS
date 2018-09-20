import React from "react";

import SiteSelect from 'containers/textFields/selects/SiteSelect';

class BudgetPlans extends React.Component{
    constructor(props) {
        super(props);
        this.state = {
            budgetPlanId: 0,
            siteId: 0
        }
    }

    onSiteChanged = e => {
        this.setState({
            siteId : e.target.value
        });
    }

    render() {
        const { siteId, budgetPlanId } = this.state;
        return <>
            <h1>Budget plans table</h1>
            <SiteSelect value={siteId} label="Выберите сит" selectionChanged={this.onSiteChanged} />
            { !!siteId && !!budgetPlanId && <h1>Budget plan detalization</h1> } 
        </>;
    }
}

export default BudgetPlans;