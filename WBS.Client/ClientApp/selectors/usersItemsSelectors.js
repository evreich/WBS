import { createSelector } from 'reselect';

const getComponent = componentName => state => state.components[componentName];

const getSelectItems = componentName =>
    createSelector(
        [getComponent(componentName)],
        (component) => component.items &&
            component.items.map(elem => ({
                id: elem.id,
                login: elem.login,
                fio: elem.fio
            }))
    );

export default getSelectItems;