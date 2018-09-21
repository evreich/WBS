import { connect } from "react-redux";

import BudgetPlans from "components/complex/BudgetPlans";

const TABLE = "budgetPlans";

const mapStateToProps = state =>
    (state.tables[TABLE] ?
        {
            updatingItem: state.tables[TABLE].updatingItem
            //TODO: send server error in form from redux store
            //errors: state.tables[TABLE].errors
        } : {});

const BudgetPlansComplexContainer = connect(
    mapStateToProps
)(BudgetPlans);

export default BudgetPlansComplexContainer;
