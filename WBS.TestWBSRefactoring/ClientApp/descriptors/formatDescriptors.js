import TypesOfColumnData from "constants/typesOfColumnData";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    title: {
        propName: "title",
        label: "Название",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true
    },
    profile: {
        propName: "profile",
        label: "Профиль",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true
    },
    directorOfFormatId: {
        propName: "directorOfFormatId",
        label: "Директор Формата",
        type: TypesOfColumnData.NUMBER,
        isVisible: true,
        canEdit: true
    },
    directorOfFormatFio: {
        propName: "directorOfFormatFio",
        label: "Директор Формата",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true
    },
    directorOfKYFormatId: {
        propName: "directorOfKYFormatId",
        label: "Директор КУ Формата",
        type: TypesOfColumnData.NUMBER,
        isVisible: true,
        canEdit: true
    },
    directorOfKYFormatFio: {
        propName: "directorOfKYFormatFio",
        label: "Директор КУ Формата",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true
    },
    kyFormatId: {
        propName: "kyFormatId",
        label: "КУ Формат",
        type: TypesOfColumnData.NUMBER,
        isVisible: true,
        canEdit: true
    },
    kyFormatFio: {
        propName: "kyFormatFio",
        label: "КУ Формат",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true
    },
    typeOfFormat: {
        propName: "typeOfFormat",
        label: "Тип Формата",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true
    },
    e1Limit: {
        propName: "e1Limit",
        label: "E1",
        type: TypesOfColumnData.NUMBER,
        isVisible: true,
        canEdit: true
    },
    e2Limit: {
        propName: "e2Limit",
        label: "E2",
        type: TypesOfColumnData.NUMBER,
        isVisible: true,
        canEdit: true
    },
    e3Limit: {
        propName: "e3Limit",
        label: "E3",
        type: TypesOfColumnData.NUMBER,
        isVisible: true,
        canEdit: true
    },
};

const createWindowFields = {
    [commonFields.title.propName]: commonFields.title,
    [commonFields.profile.propName]: commonFields.profile,
    [commonFields.directorOfFormatId.propName]: commonFields.directorOfFormatId,
    [commonFields.directorOfFormatFio.propName]: commonFields.directorOfFormatFio,
    [commonFields.directorOfKYFormatId.propName]: commonFields.directorOfKYFormatId,
    [commonFields.directorOfKYFormatFio.propName]: commonFields.directorOfKYFormatFio,
    [commonFields.kyFormatId.propName]: commonFields.kyFormatId,
    [commonFields.kyFormatFio.propName]: commonFields.kyFormatFio,
    [commonFields.typeOfFormat.propName]: commonFields.typeOfFormat,
    [commonFields.e1Limit.propName]: commonFields.e1Limit,
    [commonFields.e2Limit.propName]: commonFields.e2Limit,
    [commonFields.e3Limit.propName]: commonFields.e3Limit,
};

const editWindowFields = {
    ...createWindowFields
};

const infoWindowModel = {
    [commonFields.title.propName]: commonFields.title,
    [commonFields.profile.propName]: commonFields.profile,
    [commonFields.directorOfFormatFio.propName]: commonFields.directorOfFormatFio,
    [commonFields.directorOfKYFormatFio.propName]: commonFields.directorOfKYFormatFio,
    [commonFields.kyFormatFio.propName]: commonFields.kyFormatFio,
    [commonFields.typeOfFormat.propName]: commonFields.typeOfFormat,
    [commonFields.e1Limit.propName]: commonFields.e1Limit,
    [commonFields.e2Limit.propName]: commonFields.e2Limit,
    [commonFields.e3Limit.propName]: commonFields.e3Limit,
};

const tableHeaders = {
    [commonFields.title.propName]: commonFields.title,
    [commonFields.profile.propName]: commonFields.profile,
    [commonFields.directorOfFormatFio.propName]: commonFields.directorOfFormatFio,
    [commonFields.directorOfKYFormatFio.propName]: commonFields.directorOfKYFormatFio,
    [commonFields.kyFormatFio.propName]: commonFields.kyFormatFio,
    [commonFields.typeOfFormat.propName]: commonFields.typeOfFormat,
    [commonFields.e1Limit.propName]: commonFields.e1Limit,
    [commonFields.e2Limit.propName]: commonFields.e2Limit,
    [commonFields.e3Limit.propName]: commonFields.e3Limit,
};

const titleTable = "Форматы ситов";
const tableId = "Format";

export default {
    createWindowFields,
    editWindowFields,
    infoWindowModel,
    tableHeaders,
    titleTable,
    tableId
};
