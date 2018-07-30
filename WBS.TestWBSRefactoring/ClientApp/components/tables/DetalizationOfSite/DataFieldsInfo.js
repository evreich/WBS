import { TypesOfColumnData } from "../../../constants";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    resultCenterId: {
        id: "resultCenterId",
        label: "Центр результата"
    },
    resultCenterTitle: {
        id: "resultCenterTitle",
        label: "Центр результата"
    },
    typeOfInvestmentId: {
        id: "typeOfInvestmentId",
        label: "Тип инвестиций"
    },
    typeOfInvestmentTitle: {
        id: "typeOfInvestmentTitle",
        label: "Тип инвестиций"
    },
    categoryId: {
        id: "categoryId",
        label: "Категория"
    },
    categoryTitle: {
        id: "categoryTitle",
        label: "Категория"
    },
    subjectOfInvestment: {
        id: "subjectOfInvestment",
        label: "Предмет инвестиций"
    },
    dateOfDelivery: {
        id: "dateOfDelivery",
        label: "Дата поставки"
    },
    count: {
        id: "count",
        label: "Количество"
    },
    price: {
        id: "price",
        label: "Цена, руб."
    },
    amount: {
        id: "amount",
        label: "Сумма, руб."
    }
};

const createWindowFields = {
    [commonFields.resultCenterId.id]: commonFields.resultCenterId,
    [commonFields.typeOfInvestmentId.id]: commonFields.typeOfInvestmentId,
    [commonFields.categoryId.id]: commonFields.categoryId,
    [commonFields.subjectOfInvestment.id]: commonFields.subjectOfInvestment,
    [commonFields.dateOfDelivery.id]: commonFields.dateOfDelivery,
    [commonFields.count.id]: commonFields.count,
    [commonFields.price.id]: commonFields.price,
    [commonFields.amount.id]: commonFields.amount,
}

const editWindowFields = {
    ...createWindowFields
}

const infoWindowModel = {
    [commonFields.resultCenterTitle.id]: commonFields.resultCenterTitle,
    [commonFields.typeOfInvestmentTitle.id]: commonFields.typeOfInvestmentTitle,
    [commonFields.categoryTitle.id]: commonFields.categoryTitle,
    [commonFields.subjectOfInvestment.id]: commonFields.subjectOfInvestment,
    [commonFields.dateOfDelivery.id]: commonFields.dateOfDelivery,
    [commonFields.count.id]: commonFields.count,
    [commonFields.price.id]: commonFields.price,
    [commonFields.amount.id]: commonFields.amount,
}

const tableHeaders = {
    [commonFields.resultCenterTitle.id]: {
        ...commonFields.resultCenter,
        type: TypesOfColumnData.STRING
    },
    [commonFields.typeOfInvestmentTitle.id]: {
        ...commonFields.typeOfInvestment,
        type: TypesOfColumnData.STRING
    },
    [commonFields.categoryTitle.id]: {
        ...commonFields.category,
        type: TypesOfColumnData.STRING
    },
    [commonFields.subjectOfInvestment.id]: {
        ...commonFields.subjectOfInvestment,
        type: TypesOfColumnData.STRING
    },
    [commonFields.dateOfDelivery.id]: {
        ...commonFields.dateOfDelivery,
        type: TypesOfColumnData.DATE
    },
    [commonFields.count.id]: {
        ...commonFields.count,
        type: TypesOfColumnData.NUMBER
    },
    [commonFields.price.id]: {
        ...commonFields.price,
        type: TypesOfColumnData.NUMBER
    },
    [commonFields.amount.id]: {
        ...commonFields.amount,
        type: TypesOfColumnData.NUMBER
    }
};

const titleTable = "Детальный план сита";

export default { createWindowFields, editWindowFields, infoWindowModel, tableHeaders, titleTable };