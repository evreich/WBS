const styles = () => ({
    btnSmall: {
        padding: '5px 6px',
        minWidth: '64px',
        fontSize: '0.6675rem',
        minHeight: '20px'
    },
    flexRow: {
        width: 1200,
        justifyContent: 'space-around'
    },
    flexColomn: {
        display: 'flex',
        flexDirection: 'column'
    },
    tabs: {
        flexDirection: 'column',
        width: 1200,
        justifyContent: 'space-around'
    },
    root: {
        width: '100%',
        marginTop: 50,
        paddingTop: 10,
    },
    table: {
        minWidth: 800,
        tableLayout: 'fixed',
    },
    tableWrapper: {
        overflowX: 'auto',
    },
    header: {
        background: 'linear-gradient(0deg, #f1f8e9, #fff);',
    },
    rowHover: {
        cursor: 'pointer',
        '&:nth-of-type(odd)': {
            backgroundColor: '#fafafa',
        },
        '&:hover': {
            backgroundColor: '#eee',
        },
    },
    row: {},
    cell: {
        padding: '4px 16px 4px 14px',
    },
    appBar: {
        position: 'relative',
    },
    flex: {
        flex: 1,
    },
    radio: {
        height: 25,
    },
    checkbox: {
        height: 24,
    },
})

export default styles