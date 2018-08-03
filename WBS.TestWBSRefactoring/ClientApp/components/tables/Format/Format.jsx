import React from "react";

import DataFieldsInfo from './DataFieldsInfo';
import FormatContainer from '../../../containers/tables/Format/Format';
import DialogBody from './FormatDialogBody';


const Format = () => {
    const Format = FormatContainer(DataFieldsInfo, DialogBody);

    return <Format />
    
}

export default Format;


