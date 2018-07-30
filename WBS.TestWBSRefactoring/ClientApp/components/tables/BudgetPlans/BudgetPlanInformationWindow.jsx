import DetalizationOfBudgetPlan from "../DetalizationOfBudgetPlan";
import PropTypes from "prop-types";
import React from "react";
 
const BudgetPlanInformationWindow = props => {
    const { open, formData } = props;
    return open ? <DetalizationOfBudgetPlan budgetPlanId={formData.id} /> : null;
};
 
BudgetPlanInformationWindow.propTypes = {
    open: PropTypes.bool.isRequired,
    formData: PropTypes.object
};
 
export default BudgetPlanInformationWindow;