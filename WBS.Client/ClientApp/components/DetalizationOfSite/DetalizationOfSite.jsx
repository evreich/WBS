import React from 'react';
import DataFieldsInfo from './DataFieldsInfo';
import DetalizationOfSiteContainer from '../../containers/DetalizationOfSite/DetalizationOfSite';
import DialogBody from '../../containers/DetalizationOfSite/DialogBody';
import SearchDataForTable from './SearchDataForTable';

const DetalizationOfSite = () => {
    const DetalizationOfSite = DetalizationOfSiteContainer(DataFieldsInfo, DialogBody);

    return (
        <>
            <SearchDataForTable />
            <DetalizationOfSite />
        </>
    )
}

export default DetalizationOfSite;


