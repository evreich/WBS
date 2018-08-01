import { TypesOfColumnData } from "../../../constants";
 
//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
export const commonFields = {
    year: {
        propName: "year",
        label: "Год"
    },
    status: {
        propName: "status",
        label: "Статус"
    },
    eventLog: {
        propName: "eventLog",
        label: "Протокол событий"
    },
    managementPlan: {
        propName: "managementPlan",
        label: "Управление планом"
    }
};
 
const tableHeaders = {
    [commonFields.year.propName]: {
        ...commonFields.year,
        type: TypesOfColumnData.NUMBER
    },
    [commonFields.status.propName]: {
        ...commonFields.status,
        type: TypesOfColumnData.STRING
    },
    [commonFields.eventLog.propName]: {
        ...commonFields.eventLog,
        type: TypesOfColumnData.NONE
    },
    [commonFields.managementPlan.propName]: {
        ...commonFields.managementPlan,
        type: TypesOfColumnData.NONE
    }
};
 
const titleTable = "Бюджетные планы";
 
const createWindowFields = {
    [commonFields.year.propName]: commonFields.year,
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
