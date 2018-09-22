
export const styles = {
    root: {
        width: "80%",
        marginTop: 50,
        marginLeft: "10%",
        paddingTop: 10,
        overflowX: "auto"
    },
    cell: {
        padding: "4px 16px 4px 14px"
    },
    actionsCell: {
        width: "90px"
    },
    table: {
        minWidth: 800,
        tableLayout: "fixed"
    },
    tableWrapper: {
        overflowX: "auto"
    },
    header: {
        background: "linear-gradient(0deg, #f1f8e9, #fff);"
    },
    footer: {
        fontSize: "14px"
    },
    rowHover: {
        cursor: "pointer",
        "&:nth-of-type(odd)": {
            backgroundColor: "#fafafa"
        },
        "&:hover": {
            backgroundColor: "#eee"
        }
    },
    operationCell: {
        padding: "4px"
    },
    flexRow: {
        paddingTop: 10,
        paddingBottom: 10,
        width: "100%",
        justifyContent: "space-between",
        display: "flex"
    },
    appBar: {
        position: "relative"
    },
    flex: {
        flex: 1
    },
    radio: {
        height: 25
    },
    checkbox: {
        height: 24
    },
    tooltip: {
        borderEadius: 10
    }
};
