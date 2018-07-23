import { SortingActions } from '../constants';

const initialSortingState = {
    sort: SortingActions.SORT_DEFAULT,
    sortBy: ''
};

//
// Универсальная сортировка (с возможностью переиспользования редьюсера).
// prefix представляет собой объект стора, где будет использоваться сортировка
// Использование: комбинируем редьюсер сортировки с вашим редьюсером с помощью combineReducers
//
export const sortingReducerFor = (prefix) => {
    const sortingReducer = (state = initialSortingState, action) => {

        switch (action.type) {
            case prefix + SortingActions.SET_SORTING:
                {
                    const {
                        sort,
                        sortBy,
                    } = action.payload;
                    return Object.assign({}, state, {
                        sort,
                        sortBy
                    });
                }
            default:
                return state;
        }
    };
    return sortingReducer;
};

// Функция меняет состояние сортировки в указанной части стора
// prefix - объект стора, где используется сортировка
export const setSortingFor = (prefix) => {
    const setSorting = (response) => {
        const {
            sort,
            sortBy,
        } = response;
        return {
            type: prefix + SortingActions.SET_SORTING,
            payload: {
                sort,
                sortBy
            },
        };
    };
    return setSorting;
};