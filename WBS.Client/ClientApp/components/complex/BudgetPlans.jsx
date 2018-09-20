import React from "react";

class BudgetPlans extends React.Component{
    constructor(props) {
        super(props);
        this.state = {
            budgetPlanId: null,
            siteId: null
        }
    }

    render(){
        return <>
            <h1>Budget plans table</h1>
            <h1>Site chooser</h1>
            <h1>Budget plan detalization</h1>
            </>;
    }
}

export default BudgetPlans;