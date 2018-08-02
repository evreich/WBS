import request from '../../utils/fetchUtil';
import REQUEST_METHOD from '../../settings/httpMethods';

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

const rootRequest = (currRoute, onSuccess, onError) => {
    if (!currRoute) throw new Error("Can't resolve URI");

    request(
        {
            method: REQUEST_METHOD.HTTP_GET,
            route: currRoute,
        },
        (data) => onSuccess(data),
        (ex) => onError(ex)
    )
};