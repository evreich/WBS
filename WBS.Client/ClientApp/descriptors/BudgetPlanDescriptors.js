import TypesOfColumnData from "constants/typesOfColumnData";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
export const commonFields = {
    year: {
        propName: "year",
        label: "Год",
        type: TypesOfColumnData.NUMBER
    },
    status: {
        propName: "status",
        label: "Статус",
        type: TypesOfColumnData.STRING
    },
    eventLog: {
        propName: "eventLog",
        label: "Протокол событий",
        type: TypesOfColumnData.NONE
    },
    managementPlan: {
        propName: "managementPlan",
        label: "Управление планом",
        type: TypesOfColumnData.NONE
    }
};

const tableHeaders = {
    [commonFields.year.propName]: commonFields.year,
    [commonFields.status.propName]: commonFields.status,
    [commonFields.eventLog.propName]: commonFields.eventLog,
    [commonFields.managementPlan.propName]: commonFields.managementPlan
};

const titleTable = "Бюджетные планы";
const tableId = "BudgetPlans";

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
    titleTable,
    tableId
};
