import TypesOfColumnData from "../../../constants/typesOfColumnData";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    code: {
        propName: "code",
        label: "Код",
        type: TypesOfColumnData.NUMBER
    },
    title: {
        propName: "title",
        label: "Название",
        type: TypesOfColumnData.STRING
    },
    externalCode: {
        propName: "externalCode",
        label: "Внешний код",
        type: TypesOfColumnData.NUMBER
    }
};

const createWindowFields = {
    [commonFields.code.propName]: commonFields.code,
    [commonFields.title.propName]: commonFields.title,
    [commonFields.externalCode.propName]: commonFields.externalCode,
}

const editWindowFields = {
    ...createWindowFields
}

const infoWindowModel = {
    ...createWindowFields
}

const tableHeaders = {
    [commonFields.code.propName]: commonFields.code,
    [commonFields.title.propName]: commonFields.title,
    [commonFields.externalCode.propName]: commonFields.externalCode,
};

const titleTable = "Типы инвестиции";

export default { 
    createWindowFields, 
    editWindowFields, 
    infoWindowModel, 
    tableHeaders, 
    titleTable 
};
