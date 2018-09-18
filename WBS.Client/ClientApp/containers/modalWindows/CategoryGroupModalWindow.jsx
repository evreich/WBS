import modalWindowFactory from 'factories/ChangeItemModalWindow';
import api from 'constants/api';

const COMPONENT = 'CategoryGroupModalWindow';
const OBJECT_TYPE = 'CategoryGroup';

export default modalWindowFactory(api.categoryGroups, COMPONENT, OBJECT_TYPE);