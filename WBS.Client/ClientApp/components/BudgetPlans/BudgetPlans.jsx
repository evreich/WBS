import React from "react";
import DataFieldsInfo from "./DataFieldsInfo";
import BudgetPlansContainer from "../../containers/BudgetPlans";
import DialogBody from "./BudgetPlanDialogBody";
import CustomTableRow from "./BudgetPlanSimpleRow";
import BudgetPlanInformationWindow from "./BudgetPlanInformationWindow";

const BudgetPlans = () => {
    const BudgetPlans = BudgetPlansContainer(
        DataFieldsInfo,
        DialogBody,
        CustomTableRow,
        BudgetPlanInformationWindow
    );

    return <BudgetPlans />;
};

export default BudgetPlans;
