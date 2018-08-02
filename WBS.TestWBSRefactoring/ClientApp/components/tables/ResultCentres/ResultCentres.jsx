import React from "react";

import DataFieldsInfo from './DataFieldsInfo';
import ResultCentresContainer from '../../../containers/tables/ResultCentres/ResultCentres';
import DialogBody from './ResultCentresDialogBody';
import { tableStyles } from './ResultCentres.css';


const ResultCentres = () => {
    const ResultCentres = ResultCentresContainer(DataFieldsInfo, DialogBody, tableStyles);

    return <ResultCentres />
    
}

export default ResultCentres;


