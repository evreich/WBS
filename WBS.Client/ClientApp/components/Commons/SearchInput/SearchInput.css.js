export default theme => ({
    textFieldInput: {
        borderRadius: 4,
        backgroundColor: "#9ccc65",
        color: "#fafafa",
        fontSize: 16,
        padding: "10px 12px 10px 40px",
        marginLeft: -40,
        marginTop: 3,
        height: 20,
        caretColor: "#fafafa",
        width: 150,
        transition: theme.transitions.create([
            "border-color",
            "width",
            "box-shadow"
        ]),
        "&:focus": {
            width: 200,
            backgroundColor: "#aed581"
        },
        "&:hover": {
            backgroundColor: "#aed581"
        }
    },
    textFieldFormLabel: {
        fontSize: 18
    },
    adornment: {
        zIndex: 1,
        padding: "12px 0"
    }
});
