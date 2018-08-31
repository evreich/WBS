import moment from "moment"

import TypesOfColumnData from "../constants/typesOfColumnData";
import DATE_FORMAT from "../constants/dateFormat";

const transformFieldsToState = fields =>
    fields.reduce(
        (fieldsInitObj, currField) => ({
            ...fieldsInitObj,
            [currField.propName]: setInitValueForType(currField.type)
        }),
        {}
    );

const setInitValueForType = type => {
    switch (type) {
        case TypesOfColumnData.NUMBER:
            return 0;
        case TypesOfColumnData.STRING:
        case TypesOfColumnData.NONE:
            return '';
        case TypesOfColumnData.DATE:
            return moment().format(DATE_FORMAT);
        case TypesOfColumnData.ARRAY:
            return [];
        case TypesOfColumnData.BOOLEAN:
            return false;
        default:
            break;
    }
};

export default transformFieldsToState;
