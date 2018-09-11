import PropTypes from "prop-types";
import React from "react";

import { DetalizationOfBudgetPlan } from "../DetalizationOfBudgetPlan/DetalizationOfBudgetPlan";

const BudgetPlanInformationWindow = props => {
    const { open, formData } = props;
    return open ? <DetalizationOfBudgetPlan budgetPlanId={formData.id} /> : null;
};

BudgetPlanInformationWindow.propTypes = {
    open: PropTypes.bool.isRequired,
    formData: PropTypes.object,
};

export default BudgetPlanInformationWindow;
