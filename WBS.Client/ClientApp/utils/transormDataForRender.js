import moment from 'moment';

import TypesOfColumnData from "constants/typesOfColumnData";
import DATE_FORMAT from "constants/dateFormat";

export default (data, type) => {
    switch (type) {
        case TypesOfColumnData.ARRAY:
            return data.map(item => item.title).join(", ");
        case TypesOfColumnData.DATE:
            return moment(data).format(DATE_FORMAT);
        default:
            return data;
    }
}