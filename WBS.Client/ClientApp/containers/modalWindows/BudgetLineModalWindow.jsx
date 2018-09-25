import modalWindowFactory from 'factories/ChangeItemModalWindow';
import api from 'constants/api';
import objectTypes from 'constants/objectTypes';

const COMPONENT = 'BudgetLineModalWindow';

export default modalWindowFactory(api.budgetLine, COMPONENT, objectTypes.budgetLine);