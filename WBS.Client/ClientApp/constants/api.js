const root = "http://localhost:50122/api";

export default {
    //main paths to controllers
    auth: `${root}/auth/login`,
    token: `${root}/auth/token`,

    categoriesOfEquipment: `${root}/CategoriesOfEquipment/`,
    categoryGroups: `${root}/CategoryGroup/`,
    budgetPlan: `${root}/BudgetPlan/`,
    budgetLine: `${root}/BudgetLine/`,
    typesOfInvestments: `${root}/TypesOfInvestment/`,
    resultCentres: `${root}/ResultCentres/`,
    providers: `${root}/Provider/`,
    sits: `${root}/Site/`,
    formats: `${root}/Format/`,
    profiles: `${root}/Profile/`,
    newRequests: `${root}/DAIRequest/`,

    descriptors: `${root}/Descriptor`,
    permissions: `${root}/Permissions/`,

    //ATTACHMENTS
    ATTACHMENT_CONTROLLER_URL: `${root}/Attachment`,
    ATTACHMENT_UPLOAD_URL: `${root}/Attachment/Upload`,
    ATTACHMENT_DELETE_URL: `${root}/Attachment/Delete`,

    //selections for helpersAPI
    categoryGroupsSelection: `${root}/CategoryGroup/categoriesSelection/`,
    categoriesOfEquipSelection: `${root}/CategoriesOfEquipment/categoriesOfEquipSelection/`,
    sitsSelection: `${root}/Site/sitsSelection/`,
    resultCentresSelection: `${root}/ResultCentres/resCentresSelection/`,
    typesOfInvestmentSelection: `${root}/TypesOfInvestment/typesofinvestmentSelection/`,
    technicalServsSelection: `${root}/TechnicalService/technicalServsSelection/`,
    formatsSelection: `${root}/Format/formatsSelection/`,
    filteredProfilesForSelect: `${root}/Profile/usersSelection/`,
    rolesSelection: `${root}/Profile/rolesSelection/`,
    investmentRationaleSelection: `${root}/RationaleForInvestment/investmentRationaleSelection/`,

    markProfileForDeletion: `${root}/Profile/markForDeletion/`
};
