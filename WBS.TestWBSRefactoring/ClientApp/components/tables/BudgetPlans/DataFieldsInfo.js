import { TypesOfColumnData } from "../../../constants";
 
//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
export const commonFields = {
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
    [commonFields.year.id]: {
        ...commonFields.year,
        type: TypesOfColumnData.NUMBER
    },
    [commonFields.status.id]: {
        ...commonFields.status,
        type: TypesOfColumnData.STRING
    },
    [commonFields.eventLog.id]: {
        ...commonFields.eventLog,
        type: TypesOfColumnData.NONE
    },
    [commonFields.managementPlan.id]: {
        ...commonFields.managementPlan,
        type: TypesOfColumnData.NONE
    }
};
 
const titleTable = "Бюджетные планы";
 
const createWindowFields = {
    [commonFields.year.id]: commonFields.year,
}

const editWindowFields = {
    ...createWindowFields
}

const infoWindowModel = {
}

export default { 
    createWindowFields, 
    editWindowFields, 
    infoWindowModel, 
    tableHeaders, 
    titleTable 
};
