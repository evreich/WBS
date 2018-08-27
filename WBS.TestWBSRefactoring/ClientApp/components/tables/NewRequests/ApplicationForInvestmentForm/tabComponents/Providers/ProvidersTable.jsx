import React from "react";
import PropTypes from 'prop-types';

import DataFieldsInfo from './DataFieldsInfo';
import ProvidersContainer from 'containers/tables/Providers/Providers';
import ProviderTableRow from './ProviderTableRow';
import QueryParamsContext from "./QueryParamsContext";

const ProvidersTable = ({classes }) => {
    const TableRow = ({ row, classes }) => (<QueryParamsContext.Consumer>
        {value => (
            <ProviderTableRow add={value.add} row={row} classes={classes} />
        )}
    </QueryParamsContext.Consumer>)

    TableRow.propTypes = {
        classes: PropTypes.object.isRequired,
        row: PropTypes.object.isRequired
    }

    const Providers = ProvidersContainer(DataFieldsInfo, null, TableRow, classes);

    return <QueryParamsContext.Consumer>
        {value => (
            <Providers queryParams={value.queryParams} showToolbar={value.showToolbar} classes={classes}/>
        )}
    </QueryParamsContext.Consumer>

}

ProvidersTable.propTypes = {
    classes: PropTypes.object
}

export default ProvidersTable;
