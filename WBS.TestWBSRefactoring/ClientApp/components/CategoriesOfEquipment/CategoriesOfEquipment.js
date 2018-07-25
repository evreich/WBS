import React from "react";

import DataFieldsInfo from './DataFieldsInfo';
import CategoriesOfEquipmentContainer from '../../containers/CategoriesOfEquipment/CategoriesOfEquipment';
import DialogBody from './CategoriesOfEquipmentDialogBody';

//const CategoriesOfEquipment = () => CategoriesOfEquipmentContainer(DataFieldsInfo, DialogBody);

const CategoriesOfEquipment = () => {
    const CategoriesOfEquipment = CategoriesOfEquipmentContainer(DataFieldsInfo, DialogBody);

    return (
        <CategoriesOfEquipment />
    )
}

export default CategoriesOfEquipment;


