import { TypesOfColumnData } from "../../../constants";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    categoryGroupId: {
        id: "categoryGroupId",
        label: "Группа категории"
    },
    categoryGroupTitle: {
        id: "categoryGroupTitle",
        label: "Группа категории"
    },
    code: {
        id: "code",
        label: "Код"
    },
    title: {
        id: "title",
        label: "Название"
    },
    depreciationPeriod: {
        id: "depreciationPeriod",
        label: "Амортизация, лет."
    }
};

const createWindowFields = {
    [commonFields.categoryGroupId.id]: commonFields.categoryGroupId,
    [commonFields.code.id]: commonFields.code,
    [commonFields.title.id]: commonFields.title,
    [commonFields.depreciationPeriod.id]: commonFields.depreciationPeriod,
}

const editWindowFields = {
    ...createWindowFields
}

const infoWindowModel = {
    [commonFields.categoryGroupTitle.id]: commonFields.categoryGroupTitle,
    [commonFields.code.id]: commonFields.code,
    [commonFields.title.id]: commonFields.title,
    [commonFields.depreciationPeriod.id]: commonFields.depreciationPeriod,
}

const tableHeaders = {
    [commonFields.categoryGroupTitle.id]: {
        ...commonFields.categoryGroupTitle,
        type: TypesOfColumnData.STRING
    },
    [commonFields.code.id]: {
        ...commonFields.code,
        type: TypesOfColumnData.STRING
    },
    [commonFields.title.id]: {
        ...commonFields.title,
        type: TypesOfColumnData.STRING
    },
    [commonFields.depreciationPeriod.id]: {
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
