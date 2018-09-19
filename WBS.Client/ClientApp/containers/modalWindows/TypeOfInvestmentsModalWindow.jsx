import modalWindowFactory from 'factories/ChangeItemModalWindow';
import api from 'constants/api';
import objectTypes from 'constants/objectTypes';

const COMPONENT = 'TypeOfInvestmentsModalWindow';

export default modalWindowFactory(api.categoryGroups, COMPONENT, objectTypes.typeOfInvestment);