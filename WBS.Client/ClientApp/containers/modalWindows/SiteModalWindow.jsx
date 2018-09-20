import modalWindowFactory from 'factories/ChangeItemModalWindow';
import api from 'constants/api';
import objectTypes from 'constants/objectTypes';

const COMPONENT = 'SiteModalWindow';

export default modalWindowFactory(api.sits, COMPONENT, objectTypes.site);