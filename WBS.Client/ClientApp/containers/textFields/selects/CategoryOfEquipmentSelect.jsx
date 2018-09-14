import textFieldSelectFactory from 'factories/textFieldSelectFactory';
import api from 'constants/api';

const COMPONENT = 'CategoryOfEquipmentSelect';

export default textFieldSelectFactory(api.categoriesOfEquipSelection, COMPONENT);