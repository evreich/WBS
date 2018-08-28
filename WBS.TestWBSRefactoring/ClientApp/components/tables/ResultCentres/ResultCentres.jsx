import React from "react";

import DataFieldsInfo from './DataFieldsInfo';
import ResultCentresContainer from '../../../containers/tables/ResultCentres/ResultCentres';
import DialogBody from './ResultCentresDialogBody';
import { tableStyles } from '../tableLayoutAuto.css';


const ResultCentres = () => {
    const ResultCentres = ResultCentresContainer(DataFieldsInfo, DialogBody, tableStyles);

    return <ResultCentres />
    
}

export default ResultCentres;


