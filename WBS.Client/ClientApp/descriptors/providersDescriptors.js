import TypesOfColumnData from "constants/typesOfColumnData";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    title: {
        propName: "title",
        label: "Название",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true,
        fieldComponent: 'TextFieldMultiline'
    },
    profiles: {
        propName: "profiles",
        label: "Профиль",
        type: TypesOfColumnData.ARRAY,
        isVisible: true,
        canEdit: true,
        fieldComponent: 'TechnicalServMultiSelect'
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
const tableId = "Providers";

export default { 
    createWindowFields, 
    editWindowFields, 
    infoWindowModel, 
    tableHeaders, 
    titleTable,
    tableId
};
