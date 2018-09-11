const styles = () => ({
    dialogTitle: {
        display: "flex",
        justifyContent: "space-between"
    },
    saveButton: {
        color: "white",
        background: "green",
        "&:hover": { background: "#045404", backgroundClip: "padding-box" }
    },
    cancelButton: {
        float: "right"
    },
    header: {
        marginTop: 5
    },
    container: { minWidth: "400px" }
});

export default styles;