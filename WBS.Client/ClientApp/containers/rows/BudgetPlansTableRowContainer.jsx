import { connect } from "react-redux";

import BudgetPlanTableRow from "../tables/BudgetPlans/BudgetPlanTableRow";

import {setUpdatingItem} from 'actions/tablesActions';

const TABLE = "budgetPlans";

const mapDispatchToProps = (dispatch) => ({
    setUpdatingItem: (updatingItemId) => dispatch(setUpdatingItem(updatingItemId, TABLE))
});

const BudgetPlansTableRowContainer = connect(
    null,
    mapDispatchToProps
)(BudgetPlanTableRow);

export default BudgetPlansTableRowContainer;
