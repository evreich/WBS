import DetalizationOfBudgetPlan from "../../containers/DetalizationOfBudgetPlan/DetalizationOfBudgetPlan";
import PropTypes from "prop-types";
import React from "react";

const BudgetPlanInformationWindow = props => {
    const { open, formData } = props;
    const DetalizationOfBP = open ? DetalizationOfBudgetPlan : null;

    return <DetalizationOfBP budgetPlan={formData} />;
};

BudgetPlanInformationWindow.propTypes = {
    open: PropTypes.bool.isRequired,
    formData: PropTypes.object.isRequired
};
