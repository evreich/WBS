import TypesOfColumnData from "constants/typesOfColumnData";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    budgetPlanId: {
        propName: "budgetPlanId",
        label: "Год",
        type: TypesOfColumnData.NUMBER
    },
    budgetPlanTitle: {
        propName: "budgetPlan",
        label: "Год",
        type: TypesOfColumnData.STRING
    },
    siteId: {
        propName: "siteId",
        label: "Название Сита",
        type: TypesOfColumnData.NUMBER
    },
    siteTitle: {
        propName: "site",
        label: "Название Сита",
        type: TypesOfColumnData.STRING
    },
    resultCenterId: {
        propName: "resultCenterId",
        label: "Центр результата",
        type: TypesOfColumnData.NUMBER
    },
    resultCenterTitle: {
        propName: "resultCenter",
        label: "Центр результата",
        type: TypesOfColumnData.STRING
    },
    typeOfInvestmentId: {
        propName: "typeOfInvestmentId",
        label: "Тип инвестиций",
        type: TypesOfColumnData.NUMBER
    },
    typeOfInvestmentTitle: {
        propName: "typeOfInvestment",
        label: "Тип инвестиций",
        type: TypesOfColumnData.STRING
    },
    categoryGroupId: {
        propName: "categoryGroupId",
        label: "Группы категорий",
        type: TypesOfColumnData.NUMBER
    },
    categoryGroupTitle: {
        propName: "categoryGroup",
        label: "Группы категорий",
        type: TypesOfColumnData.STRING
    },
    categoryOfEquipmentId: {
        propName: "categoryOfEquipmentId",
        label: "Категория",
        type: TypesOfColumnData.NUMBER
    },
    categoryOfEquipmentTitle: {
        propName: "categoryOfEquipment",
        label: "Категория",
        type: TypesOfColumnData.STRING
    },
    subjectOfInvestment: {
        propName: "subjectOfInvestment",
        label: "Предмет инвестиций",
        type: TypesOfColumnData.STRING
    },
    count: {
        propName: "count",
        label: "Количество",
        type: TypesOfColumnData.NUMBER
    },
    price: {
        propName: "price",
        label: "Цена, руб.",
        type: TypesOfColumnData.NUMBER
    },
    amount: {
        propName: "amount",
        label: "Сумма, руб.",
        type: TypesOfColumnData.NUMBER
    },
    plannedInvestmentDate: {
        propName: "plannedInvestmentDate",
        label: "Дата поставки",
        type: TypesOfColumnData.NUMBER
    }
};

const createWindowFields = {
    [commonFields.resultCenterId.propName]: commonFields.resultCenterId,
    [commonFields.resultCenterTitle.propName]: commonFields.resultCenterTitle,
    [commonFields.budgetPlanId.propName]: commonFields.budgetPlanId,
    [commonFields.budgetPlanTitle.propName]: commonFields.budgetPlanTitle,
    [commonFields.siteId.propName]: commonFields.siteId,
    [commonFields.siteTitle.propName]: commonFields.siteTitle,
    [commonFields.typeOfInvestmentId.propName]: commonFields.typeOfInvestmentId,
    [commonFields.typeOfInvestmentTitle.propName]:
        commonFields.typeOfInvestmentTitle,
    [commonFields.categoryOfEquipmentId.propName]:
        commonFields.categoryOfEquipmentId,
    [commonFields.categoryOfEquipmentTitle.propName]:
        commonFields.categoryOfEquipmentTitle,
    [commonFields.subjectOfInvestment.propName]:
        commonFields.subjectOfInvestment,
    [commonFields.plannedInvestmentDate.propName]: commonFields.plannedInvestmentDate,
    [commonFields.count.propName]: commonFields.count,
    [commonFields.price.propName]: commonFields.price,
    [commonFields.amount.propName]: commonFields.amount
};

const editWindowFields = {
    ...createWindowFields
};

const infoWindowModel = {
    [commonFields.resultCenterTitle.propName]: commonFields.resultCenterTitle,
    [commonFields.typeOfInvestmentTitle.propName]:
        commonFields.typeOfInvestmentTitle,
    [commonFields.categoryOfEquipmentTitle.propName]:
        commonFields.categoryOfEquipmentTitle,
    [commonFields.subjectOfInvestment.propName]:
        commonFields.subjectOfInvestment,
    [commonFields.plannedInvestmentDate.propName]: commonFields.plannedInvestmentDate,
    [commonFields.count.propName]: commonFields.count,
    [commonFields.price.propName]: commonFields.price,
    [commonFields.amount.propName]: commonFields.amount
};

const tableHeaders = {
    [commonFields.resultCenterTitle.propName]: commonFields.resultCenterTitle,
    [commonFields.typeOfInvestmentTitle.propName]:
        commonFields.typeOfInvestmentTitle,
    [commonFields.categoryOfEquipmentTitle.propName]:
        commonFields.categoryOfEquipmentTitle,
    [commonFields.subjectOfInvestment.propName]:
        commonFields.subjectOfInvestment,
    [commonFields.plannedInvestmentDate.propName]: commonFields.plannedInvestmentDate,
    [commonFields.count.propName]: commonFields.count,
    [commonFields.price.propName]: commonFields.price,
    [commonFields.amount.propName]: commonFields.amount
};

const titleTable = "Детальный план сита";
const tableId = "DetalizationOfSite";

export default {
    createWindowFields,
    editWindowFields,
    infoWindowModel,
    tableHeaders,
    titleTable,
    tableId
};
