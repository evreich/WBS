const styles = () => ({
    btnSmall: {
        padding: "5px 6px",
        minWidth: "64px",
        fontSize: "0.6675rem",
        minHeight: "20px"
    },
    flexRow: {
        display: 'flex',
        width: 1200,
        justifyContent: "space-around"
    },
    flexColomn: {
        display: "flex",
        flexDirection: "column"
    },
    tabs: {
        flexDirection: "column",
        width: 1200,
        justifyContent: "space-around"
    },

    input: {
        display: "none"
    },
    dropzone: {
        width: "100%",
        height: "100px",
        border: "1px dashed gray",
        textAlign: "center",
        "&:hover": {
            cursor: "pointer"
        }
    },
    root: {
        width: "100%",
        marginTop: 50,
        paddingTop: 10
    },
    table: {
        minWidth: 800,
        tableLayout: "fixed"
    },
    tableWrapper: {
        overflowX: "auto"
    },
    header: {
        background: "linear-gradient(0deg, #f1f8e9, #fff)"
    },

    dialogTitle: {
        backgroundColor: "#296E50",
        "& div" : {
            display: "flex",
            justifyContent: "space-between",
            "& div": { marginTop: 5, color: "white" }
        }
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
    row: {},
    cell: {
        padding: "4px 16px 4px 14px"
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
    dialogField: { width: 300, marginTop: 20 },
    dialogBodyColumn: {
        width: 300,
        display: "flex",
        flexDirection: "column"
    },
    rationalForInvestFlexColumn: { width: 500, flexDirection: "column" },
    saveButton: {
        color: "white",
        background: "green",
        "&:hover": { background: "#045404", backgroundClip: "padding-box" }
    },
    cancelButton: {
        color: "white",
        background: "red",
        "&:hover": { background: "#b50606", backgroundClip: "padding-box" }
    },
});

export default styles;
