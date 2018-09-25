import modalWindowFactory from 'factories/ChangeItemModalWindow';
import api from 'constants/api';
import objectTypes from 'constants/objectTypes';

const COMPONENT = 'BudgetPlanModalWindow';

export default modalWindowFactory(api.budgetPlan, COMPONENT, objectTypes.budgetPlan);