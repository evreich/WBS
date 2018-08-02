import { SortingActions, TypesOfColumnData } from "../constants";

export const sortOn = (sortingDataProp, type, sortOrder) => (
    currItem,
    nextItem
) => {
    switch (type) {
        case TypesOfColumnData.STRING:
            return sortOrder === SortingActions.SORT_DESC
                ? currItem[sortingDataProp] > nextItem[sortingDataProp]
                    ? -1
                    : 1
                : nextItem[sortingDataProp] > currItem[sortingDataProp]
                    ? -1
                    : 1;

        case TypesOfColumnData.DATE:
            return sortOrder === SortingActions.SORT_DESC
                ? new Date(nextItem[sortingDataProp]) -
                      new Date(currItem[sortingDataProp])
                : new Date(currItem[sortingDataProp]) -
                      new Date(nextItem[sortingDataProp]);

        case TypesOfColumnData.NUMBER:
            return sortOrder === SortingActions.SORT_DESC
                ? nextItem[sortingDataProp] - currItem[sortingDataProp]
                : currItem[sortingDataProp] - nextItem[sortingDataProp];
        case TypesOfColumnData.NONE:
        case TypesOfColumnData.ARRAY:
            return 0
    }
};
