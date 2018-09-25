import { createSelector } from 'reselect';

const getTable = tableName => state => state.tables[tableName];

export const getTableData = tableName =>
    createSelector(
        [getTable(tableName)],
        (table) => table.data && table.permissions &&
            table.data.map(item => ({
                ...item,
                permissions: { ...table.permissions }
            }))
    );

export const getProvidersTableData = tableName =>
    createSelector(
        [getTable(tableName)],
        (table) => table.data && table.permissions &&
            table.data.map(item => ({
                ...item,
                permissions: { ...table.permissions },
                providersTechnicalServices: item.providersTechnicalServices.map(p => p.title).join(", ")
            }))
    );

export const getProfilesTableData = tableName =>
    createSelector(
        [getTable(tableName)],
        (table) => table.data && table.permissions &&
            table.data.map(item => ({
                ...item,
                permissions: { ...table.permissions },
                deletionMark: item.deletionMark ? 'Да' : 'Нет'
            }))
    );