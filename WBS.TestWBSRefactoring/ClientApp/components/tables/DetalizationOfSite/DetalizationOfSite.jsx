import React from 'react';

import DataFieldsInfo from './DataFieldsInfo';
import DetalizationOfSiteContainer from '../../../containers/tables/DetalizationOfSite/DetalizationOfSite';
import DialogBody from './DetalizationOfSiteDialogBody';
import SearchDataForTable from './SearchDataForTable';
import { tableStyles } from "../../../components/tables/DetalizationOfSite/DetalizationOfSite.css";
import { QueryParamsContext } from '../DetalizationOfBudgetPlan/DetalizationOfBudgetPlan'
 
const DetalizationOfSite = () => {

    const DetalizationOfSite = DetalizationOfSiteContainer(DataFieldsInfo, DialogBody, tableStyles);
    return (
        <>
            <SearchDataForTable />
            <QueryParamsContext.Consumer>
                {queryParams => (
                    <DetalizationOfSite queryParams={queryParams} /> 
                )}   
            </QueryParamsContext.Consumer> 
        </>
    )
}
 
export default DetalizationOfSite;