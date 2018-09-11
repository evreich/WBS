import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import PropTypes from "prop-types";

import Paper from "@material-ui/core/Paper"
import Typography from "@material-ui/core/Typography";
import { withStyles } from "@material-ui/core/styles";

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
            accessToken: nextProps.auth && nextProps.auth.accessToken,
            refreshToken: nextProps.auth && nextProps.auth.refreshToken
        };
    }

    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    submmit = (event) => {
        event.preventDefault();
        const { authorization } = this.props;
        const { login, password } = this.state;
        authorization(login, password);
    }

    render() {
        const { classes, error } = this.props;
        const { accessToken, refreshToken } = this.state;
        return accessToken && refreshToken ? (
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
    authorization: PropTypes.func,
    error: PropTypes.string
};

export default withStyles(styles)(AuthorizationFormComponent);