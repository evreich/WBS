const drawerWidth = 320;
const duration = 100;

export default theme => ({
    root: {
        flexGrow: 1,
    },
    link: {
        textDecoration: 'none',
    },
    appFrame: {
        height: '100%',
        zIndex: 1,
        overflow: 'hidden',
        position: 'relative',
        display: 'flex',
        width: '100%',
    },
    appBar: {
        position: 'absolute',
        transition: theme.transitions.create(['margin', 'width'], {
            easing: theme.transitions.easing.sharp,
            duration,
        }),
    },
    appBarShift: {
        width: `calc(100% - ${drawerWidth + 9}px)`,
        marginLeft: drawerWidth,
        transition: theme.transitions.create(['margin', 'width'], {
            easing: theme.transitions.easing.easeOut,
            duration,
        }),
    },
    menuButton: {
        marginLeft: -12,
        marginRight: 20,
    },
    hide: {
        display: 'none',
    },
    drawerPaper: {
        position: 'relative',
        width: drawerWidth,
        overflowY: 'overlay',
    },
    drawerHeader: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'space-between',
        padding: '0 8px',
        ...theme.mixins.toolbar,
    },
    content: {
        flexGrow: 1,
        marginLeft: 0,
        height: '100%',
        backgroundColor: theme.palette.background.default,
        padding: theme.spacing.unit * 3,
        transition: theme.transitions.create('margin', {
            easing: theme.transitions.easing.sharp,
            duration,
        }),

    },
    contentShift: {
        marginLeft: drawerWidth,
        minWidth: 800,
        transition: theme.transitions.create('margin', {
            easing: theme.transitions.easing.easeOut,
            duration,
        }),
    },
    nested: {
        marginLeft: theme.spacing.unit * 4.5,
        paddingLeft: theme.spacing.unit * 2.5,
        borderLeft: '2px solid rgba(0, 0, 0, 0.08)',
    },
});