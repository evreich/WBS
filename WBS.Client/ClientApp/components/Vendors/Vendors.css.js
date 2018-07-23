const styles = theme => ({
  head: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  root: {
    maxWidth: '70%',
    margin: '0 auto',
    padding: '10px'
  },
  table: {
    minWidth: 500,
  },
  tableWrapper: {
    overflowX: 'auto',
  },
  updateCell: {
    transition: '10s'
  },
  GrundCell: {
    width: 'calc(100%-134px)'
  },
  createRow:{
    height:'70px'
  }
});

export default styles