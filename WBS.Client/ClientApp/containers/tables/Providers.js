import { connect } from "react-redux";

import CreateTable from "factories/Table";
import ModalWindow from "../modalWindows/ProviderModalWindow";
//import ProviderTableRow from "components/tableRows/ProviderTableRow";
import {
    getTable,
    clearTable,
    updateTable,
    changeData,
    deleteData,
    setUpdatingItem,
    clearUpdatingItem,
    getPermissions
} from 'actions/tablesActions';
import { tableStyles } from 'stylesheets/tableLayoutAuto.css';
import metaData from 'constants/tablesMetaData/providersMetaData'
import api from 'constants/api';
import objectTypes from 'constants/objectTypes';

const TABLE = "providers";
const ROUTE = api.providers;

const mapStateToProps = state => {
    const props = (state.tables[TABLE] && state.tables[TABLE].data && state.tables[TABLE].permissions ?
        {
            //...state.tables[TABLE],
            data: state.tables[TABLE].data.map(item => ({
                ...item,
                permissions: { ...state.tables[TABLE].permissions },
                providersTechnicalServices: item.providersTechnicalServices.map(p => p.title).join(", ")
            })),
            pagination: state.tables[TABLE].pagination,
            accessToCreate: true
            /*data: state.tables[TABLE].data.map(item => ({ ...item, permissions: { ...state.tables[TABLE].permissions} })),
            pagination: state.tables[TABLE].pagination,
            accessToCreate: state.tables[TABLE].permissions.accessToCreate*/

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
    clearUpdatingItem: () => dispatch(clearUpdatingItem(TABLE)),
    getPermissions: () => dispatch(getPermissions(TABLE, objectTypes.provider))
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(
    CreateTable({
        metaData,
        title: TABLE,
        tableStyles: tableStyles,
        //RowComponent: ProviderTableRow,
        ChangeItemModalWindow: ModalWindow
    })
);
