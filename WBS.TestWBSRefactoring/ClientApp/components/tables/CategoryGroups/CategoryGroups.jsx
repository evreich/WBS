import React from "react";

import DataFieldsInfo from './DataFieldsInfo';
import CategoryGroupsContainer from '../../../containers/tables/CategoryGroups/CategoryGroups';
import DialogBody from './CategoryGroupDialogBody';
import { tableStyles } from '../tableLayoutAuto.css';


const CategoryGroups = () => {
    const CategoryGroups = CategoryGroupsContainer(DataFieldsInfo, DialogBody, tableStyles);

    return <CategoryGroups />
    
}

export default CategoryGroups;


