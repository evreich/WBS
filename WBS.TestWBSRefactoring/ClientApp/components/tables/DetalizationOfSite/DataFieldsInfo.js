import { TypesOfColumnData } from "../../../constants";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    resultCenterId: {
        propName: "resultCenterId",
        label: "Центр результата"
    },
    resultCenterTitle: {
        propName: "resultCenter",
        label: "Центр результата"
    },
    typeOfInvestmentId: {
        propName: "typeOfInvestmentId",
        label: "Тип инвестиций"
    },
    typeOfInvestmentTitle: {
        propName: "typeOfInvestment",
        label: "Тип инвестиций"
    },
    categoryOfEquipmentId: {
        propName: "categoryOfEquipmentId",
        label: "Категория"
    },
    categoryOfEquipmentTitle: {
        propName: "categoryOfEquipment",
        label: "Категория"
    },
    subjectOfInvestment: {
        propName: "subjectOfInvestment",
        label: "Предмет инвестиций"
    },
    dateOfDelivery: {
        propName: "dateOfDelivery",
        label: "Дата поставки"
    },
    count: {
        propName: "count",
        label: "Количество"
    },
    price: {
        propName: "price",
        label: "Цена, руб."
    },
    amount: {
        propName: "amount",
        label: "Сумма, руб."
    }
};

const createWindowFields = {
    [commonFields.resultCenterId.propName]: commonFields.resultCenterId,
    [commonFields.typeOfInvestmentId.propName]: commonFields.typeOfInvestmentId,
    [commonFields.categoryOfEquipmentId.propName]: commonFields.categoryOfEquipmentId,
    [commonFields.subjectOfInvestment.propName]: commonFields.subjectOfInvestment,
    [commonFields.dateOfDelivery.propName]: commonFields.dateOfDelivery,
    [commonFields.count.propName]: commonFields.count,
    [commonFields.price.propName]: commonFields.price,
    [commonFields.amount.propName]: commonFields.amount
}

const editWindowFields = {
    ...createWindowFields
}

const infoWindowModel = {
    [commonFields.resultCenterTitle.propName]: commonFields.resultCenterTitle,
    [commonFields.typeOfInvestmentTitle.propName]: commonFields.typeOfInvestmentTitle,
    [commonFields.categoryOfEquipmentTitle.propName]: commonFields.categoryOfEquipmentTitle,
    [commonFields.subjectOfInvestment.propName]: commonFields.subjectOfInvestment,
    [commonFields.dateOfDelivery.propName]: commonFields.dateOfDelivery,
    [commonFields.count.propName]: commonFields.count,
    [commonFields.price.propName]: commonFields.price,
    [commonFields.amount.propName]: commonFields.amount,
}

const tableHeaders = {
    [commonFields.resultCenterTitle.propName]: {
        ...commonFields.resultCenterTitle,
        type: TypesOfColumnData.STRING
    },
    [commonFields.typeOfInvestmentTitle.propName]: {
        ...commonFields.typeOfInvestmentTitle,
        type: TypesOfColumnData.STRING
    },
    [commonFields.categoryOfEquipmentTitle.propName]: {
        ...commonFields.categoryOfEquipmentTitle,
        type: TypesOfColumnData.STRING
    },
    [commonFields.subjectOfInvestment.propName]: {
        ...commonFields.subjectOfInvestment,
        type: TypesOfColumnData.STRING
    },
    [commonFields.dateOfDelivery.propName]: {
        ...commonFields.dateOfDelivery,
        type: TypesOfColumnData.DATE
    },
    [commonFields.count.propName]: {
        ...commonFields.count,
        type: TypesOfColumnData.NUMBER
    },
    [commonFields.price.propName]: {
        ...commonFields.price,
        type: TypesOfColumnData.NUMBER
    },
    [commonFields.amount.propName]: {
        ...commonFields.amount,
        type: TypesOfColumnData.NUMBER
    }
};

const titleTable = "Детальный план сита";

export default { createWindowFields, editWindowFields, infoWindowModel, tableHeaders, titleTable };