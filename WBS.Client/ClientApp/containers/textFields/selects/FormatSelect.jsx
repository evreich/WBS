import textFieldSelectFactory from 'factories/textFieldSelectFactory';
import api from 'constants/api';

const COMPONENT = 'FormatSelect';

export default textFieldSelectFactory(api.formatsSelection, COMPONENT);