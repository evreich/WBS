import { lighten } from 'material-ui/styles/colorManipulator';

export const toolbarStyles = theme => ({
  root: {
    paddingRight: theme.spacing.unit,
  },
  highlight:
    theme.palette.type === 'light'
      ? {
        color: theme.palette.secondary.main,
        backgroundColor: lighten(theme.palette.secondary.light, 0.85),
      }
      : {
        color: theme.palette.text.primary,
        backgroundColor: theme.palette.secondary.dark,
      },
  spacer: {
    flex: '1 1 100%',
  },
  actions: {
    color: theme.palette.text.secondary,
  },
  title: {
    display: 'flex',
    alignItems: 'center',
    flex: '0 0 auto',
  },
});

export const styles = () => ({
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
  row: {
  },
  cell: {
    padding: '4px 16px 4px 14px',
  },
  flexRow: {
    paddingTop: 10,
    paddingBottom: 10,
    width: '100%',
    justifyContent: 'space-between',
    display: 'flex'
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
});