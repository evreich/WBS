const styles = theme => ({
    root: theme.mixins.gutters({
        flexGrow: 1
        // maxWidth: '70%',
        // minHeight: 'calc(100vh - 160px)',
        // margin: 'auto',
        // padding: '10px'
    }),
    appFrame: {
        height: "calc(100vh - 64px)",
        zIndex: 1,
        overflow: "hidden",
        position: "relative",
        display: "flex",
        width: "100%"
    },
    auth: {
        width: "300px",
        position: "relative",
        margin: "auto"
    }
});

export default styles;
