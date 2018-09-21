import textFieldSelectFactory from 'factories/textFieldSelectFactory';
import api from 'constants/api';

const COMPONENT = 'MonthSelect';

export default textFieldSelectFactory(api.monthSelection, COMPONENT);