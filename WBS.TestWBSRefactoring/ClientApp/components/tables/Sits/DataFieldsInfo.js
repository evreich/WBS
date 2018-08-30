import TypesOfColumnData from "constants/typesOfColumnData";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    formatId: {
        propName: "formatId",
        label: "Формат",
        type: TypesOfColumnData.NUMBER
    },
    formatTitle: {
        propName: "formatTitle",
        label: "Формат",
        type: TypesOfColumnData.STRING
    },
    kySitId: {
        propName: "kySitId",
        label: "КУ Сита",
        type: TypesOfColumnData.NUMBER
    },
    kySitFio: {
        propName: "kySitFio",
        label: "КУ Сита",
        type: TypesOfColumnData.STRING
    },
    technicalExpertId: {
        propName: "technicalExpertId",
        label: "Технический эксперт",
        type: TypesOfColumnData.NUMBER
    },
    technicalExpertFio: {
        propName: "technicalExpertFio",
        label: "Технический эксперт",
        type: TypesOfColumnData.STRING
    },
    directorOfSitId: {
        propName: "directorOfSitId",
        label: "Директор Сита",
        type: TypesOfColumnData.NUMBER
    },
    directorOfSitFio: {
        propName: "directorOfSitFio",
        label: "Директор Сита",
        type: TypesOfColumnData.STRING
    },
    createrOfBudgetId: {
        propName: "createrOfBudgetId",
        label: "Создатель",
        type: TypesOfColumnData.NUMBER
    },
    createrOfBudgetFio: {
        propName: "createrOfBudgetFio",
        label: "Создатель",
        type: TypesOfColumnData.STRING
    },
    kyRegionId: {
        propName: "kyRegionId",
        label: "КУ региональный",
        type: TypesOfColumnData.NUMBER
    },
    kyRegionFio: {
        propName: "kyRegionFio",
        label: "КУ региональный",
        type: TypesOfColumnData.STRING
    },
    operationDirectorId: {
        propName: "operationDirectorId",
        label: "Операционный директор",
        type: TypesOfColumnData.NUMBER
    },
    operationDirectorFio: {
        propName: "operationDirectorFio",
        label: "Операционный директор",
        type: TypesOfColumnData.STRING
    },
    title: {
        propName: "title",
        label: "Название",
        type: TypesOfColumnData.STRING
    }
};

const infoWindowModel = {
    [commonFields.title.propName]: commonFields.title,
    [commonFields.formatTitle.propName]: commonFields.formatTitle,
    [commonFields.kySitFio.propName]: commonFields.kySitFio,
    [commonFields.technicalExpertFio.propName]: commonFields.technicalExpertFio,
    [commonFields.directorOfSitFio.propName]: commonFields.directorOfSitFio,
    [commonFields.createrOfBudgetFio.propName]: commonFields.createrOfBudgetFio,
    [commonFields.kyRegionFio.propName]: commonFields.kyRegionFio,
    [commonFields.operationDirectorFio.propName]:
    commonFields.operationDirectorFio
};

const createWindowFields = {
    [commonFields.title.propName]: commonFields.title,
    [commonFields.formatId.propName]: commonFields.formatId,
    [commonFields.kySitId.propName]: commonFields.kySitId,
    [commonFields.technicalExpertId.propName]: commonFields.technicalExpertId,
    [commonFields.directorOfSitId.propName]: commonFields.directorOfSitId,
    [commonFields.createrOfBudgetId.propName]: commonFields.createrOfBudgetId,
    [commonFields.kyRegionId.propName]: commonFields.kyRegionId,
    [commonFields.operationDirectorId.propName]:
    commonFields.operationDirectorId,
    ...infoWindowModel
};

const editWindowFields = {
    ...createWindowFields
};

const tableHeaders = {
    [commonFields.title.propName]: commonFields.title,
    [commonFields.formatTitle.propName]: commonFields.formatTitle,
    [commonFields.kySitFio.propName]: commonFields.kySitFio,
    [commonFields.technicalExpertFio.propName]: commonFields.technicalExpertFio,
    [commonFields.directorOfSitFio.propName]: commonFields.directorOfSitFio,
    [commonFields.createrOfBudgetFio.propName]: commonFields.createrOfBudgetFio,
    [commonFields.kyRegionFio.propName]: commonFields.kyRegionFio,
    [commonFields.operationDirectorFio.propName]:
        commonFields.operationDirectorFio
};

const titleTable = "Ситы";
const tableId = "Sits";

export default {
    createWindowFields,
    editWindowFields,
    infoWindowModel,
    tableHeaders,
    titleTable,
    tableId
};
