import { connect } from "react-redux";

import CreateTable from "factories/Table";
import ProviderTableRow from "components/tableRows/ProviderTableRow";
import {
    getTable,
    clearTable,
    updateTable,
    changeData,
    deleteData,
    setUpdatingItem,
    clearUpdatingItem
} from 'actions/tablesActions';
import { tableStyles } from 'stylesheets/tableLayoutAuto.css';
import descriptors from "descriptors/providersDescriptors";
import api from 'constants/api';

const TABLE = "providers";
const ROUTE = api.providers;

const mapStateToProps = state => {
    const props = (state.tables[TABLE] ?
        {
            ...state.tables[TABLE],
            //TODO: send server error in form from redux store
            //errors: state.tables[TABLE].errors
        } : {});
    if (state.tables[TABLE] && state.tables[TABLE].updatingItem)
        props.modalFormInitialValues = state.tables[TABLE].data
            .find((item) => item.id === state.tables[TABLE].updatingItem)
    return props;
}

//TODO: ����������� ���� � �� �� - �������?
const mapDispatchToProps = (dispatch) => ({
    getDataTable: (pageIndex, pageSize, queryParams) => dispatch(getTable(pageIndex, pageSize, ROUTE, TABLE, queryParams)),
    clearTable: () => dispatch(clearTable(TABLE)),
    updateTable: (data) => dispatch(updateTable(data, TABLE)),
    changeData: (pageIndex, pageSize, method, data) => dispatch(changeData(pageIndex, pageSize, method, data, ROUTE, TABLE)),
    deleteData: (pageIndex, pageSize, data) => dispatch(deleteData(pageIndex, pageSize, data, ROUTE, TABLE)),
    setUpdatingItem: (updatingItemId) => dispatch(setUpdatingItem(updatingItemId, TABLE)),
    clearUpdatingItem: () => dispatch(clearUpdatingItem(TABLE))
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(
    CreateTable({
        dataFiledsInfo: descriptors,
        title: TABLE,
        tableStyles: tableStyles,
        RowComponent: ProviderTableRow
    })
);
