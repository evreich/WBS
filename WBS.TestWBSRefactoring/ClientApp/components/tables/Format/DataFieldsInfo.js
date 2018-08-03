import { TypesOfColumnData } from "../../../constants";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    title: {
        propName: "title",
        label: "Название",
        type: TypesOfColumnData.STRING
    },
    profile: {
        propName: "profile",
        label: "Профиль",
        type: TypesOfColumnData.STRING
    },
    directorOfFormatId: {
        propName: "directorOfFormatId",
        label: "Директор Формата",
        type: TypesOfColumnData.NUMBER
    },
    directorOfFormatFio: {
        propName: "directorOfFormatFio",
        label: "Директор Формата",
        type: TypesOfColumnData.STRING
    },
    directorOfKYFormatId: {
        propName: "directorOfKYFormatId",
        label: "Директор КУ Формата",
        type: TypesOfColumnData.NUMBER
    },
    directorOfKYFormatFio: {
        propName: "directorOfKYFormatFio",
        label: "Директор КУ Формата",
        type: TypesOfColumnData.STRING
    },
    kyFormatId: {
        propName: "kyFormatId",
        label: "КУ Формат",
        type: TypesOfColumnData.NUMBER
    },
    kyFormatFio: {
        propName: "kyFormatFio",
        label: "КУ Формат",
        type: TypesOfColumnData.STRING
    },
    typeOfFormat: {
        propName: "typeOfFormat",
        label: "Тип Формата",
        type: TypesOfColumnData.STRING
    },
    e1Limit: {
        propName: "e1Limit",
        label: "E1",
        type: TypesOfColumnData.NUMBER
    },
    e2Limit: {
        propName: "e2Limit",
        label: "E2",
        type: TypesOfColumnData.NUMBER
    },
    e3Limit: {
        propName: "e3Limit",
        label: "E3",
        type: TypesOfColumnData.NUMBER
    },
};

const createWindowFields = {
    [commonFields.title.propName]: commonFields.title,
    [commonFields.profile.propName]: commonFields.profile,
    [commonFields.directorOfFormatId.propName]: commonFields.directorOfFormatId,
    [commonFields.directorOfKYFormatId.propName]: commonFields.directorOfKYFormatId,
    [commonFields.kyFormatId.propName]: commonFields.kyFormatId,
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

export default {
    createWindowFields,
    editWindowFields,
    infoWindowModel,
    tableHeaders,
    titleTable
};
