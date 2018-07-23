
import { PaginationActions } from '../constants';

const initialPaginationState = {
    currentPage: 0,
    elementsPerPage: 5,
    elementsCount: 0
};

//
// Универсальная пагинация (с возможностью переиспользования редьюсера).
// prefix представляет собой объект стора, где будет использоваться пагинация
// Использование: комбинируем редьюсер пагинации с вашим редьюсером с помощью combineReducers
//
export const paginationReducerFor = (prefix) => {
    const paginationReducer = (state = initialPaginationState, action) => {
       
        switch (action.type) {
            case prefix + PaginationActions.SET_PAGINATION:
                {
                    const {
                            currentPage,
                            elementsPerPage,
                            elementsCount,
                     } = action.payload;
                    return Object.assign({}, state, {
                        currentPage,
                        elementsPerPage,
                        elementsCount,
                    });
                }
            default:
                return state;
        }
    };
    return paginationReducer;
};


export const setPaginationFor = (prefix) => {
    const setPagination = (response) => {
        const {
            currentPage,
            elementsPerPage,
            elementsCount,
    } = response;
        return {
            type: prefix + PaginationActions.SET_PAGINATION,
            payload: {
                currentPage,
                elementsPerPage,
                elementsCount
            },
        };
    };
    return setPagination;
};