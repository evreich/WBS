import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import PropTypes from "prop-types";

import Paper from "material-ui/Paper";
import Typography from "material-ui/Typography";
import { withStyles } from "material-ui/styles";

import TextFieldPlaceholder from "../Commons/TextFields/TextFieldPlaceholder";
import ButtonPrimary from "../Commons/Buttons/ButtonPrimary";
import styles from "./AuthorizationForm.css";


class AuthorizationFormComponent extends Component {

    constructor(props) {
        super(props);
        this.state = {
            login: "",
            password: ""
        };
    }

    static getDerivedStateFromProps(nextProps) {
        return {
            access_token: nextProps.auth && nextProps.auth.access_token,
            refresh_token: nextProps.auth && nextProps.auth.refresh_token
        };
    }

    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    submmit = event => {
        event.preventDefault();
        const { getToken } = this.props;
        const { login, password } = this.state;
        const values = { login, password };
        getToken(values);
    };

    render() {
        const { classes, error } = this.props;
        const { access_token, refresh_token } = this.state;
        return access_token && refresh_token ? (
            <Redirect to={"/Home"} />
        ) : (
            <div>
                <Paper className={classes.root} elevation={4}>
                    <div className={classes.appFrame}>
                        <div className={classes.auth}>
                            <Typography
                                variant="headline"
                                component="h3"
                                style={{ textAlign: "center" }}
                            >
                                Авторизация
                            </Typography>
                            <Typography variant="subheading">
                                <form onSubmit={this.submmit}>
                                    <TextFieldPlaceholder
                                        muProps={{
                                            name: "login",
                                            type: "text",
                                            placeholder: "Введите логин",
                                            label: "Логин",
                                            onChange: this.handleChange,
                                            fullWidth: true
                                        }}
                                    />
                                    <TextFieldPlaceholder
                                        muProps={{
                                            name: "password",
                                            type: "password",
                                            placeholder: "Введите пароль",
                                            label: "Пароль",
                                            onChange: this.handleChange,
                                            fullWidth: true
                                        }}
                                    />
                                    {error && (
                                        <>
                                            <span style={{ color: "red" }}>
                                                {error}
                                            </span>
                                            <br />
                                        </>
                                    )}
                                    <ButtonPrimary text="Войти" type="submit" />
                                </form>
                            </Typography>
                        </div>
                    </div>
                </Paper>
            </div>
        );
    }
}

AuthorizationFormComponent.propTypes = {
    classes: PropTypes.object.isRequired,
    getToken: PropTypes.func,
    error: PropTypes.string
};

export default withStyles(styles)(AuthorizationFormComponent);