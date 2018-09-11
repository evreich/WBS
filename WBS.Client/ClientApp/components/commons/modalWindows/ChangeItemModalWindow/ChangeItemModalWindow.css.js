const styles = () => ({
    dialogTitle: {
        display: "flex",
        justifyContent: "space-between",
        backgroundColor: "#296E50",
        "& div": { marginTop: 5, color: "white" }
    },
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
    container: { minWidth: "400px" }
});

export default styles;
