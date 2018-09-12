import textFieldSelectFactory from 'factories/textFieldSelectFactory';
import api from 'constants/api';

const COMPONENT = 'SiteSelect';

export default textFieldSelectFactory(api.sitsSelection, COMPONENT);