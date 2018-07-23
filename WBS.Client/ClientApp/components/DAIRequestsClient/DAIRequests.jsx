import React, { Fragment } from 'react';
import NewRequestsTable from './NewRequestsTable/NewRequestsTable';
import ProcessingTasksTable from './ProcessingTasksTable/ProcessingTasksTable';

const DAIRequests = () => (
  <Fragment>
    <NewRequestsTable />
    <ProcessingTasksTable />
  </Fragment>
);

export default DAIRequests;
