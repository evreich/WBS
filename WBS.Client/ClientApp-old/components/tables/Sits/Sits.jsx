import React from "react";

import DataFieldsInfo from './DataFieldsInfo';
import SitsContainer from 'containers/tables/Sits/Sits';
import DialogBody from './SitsDialogBody';


const Sits = () => {
    const Sits = SitsContainer(DataFieldsInfo, DialogBody);

    return <Sits />
    
}

export default Sits;


