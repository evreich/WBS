import React from "react";

import DataFieldsInfo from './DataFieldsInfo';
import NewRequestsContainer from '../../../containers/tables/NewRequests/NewRequests';
import CreateNewRequest from './ApplicationForInvestmentForm';

const NewRequests = () => {
    const NewRequests = NewRequestsContainer(DataFieldsInfo, CreateNewRequest);

    return <NewRequests />
}

export default NewRequests;


