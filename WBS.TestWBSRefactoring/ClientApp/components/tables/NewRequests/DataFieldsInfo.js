import TypesOfColumnData from "../../../constants/typesOfColumnData";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    creationData: {
        propName: "creationData",
        label: "Дата создания",
        type: TypesOfColumnData.DATE
    },
    siteId: {
        propName: "siteId",
        label: "Название сита",
        type: TypesOfColumnData.NUMBER
    },
    siteTitle: {
        propName: "siteTitle",
        label: "Название сита",
        type: TypesOfColumnData.STRING
    },
    lastModifiedData: {
        propName: "lastModifiedData",
        label: "Дата последней модификации",
        type: TypesOfColumnData.DATE
    },
    subject: {
        propName: "subject",
        label: "Предмет инвестиции",
        type: TypesOfColumnData.STRING
    },

    //fields for new investment
    number: {
        propName: "number",
        label: "Номер заявки",
        type: TypesOfColumnData.STRING
    },
    directorApprovalDate: {
        propName: "directorApprovalDate",
        label: "Дата утверждения директором",
        type: TypesOfColumnData.DATE
    },
    resultCentreId: {
        propName: "resultCentreId",
        label: "Центр результата",
        type: TypesOfColumnData.NUMBER
    },
    resultCentreName: {
        propName: "resultCentreName",
        label: "Центр результата",
        type: TypesOfColumnData.STRING
    },
    deliveryTime: {
        propName: "deliveryTime",
        label: "Желаемый срок поставки",
        type: TypesOfColumnData.DATE
    },
    approvalOfTechExpertIsRequired: {
        propName: "approvalOfTechExpertIsRequired",
        label: "Требуется одобрение технического эксперта",
        type: TypesOfColumnData.BOOLEAN
    },
    rationaleForInvestmentId: {
        propName: "rationaleForInvestmentId",
        label: "Обоснование необходимости инвестиций",
        type: TypesOfColumnData.NUMBER
    },
    commentForDirectorGeneral: {
        propName: "commentForDirectorGeneral",
        label: "Комментарий для генерального директора",
        type: TypesOfColumnData.STRING
    },
    reasonForDAI: {
        propName: "reasonForDAI",
        label: "Причины заполнения заявки",
        type: TypesOfColumnData.STRING
    },
    totalInvestment: {
        propName: "totalInvestment",
        label: "Всего инвестиций",
        type: TypesOfColumnData.NUMBER
    },
    estimatedOperationPeriod: {
        propName: "estimatedOperationPeriod",
        label: "Предположительный срок эксплуатации",
        type: TypesOfColumnData.NUMBER
    },
    additionalSalesPerYear: {
        propName: "additionalSalesPerYear",
        label: "Дополнительные продажи за год",
        type: TypesOfColumnData.NUMBER
    },
    savingsPerYear: {
        propName: "savingsPerYear",
        label: "Экономия средств в год",
        type: TypesOfColumnData.NUMBER
    },
    periodOfPayback: {
        propName: "periodOfPayback",
        label: "Срок окупаемости",
        type: TypesOfColumnData.NUMBER
    },
    netMargin: {
        propName: "netMargin",
        label: "Чистая маржа %",
        type: TypesOfColumnData.NUMBER
    },
    internalRateOfReturn: {
        propName: "internalRateOfReturn",
        label: "Внутренняя ставка доходности",
        type: TypesOfColumnData.NUMBER
    },
    netPresentValue: {
        propName: "netPresentValue",
        label: "Чистая приведенная стоимость",
        type: TypesOfColumnData.NUMBER
    },
    marginOnAddedValue: {
        propName: "marginOnAddedValue",
        label: "Маржа на добавочную стоимость",
        type: TypesOfColumnData.NUMBER
    },
    extraAnnualCost: {
        propName: "extraAnnualCost",
        label: "Дополнительные ежегодные затраты",
        type: TypesOfColumnData.NUMBER
    },
    technicalServs: {
        propName: "technicalServs",
        label: "Выбор технической службы*",
        type: TypesOfColumnData.ARRAY
    }
};

const mainDialogBodyFields = {
    [commonFields.number.propName]: commonFields.number,
    [commonFields.directorApprovalDate.propName]:
        commonFields.directorApprovalDate,
    [commonFields.siteId.propName]: commonFields.siteId,
    [commonFields.resultCentreId.propName]: commonFields.resultCentreId,
    [commonFields.deliveryTime.propName]: commonFields.deliveryTime,
    [commonFields.technicalServs.propName]: commonFields.technicalServs
};

const rationaleForInvestmenFields = {
    [commonFields.rationaleForInvestmentId.propName]:
        commonFields.rationaleForInvestmentId,
    [commonFields.approvalOfTechExpertIsRequired.propName]:
        commonFields.approvalOfTechExpertIsRequired,
    [commonFields.commentForDirectorGeneral.propName]:
        commonFields.commentForDirectorGeneral
};

const expansionElementsFields = {
    [commonFields.rationaleForInvestmentId.propName]:
        commonFields.rationaleForInvestmentId,
    [commonFields.reasonForDAI.propName]: commonFields.reasonForDAI,
    [commonFields.totalInvestment.propName]: commonFields.totalInvestment,
    [commonFields.estimatedOperationPeriod.propName]:
        commonFields.estimatedOperationPeriod,
    [commonFields.additionalSalesPerYear.propName]:
        commonFields.additionalSalesPerYear,
    [commonFields.savingsPerYear.propName]: commonFields.savingsPerYear,
    [commonFields.periodOfPayback.propName]: commonFields.periodOfPayback,
    [commonFields.netMargin.propName]: commonFields.netMargin,
    [commonFields.internalRateOfReturn.propName]:
        commonFields.internalRateOfReturn,
    [commonFields.netPresentValue.propName]: commonFields.netPresentValue,
    [commonFields.marginOnAddedValue.propName]: commonFields.marginOnAddedValue,
    [commonFields.extraAnnualCost.propName]: commonFields.extraAnnualCost
};

const createWindowFields = {
    mainDialogBodyFields,
    rationaleForInvestmenFields,
    expansionElementsFields
};

const editWindowFields = {
    ...createWindowFields
};

const infoWindowModel = {};

const tableHeaders = {
    [commonFields.creationData.propName]: commonFields.creationData,
    [commonFields.siteTitle.propName]: commonFields.siteTitle,
    [commonFields.lastModifiedData.propName]: commonFields.lastModifiedData,
    [commonFields.subject.propName]: commonFields.subject
};

const titleTable = "Новые заявки на инвестицию";
const tableId = "NewRequests";

export default {
    createWindowFields,
    editWindowFields,
    infoWindowModel,
    tableHeaders,
    titleTable,
    tableId
};
