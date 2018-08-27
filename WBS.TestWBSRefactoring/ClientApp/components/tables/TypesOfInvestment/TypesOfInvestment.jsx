import React from "react";

import DataFieldsInfo from './DataFieldsInfo';
import TypeOfInvestmentsContainer from 'containers/tables/TypeOfInvestments/TypeOfInvestments';
import DialogBody from './TypeOfInvestmentDialogBody';
import { tableStyles } from './TypeOfInvestments.css';


const TypeOfInvestments = () => {
    const TypeOfInvestments = TypeOfInvestmentsContainer(DataFieldsInfo, DialogBody, tableStyles);

    return <TypeOfInvestments />
    
}

export default TypeOfInvestments;


