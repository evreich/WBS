import { TypesOfColumnData } from "../../../constants";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    categoryGroupId: {
        propName: "categoryGroupId",
        label: "Группа категории"
    },
    categoryGroupTitle: {
        propName: "categoryGroupTitle",
        label: "Группа категории"
    },
    code: {
        propName: "code",
        label: "Код"
    },
    title: {
        propName: "title",
        label: "Название"
    },
    depreciationPeriod: {
        propName: "depreciationPeriod",
        label: "Амортизация, лет."
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
    [commonFields.categoryGroupTitle.propName]: {
        ...commonFields.categoryGroupTitle,
        type: TypesOfColumnData.STRING
    },
    [commonFields.code.propName]: {
        ...commonFields.code,
        type: TypesOfColumnData.STRING
    },
    [commonFields.title.propName]: {
        ...commonFields.title,
        type: TypesOfColumnData.STRING
    },
    [commonFields.depreciationPeriod.propName]: {
        ...commonFields.depreciationPeriod,
        type: TypesOfColumnData.NUMBER
    }
};

const titleTable = "Категории оборудования";

export default { 
    createWindowFields, 
    editWindowFields, 
    infoWindowModel, 
    tableHeaders, 
    titleTable 
};
