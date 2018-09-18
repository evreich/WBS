import modalWindowFactory from 'factories/ChangeItemModalWindow';
import api from 'constants/api';

const COMPONENT = 'ProfileModalWindow';
const OBJECT_TYPE = 'WBS.DAL.Authorization.Models.User';

export default modalWindowFactory(api.rolesSelection, COMPONENT, OBJECT_TYPE);