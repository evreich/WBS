import { TypesOfColumnData } from "../../constants";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
export const fieldNames = {
    year: {
        id: "year",
        label: "Год"
    },
    status: {
        id: "status",
        label: "Статус"
    },
    eventLog: {
        id: "eventLog",
        label: "Протокол событий"
    },
    managementPlan: {
        id: "managementPlan",
        label: "Управление планом"
    }
};

const tableHeaders = {
    [fieldNames.year.id]: {
        ...fieldNames.year,
        type: TypesOfColumnData.NUMBER
    },
    [fieldNames.status.id]: {
        ...fieldNames.status,
        type: TypesOfColumnData.STRING
    },
    [fieldNames.eventLog.id]: {
        ...fieldNames.eventLog,
        type: TypesOfColumnData.NONE
    },
    [fieldNames.managementPlan.id]: {
        ...fieldNames.managementPlan,
        type: TypesOfColumnData.NONE
    }
};

const titleTable = "Бюджетные планы";

export default { fieldNames, tableHeaders, titleTable };
