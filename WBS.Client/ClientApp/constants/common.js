export const BASE_URL = 'http://localhost:50120';
export const API_URL = `${BASE_URL}/api`;

// AUTH
export const AUTH_CONTROLLER_URL = `${API_URL}/auth`;
export const TOKEN_API_URL = `${AUTH_CONTROLLER_URL}/token`;
export const LOGIN_API_URL = `${AUTH_CONTROLLER_URL}/login`;
export const SIGNUP_API_URL = `${AUTH_CONTROLLER_URL}/signup`;

// BUDGET PLANS
export const BUDGET_PLANS_CONTROLLER_URL = `${API_URL}/budgetPlan`;

// FORMATS
export const FORMAT_CONTROLLER_URL = `${API_URL}/format`;
export const GET_FORMATS_FOR_SELECT = `${FORMAT_CONTROLLER_URL}/formatsSelection`;

// PROVIDER
export const PROVIDER_CONTROLLER_URL = `${API_URL}/provider`;
export const GET_FILTERED_PROVIDERS = `${PROVIDER_CONTROLLER_URL}/FilteredProviders`;

// PROFILE
export const PROFILE_CONTROLLER_URL = `${API_URL}/profile`;
export const PROFILE_SET_DELETION_MARK = `${PROFILE_CONTROLLER_URL}/markForDeletion`;
export const GET_PROFILE_FOR_SELECT = `${PROFILE_CONTROLLER_URL}/usersSelection`;
export const GET_ROLES_FOR_SELECT = `${PROFILE_CONTROLLER_URL}/rolesSelection`;

// INVESTMENT
export const INVESTMENT_CONTROLLER_URL = `${API_URL}/TypesOfInvestment`;
export const GET_TYPES_OF_INVESTMENT_FOR_SELECT = `${INVESTMENT_CONTROLLER_URL}/typesofinvestmentSelection`;

// RESULT_CENTRE
export const RESULT_CENTRE_CONTROLLER_URL = `${API_URL}/ResultCentres`;
export const GET_RESULT_CENTRE_FOR_SELECT = `${RESULT_CENTRE_CONTROLLER_URL}/resCentresSelection`;

// DAI_REQUEST
export const DAI_REQUEST_CONTROLLER_URL = `${API_URL}/DAIRequest`;

// CATEGORY_GROUPS
export const CATEGORY_GROUPS_CONTROLLER_URL = `${API_URL}/CategoryGroup`;
export const GET_CATEGORY_GROUPS_FOR_SELECT = `${CATEGORY_GROUPS_CONTROLLER_URL}/categoriesSelection`;

// CATEGORIES_OF_EQUIP
export const CATEGORIES_OF_EQUIP_CONTROLLER_URL = `${API_URL}/CategoriesOfEquipment`;

// SITS
export const SITS_CONTROLLER_URL = `${API_URL}/site`;
export const GET_SITS_FOR_SELECT = `${SITS_CONTROLLER_URL}/sitsSelection`;

//TECHNICAL_SERVS
export const TECHNICAL_SERVS_CONTROLLER_URL = `${API_URL}/TechnicalService`;
export const GET_TECHNICAL_SERVS_SELECT = `${TECHNICAL_SERVS_CONTROLLER_URL}/technicalServsSelection`;


//RATIONAL_FOR_INVESTMENT
export const RATIONAL_FOR_INVESTMENT_CONTROLLER_URL = `${API_URL}/RationaleForInvestment`;
export const GET_RATIONAL_INVESTMENT_SELECT = `${RATIONAL_FOR_INVESTMENT_CONTROLLER_URL}/investmentRationaleSelection`;

//ITEMS_OF_BUSINESS_PLAN
export const ITEMS_OF_BUDGET_PLAN_CONTROLLER_URL = `${API_URL}/ItemsOfBudgetPlan`;
export const GET_ITEMS_OF_BUDGET_PLAN = `${ITEMS_OF_BUDGET_PLAN_CONTROLLER_URL}/getDetailsOfBP`;


export const STORE_KEY = 'STORE_KEY';