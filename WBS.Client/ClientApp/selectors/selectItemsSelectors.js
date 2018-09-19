import { createSelector } from 'reselect';

const getComponent = componentName => state => state.components[componentName];

const getSelectItems = componentName =>
    createSelector(
        [getComponent(componentName)],
        (component) => component.data &&
            component.data.map(elem => ({
                value: elem.id,
                text: elem.title
            }))
    );

export default getSelectItems;