import multiSelectFactory from 'factories/textFieldMultiSelectFactory';
import api from 'constants/api';

const COMPONENT = 'TechnicalServMultiSelect';

export default multiSelectFactory(api.technicalServsSelection, COMPONENT);