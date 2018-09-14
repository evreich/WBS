import textFieldSelectFactory from 'factories/textFieldSelectFactory';
import api from 'constants/api';

const COMPONENT = 'ResultCenterSelect';

export default textFieldSelectFactory(api.resultCentresSelection, COMPONENT);