import { TypesOfColumnData } from "../../constants";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
export const fieldNames = {
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

const tableHeaders = {
    [fieldNames.categoryGroupTitle.id]: {
        ...fieldNames.categoryGroupTitle,
        type: TypesOfColumnData.NUMBER
    },
    [fieldNames.code.id]: {
        ...fieldNames.code,
        type: TypesOfColumnData.NUMBER
    },
    [fieldNames.title.id]: {
        ...fieldNames.title,
        type: TypesOfColumnData.STRING
    },
    [fieldNames.depreciationPeriod.id]: {
        ...fieldNames.depreciationPeriod,
        type: TypesOfColumnData.DATE
    }
};

const titleTable = "Категории оборудования";

export default { fieldNames, tableHeaders, titleTable };
