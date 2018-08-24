import TypesOfColumnData from "constants/typesOfColumnData";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    title: {
        propName: "title",
        label: "Название",
        type: TypesOfColumnData.STRING
    },
    profiles: {
        propName: "profiles",
        label: "Профиль",
        type: TypesOfColumnData.ARRAY 
    }
};

const createWindowFields = {
    [commonFields.title.propName]: commonFields.title,
    [commonFields.profiles.propName]: commonFields.profiles,
}

const editWindowFields = {
    ...createWindowFields
}

const infoWindowModel = {
    ...createWindowFields
}

const tableHeaders = {
    [commonFields.title.propName]: commonFields.title,
    [commonFields.profiles.propName]: commonFields.profiles,
};

const titleTable = "Поставщики";

export default { 
    createWindowFields, 
    editWindowFields, 
    infoWindowModel, 
    tableHeaders, 
    titleTable
};
