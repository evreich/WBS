import { connect } from "react-redux";

import BudgetPlanTableRow from "components/tableRows/BudgetPlanTableRow";

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
