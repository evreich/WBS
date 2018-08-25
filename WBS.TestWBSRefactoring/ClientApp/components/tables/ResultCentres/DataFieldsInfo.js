import TypesOfColumnData from "constants/typesOfColumnData";

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
};

const createWindowFields = {
    [commonFields.code.propName]: commonFields.code,
    [commonFields.title.propName]: commonFields.title,
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
};

const titleTable = "Центры результатов";

export default { 
    createWindowFields, 
    editWindowFields, 
    infoWindowModel, 
    tableHeaders, 
    titleTable
};
