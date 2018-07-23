import { TypesOfColumnData } from "../../constants";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
export const fieldNames = {
    resultCenterId: {
        id: "resultCenterId",
        label: "Центр результата"
    },
    typeOfInvestmentId: {
        id: "typeOfInvestmentId",
        label: "Тип инвестиций"
    },
    categoryId: {
        id: "categoryId",
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

const tableHeaders = {
    [fieldNames.resultCenterId.id]: {
        ...fieldNames.resultCenter,
        type: TypesOfColumnData.STRING
    },
    [fieldNames.typeOfInvestmentId.id]: {
        ...fieldNames.typeOfInvestment,
        type: TypesOfColumnData.STRING
    },
    [fieldNames.categoryId.id]: {
        ...fieldNames.category,
        type: TypesOfColumnData.STRING
    },
    [fieldNames.subjectOfInvestment.id]: {
        ...fieldNames.subjectOfInvestment,
        type: TypesOfColumnData.STRING
    },
    [fieldNames.dateOfDelivery.id]: {
        ...fieldNames.dateOfDelivery,
        type: TypesOfColumnData.DATE
    },
    [fieldNames.count.id]: {
        ...fieldNames.count,
        type: TypesOfColumnData.NUMBER
    },
    [fieldNames.price.id]: {
        ...fieldNames.price,
        type: TypesOfColumnData.NUMBER
    },
    [fieldNames.amount.id]: {
        ...fieldNames.amount,
        type: TypesOfColumnData.NUMBER
    }
};

const titleTable = "Детальный план сита";

export default { fieldNames, tableHeaders, titleTable };
