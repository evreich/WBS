import React from 'react';
import DataFieldsInfo from './DataFieldsInfo';
import DetalizationOfSiteContainer from '../../../containers/tables/DetalizationOfSite/DetalizationOfSite';
import DialogBody from './DetalizationOfSiteDialogBody';
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