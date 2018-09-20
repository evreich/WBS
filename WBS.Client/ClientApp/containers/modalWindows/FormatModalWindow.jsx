import modalWindowFactory from 'factories/ChangeItemModalWindow';
import api from 'constants/api';
import objectTypes from 'constants/objectTypes';

const COMPONENT = 'FormatModalWindow';

export default modalWindowFactory(api.formats, COMPONENT, objectTypes.format);