import modalWindowFactory from 'factories/ChangeItemModalWindow';
import api from 'constants/api';

const COMPONENT = 'ProfileModalWindow';

export default modalWindowFactory(api.rolesSelection, COMPONENT);