import { createSelector } from 'reselect';

const getComponent = componentName => state => state.components[componentName];

const getSelectItems = componentName =>
    createSelector(
        [getComponent(componentName)],
        (component) => component.items &&
            component.items.map(elem => ({
                value: elem.id,
                text: elem.title
            }))
    );

export default getSelectItems;