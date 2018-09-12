import TypesOfColumnData from "constants/typesOfColumnData";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    formatId: {
        propName: "formatId",
        label: "Формат",
        type: TypesOfColumnData.NUMBER,
        isVisible: true,
        canEdit: true
    },
    formatTitle: {
        propName: "formatTitle",
        label: "Формат",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true
    },
    kySitId: {
        propName: "kySitId",
        label: "КУ Сита",
        type: TypesOfColumnData.NUMBER,
        isVisible: true,
        canEdit: true
    },
    kySitFio: {
        propName: "kySitFio",
        label: "КУ Сита",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true
    },
    technicalExpertId: {
        propName: "technicalExpertId",
        label: "Технический эксперт",
        type: TypesOfColumnData.NUMBER,
        isVisible: true,
        canEdit: true
    },
    technicalExpertFio: {
        propName: "technicalExpertFio",
        label: "Технический эксперт",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true
    },
    directorOfSitId: {
        propName: "directorOfSitId",
        label: "Директор Сита",
        type: TypesOfColumnData.NUMBER,
        isVisible: true,
        canEdit: true
    },
    directorOfSitFio: {
        propName: "directorOfSitFio",
        label: "Директор Сита",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true
    },
    createrOfBudgetId: {
        propName: "createrOfBudgetId",
        label: "Создатель",
        type: TypesOfColumnData.NUMBER,
        isVisible: true,
        canEdit: true
    },
    createrOfBudgetFio: {
        propName: "createrOfBudgetFio",
        label: "Создатель",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true
    },
    kyRegionId: {
        propName: "kyRegionId",
        label: "КУ региональный",
        type: TypesOfColumnData.NUMBER,
        isVisible: true,
        canEdit: true
    },
    kyRegionFio: {
        propName: "kyRegionFio",
        label: "КУ региональный",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true
    },
    operationDirectorId: {
        propName: "operationDirectorId",
        label: "Операционный директор",
        type: TypesOfColumnData.NUMBER,
        isVisible: true,
        canEdit: true
    },
    operationDirectorFio: {
        propName: "operationDirectorFio",
        label: "Операционный директор",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true
    },
    title: {
        propName: "title",
        label: "Название",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true
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
    [commonFields.operationDirectorFio.propName]: commonFields.operationDirectorFio
};

const createWindowFields = {
    [commonFields.title.propName]: commonFields.title,
    [commonFields.formatId.propName]: commonFields.formatId,
    [commonFields.kySitId.propName]: commonFields.kySitId,
    [commonFields.technicalExpertId.propName]: commonFields.technicalExpertId,
    [commonFields.directorOfSitId.propName]: commonFields.directorOfSitId,
    [commonFields.createrOfBudgetId.propName]: commonFields.createrOfBudgetId,
    [commonFields.kyRegionId.propName]: commonFields.kyRegionId,
    [commonFields.operationDirectorId.propName]: commonFields.operationDirectorId,
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
    [commonFields.operationDirectorFio.propName]: commonFields.operationDirectorFio
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