﻿import modalWindowFactory from 'factories/ChangeItemModalWindow';
import api from 'constants/api';
import objectTypes from 'constants/objectTypes';

const COMPONENT = 'CategoryOfEquipmentModalWindow';

export default modalWindowFactory(api.categoriesOfEquipment, COMPONENT, objectTypes.categoryOfEquipment);