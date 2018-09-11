import React from "react";

import DataFieldsInfo from './DataFieldsInfo';
import ProvidersContainer from 'containers/tables/Providers/Providers';
import DialogBody from './ProvidersDialogBody';
import { tableStyles } from '../tableLayoutAuto.css';
import ProviderTableRow from './ProviderTableRow';


const Providers = () => {
    const Providers = ProvidersContainer(DataFieldsInfo, DialogBody, ProviderTableRow, tableStyles);

    return <Providers />

}

export default Providers;


