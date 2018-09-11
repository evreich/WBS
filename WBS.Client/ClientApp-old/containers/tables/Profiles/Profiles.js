import { connect } from "react-redux";

import CreateTable from "components/Commons/Table";
import {
    getTable,
    clearTable,
    updateTable,
    changeData,
} from "../tablesActions";
import { markOnDeleteData } from './profileActions';

const TABLE = "profiles";
const ROUTE = document.api.profiles;
const ROUTE_MARK_ON_DELETE_PROFILE = document.api.markProfileForDeletion;

const mapStateToProps = state => 
    (state.tables[TABLE]
        ? {
              ...state.tables[TABLE]
              //TODO: send server error in form from redux store
              //errors: state.tables[TABLE].errors
          }
        : {});

const mapDispatchToProps = dispatch => ({
    getDataTable: (pageIndex, pageSize) =>
        dispatch(getTable(pageIndex, pageSize, ROUTE, TABLE)),
    clearTable: () => dispatch(clearTable(TABLE)),
    updateTable: data => dispatch(updateTable(data, TABLE)),
    changeData: (pageIndex, pageSize, method, data) =>
        dispatch(changeData(pageIndex, pageSize, method, data, ROUTE, TABLE)),
    deleteData: (pageIndex, pageSize, data) => dispatch(markOnDeleteData(pageIndex, pageSize, data, ROUTE, ROUTE_MARK_ON_DELETE_PROFILE, TABLE))
});

const ProfilesContainer = (
    dataFields,
    ProfilesAddItemDialogBody,
    ProfilesEditItemDialogBody,
    ProfilesInformationForm,
    ProviderTableRow
) =>
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(
        CreateTable({
            dataFiledsInfo: dataFields,
            AddItemDialogBodyComponent: ProfilesAddItemDialogBody,
            ChangeItemDialogBodyComponent: ProfilesEditItemDialogBody,
            RowComponent: ProviderTableRow,
            InformationModalWindow: ProfilesInformationForm, 
            title: TABLE
        })
    );

export default ProfilesContainer;
