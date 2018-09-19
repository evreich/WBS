import modalWindowFactory from 'factories/ChangeItemModalWindow';
import api from 'constants/api';
import objectTypes from 'constants/objectTypes';

const COMPONENT = 'ResultCentreModalWindow';

export default modalWindowFactory(api.categoryGroups, COMPONENT, objectTypes.resultCenter);