import React from "react";

import DataFieldsInfo from "./DataFieldsInfo";
import BudgetPlansContainer from "../../../../containers/tables/BudgetPlans/BudgetPlans";
import DialogBody from "./BudgetPlanDialogBody";
import BudgetPlanTableRow from "./BudgetPlanTableRow";
import BudgetPlanInformationWindow from "./BudgetPlanInformationWindow";

const BudgetPlans = BudgetPlansContainer(
    DataFieldsInfo,
    DialogBody,
    BudgetPlanTableRow,
    BudgetPlanInformationWindow
);
const BudgetPlansComponent = () => <BudgetPlans />;
 
export default BudgetPlansComponent;