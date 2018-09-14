import textFieldSelectFactory from 'factories/textFieldSelectFactory';
import api from 'constants/api';

const COMPONENT = 'CategoryGroupSelect';

export default textFieldSelectFactory(api.categoryGroupsSelection, COMPONENT);