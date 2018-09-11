import { rootRequest } from '../../helpers/helperAPIRequest';

const ROUTE = document.api;

export function getCategoryGroups(onSuccess, onError) {
    const currRoute = ROUTE.categoryGroupsSelection;

    rootRequest(currRoute, onSuccess, onError);
}

export function getSites(onSuccess, onError) {
    const currRoute = ROUTE.sitsSelection;

    rootRequest(currRoute, onSuccess, onError);
}


export function getResultCentres(onSuccess, onError) {
    const currRoute = ROUTE.resultCentresSelection;

    rootRequest(currRoute, onSuccess, onError);
}

export function getTypesOfInvestment(onSuccess, onError) {
    const currRoute = ROUTE.typesOfInvestmentSelection;

    rootRequest(currRoute, onSuccess, onError);
}

export function getTechnicalServs(onSuccess, onError) {
    const currRoute = ROUTE.technicalServsSelection;

    rootRequest(currRoute, onSuccess, onError);
}

export function getCategoriesOfEquip(onSuccess, onError) {
    const currRoute = ROUTE.categoriesOfEquipSelection;

    rootRequest(currRoute, onSuccess, onError);
}

export function getFormats(onSuccess, onError) {
    const currRoute = ROUTE.formatsSelection;

    rootRequest(currRoute, onSuccess, onError);
}

export function getProfilesForSelect(onSuccess, onError) {
    const currRoute = ROUTE.filteredProfilesForSelect;

    rootRequest(currRoute, onSuccess, onError);
}

export function getRolesForSelect(onSuccess, onError) {
    const currRoute = ROUTE.rolesSelection;

    rootRequest(currRoute, onSuccess, onError);
}

export function getInvestmentRational(onSuccess, onError) {
    const currRoute = ROUTE.investmentRationaleSelection;

    rootRequest(currRoute, onSuccess, onError);
}

