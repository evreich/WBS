import { createMuiTheme } from '@material-ui/core/styles';

const theme = createMuiTheme({
    palette: {
        primary: {
            light: '#296E50',
            main: '#095539',
            dark: '#	003D23',
            contrastText: '#fafafa',
        },
        secondary: {
            light: '#ff5e4c',
            main: '#ed1a21',
            dark: '#b20000',
            contrastText: '#fafafa',
        },
    },
});

export default theme;