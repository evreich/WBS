import TypesOfColumnData from "../../../constants/typesOfColumnData";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    categoryGroupId: {
        propName: "categoryGroupId",
        label: "Группа категории",
        type: TypesOfColumnData.NUMBER
    },
    categoryGroupTitle: {
        propName: "categoryGroupTitle",
        label: "Группа категории",
        type: TypesOfColumnData.STRING
    },
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
    depreciationPeriod: {
        propName: "depreciationPeriod",
        label: "Амортизация, лет.",
        type: TypesOfColumnData.NUMBER
    }
};

const createWindowFields = {
    [commonFields.categoryGroupId.propName]: commonFields.categoryGroupId,
    [commonFields.code.propName]: commonFields.code,
    [commonFields.title.propName]: commonFields.title,
    [commonFields.depreciationPeriod.propName]: commonFields.depreciationPeriod,
}

const editWindowFields = {
    ...createWindowFields
}

const infoWindowModel = {
    [commonFields.categoryGroupTitle.propName]: commonFields.categoryGroupTitle,
    [commonFields.code.propName]: commonFields.code,
    [commonFields.title.propName]: commonFields.title,
    [commonFields.depreciationPeriod.propName]: commonFields.depreciationPeriod,
}

const tableHeaders = {
    [commonFields.categoryGroupTitle.propName]: commonFields.categoryGroupTitle,
    [commonFields.code.propName]: commonFields.code,
    [commonFields.title.propName]: commonFields.title,
    [commonFields.depreciationPeriod.propName]: commonFields.depreciationPeriod
};

const titleTable = "Категории оборудования";
const tableId = "CategoriesOfEquipment";

export default { 
    createWindowFields, 
    editWindowFields, 
    infoWindowModel, 
    tableHeaders, 
    titleTable,
    tableId
};
