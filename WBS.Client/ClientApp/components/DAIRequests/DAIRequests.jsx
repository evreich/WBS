import React, { Fragment } from 'react';
import NewRequestsTable from './NewRequestsTable';
import ProcessingTasksTable from './ProcessingTasksTable';

const DAIRequests = () => (
  <Fragment>
    <NewRequestsTable />
    <ProcessingTasksTable />
  </Fragment>
);

export default DAIRequests;
