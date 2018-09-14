import multiSelectFactory from 'factories/textFieldMultiSelectFactory';
import api from 'constants/api';

const COMPONENT = 'RoleMultiSelect';

export default multiSelectFactory(api.rolesSelection, COMPONENT);