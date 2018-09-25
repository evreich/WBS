import TypesOfColumnData from "constants/typesOfColumnData";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    creationDate: {
        propName: "creationDate",
        label: "Дата создания",
        type: TypesOfColumnData.DATE,
        isVisible: true,
        canEdit: true,
        fieldComponent: 'TextFieldMultiline'
    },
    siteId: {
        propName: "siteId",
        label: "Название сита",
        type: TypesOfColumnData.NUMBER,
        isVisible: true,
        canEdit: true,
        fieldComponent: 'TextFieldMultiline'
    },
    siteName: {
        propName: "siteName",
        label: "Название сита",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true,
        fieldComponent: 'TextFieldMultiline'
    },
    lastModifiedData: {
        propName: "lastModifiedData",
        label: "Дата последней модификаци",
        type: TypesOfColumnData.Date,
        isVisible: true,
        canEdit: true,
        fieldComponent: ''
    },
    subject: {
        propName: "subject",
        label: "Предмет инвестиции",
        type: TypesOfColumnData.NUMBER,
        isVisible: true,
        canEdit: true,
        fieldComponent: 'TextFieldMultiline'
    }
};

const createWindowFields = {
    [commonFields.creationDate.propName]: commonFields.creationDate,
    [commonFields.siteId.propName]: commonFields.siteId,
    [commonFields.siteName.propName]: commonFields.siteName,
    [commonFields.subject.propName]: commonFields.subject
};

const editWindowFields = {
    ...createWindowFields
};
 
const infoWindowModel = {
    [commonFields.creationDate.propName]: commonFields.creationDate,
    [commonFields.siteId.propName]: commonFields.siteId,
    [commonFields.siteName.propName]: commonFields.siteName,
    [commonFields.subject.propName]: commonFields.subject
};

const tableHeaders = {
    [commonFields.creationDate.propName]: commonFields.creationDate,
    [commonFields.siteId.propName]: commonFields.siteId,
    [commonFields.siteName.propName]: commonFields.siteName,
    [commonFields.subject.propName]: commonFields.subject
};

const titleTable = "Новые заявки";
const tableId = "NewRequests";

export default {
    createWindowFields,
    editWindowFields,
    infoWindowModel,
    tableHeaders,
    titleTable,
    tableId
};
