const styles = () => ({
    dialogTitle: {
        backgroundColor: "#296E50",
        "& div": {
            display: "flex",
            justifyContent: "space-between",
            marginTop: 5,
            color: "#fafafa"
        }
    },
    dialogContent: {
        marginTop: "2%",
        fontSize: "20px",
        fontFamily: '"Roboto", "Helvetica", "Arial", sans-serif'
    },
    row: { height: "55px" },
    cellValue: { fontWeight: "bolder" },
    deleteButton: {
        marginLeft: "25%",
        marginRight: "5%"
    },
    submitButton: {
        backgroundColor: "#296e50",
        color: "white",
        "&:hover": {
            backgroundColor: "#1b4634"
        }
    }
});

export default styles;
