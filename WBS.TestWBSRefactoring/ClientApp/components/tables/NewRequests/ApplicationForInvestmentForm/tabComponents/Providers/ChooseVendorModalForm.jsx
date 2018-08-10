import React from "react";
import PropTypes from "prop-types";

import Dialog, { DialogContent, DialogTitle } from "material-ui/Dialog";
import Paper from "material-ui/Paper";
import Clear from "material-ui-icons/Clear";
import IconButton from "material-ui/IconButton";

import { SortingActions } from "../../../../../../constants/sortingActions";
import { sortOn } from "../../../../../../helpers/sortinngFunctions";
import ProvidersTable from "./ProvidersTable";
import Filters from "./Filters";

class ChooseVendorModalForm extends React.Component {
    componentDidMount() {
        const { getDataTable } = this.props;
        getDataTable();
    }

    handleChangePage = (event, page) => {
        const {
            getDataTable,
            changeVendorsPagination,
            paginationData
        } = this.props;
        changeVendorsPagination({ ...paginationData, currentPage: page });
        getDataTable();
    };

    handleChangeRowsPerPage = event => {
        const {
            getDataTable,
            changeVendorsPagination,
            paginationData
        } = this.props;
        changeVendorsPagination({
            ...paginationData,
            elementsPerPage: event.target.value
        });
        getDataTable();
    };

    handleRequestSort = (event, property) => {
        const { sortingData, changeVendorsSorting } = this.props;
        let newOrder = SortingActions.SORT_DESC;

        if (
            sortingData.sortBy === property &&
            sortingData.sort === SortingActions.SORT_DESC
        ) {
            newOrder = SortingActions.SORT_ASC;
        }

        const newData = this.sortData(property, newOrder);
        changeVendorsSorting({ sort: newOrder, sortBy: property }, newData);
    };

    sortData = (property, order) => {
        const { data } = this.props;

        //if sorting on field with type STRING
        return data.sort(sortOn(property, "string", order));
    };

    cancel = () => {
        const { onClose } = this.props;
        onClose();
    };

    add = item => {
        const { onAdd, onClose } = this.props;
        onAdd(item);
        onClose();
    };

    render() {
        const {
            data,
            sortingData,
            paginationData,
            getDataTable,
            getFilteredDataTable,
            technicalServs
        } = this.props;
        const { currentPage, elementsPerPage, elementsCount } = paginationData;
        const emptyRows =
            elementsPerPage -
            Math.min(
                elementsPerPage,
                elementsCount - currentPage * elementsPerPage
            );
        const actions = {
            handleRequestSort: this.handleRequestSort,
            handleChangePage: this.handleChangePage,
            handleChangeRowsPerPage: this.handleChangePage
        };
        return (
            <Dialog open={true} maxWidth={"md"} onClose={this.cancel}>
                <DialogTitle id="form-dialog-choose">
                    <div
                        style={{
                            display: "flex",
                            justifyContent: "space-between"
                        }}
                    >
                        <div style={{ marginTop: 5 }}> Выбор поставщиков </div>
                        <IconButton
                            style={{ float: "right" }}
                            color="secondary"
                            onClick={this.cancel}
                        >
                            <Clear />
                        </IconButton>
                    </div>
                </DialogTitle>
                <DialogContent>
                    <Filters
                        technicalServs={technicalServs}
                        applyFilter={getFilteredDataTable}
                        reset={getDataTable}
                    />
                    <Paper>
                        <ProvidersTable
                            data={data}
                            sortingData={sortingData}
                            paginationData={paginationData}
                            emptyRows={emptyRows}
                            actions={actions}
                            add={this.add}
                        />
                    </Paper>
                </DialogContent>
            </Dialog>
        );
    }
}

ChooseVendorModalForm.propTypes = {
    onAdd: PropTypes.func.isRequired,
    onClose: PropTypes.func.isRequired,
    handleDeleteButtonClick: PropTypes.func,
    handleUpdateButtonClick: PropTypes.func,
    changeVendorsSorting: PropTypes.func.isRequired,
    sortingData: PropTypes.object.isRequired,
    data: PropTypes.array.isRequired,
    paginationData: PropTypes.object.isRequired,
    getDataTable: PropTypes.func.isRequired,
    changeVendorsPagination: PropTypes.func.isRequired,
    getFilteredDataTable: PropTypes.func.isRequired,
    technicalServs: PropTypes.array
};

