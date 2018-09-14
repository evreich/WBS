import textFieldSelectFactory from 'factories/textFieldSelectFactory';
import api from 'constants/api';

const COMPONENT = 'TypeOfInvestmentSelect';

export default textFieldSelectFactory(api.typesOfInvestmentSelection, COMPONENT);