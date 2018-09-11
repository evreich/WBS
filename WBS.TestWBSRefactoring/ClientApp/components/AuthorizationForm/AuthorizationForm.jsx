import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import PropTypes from "prop-types";

import Paper from "@material-ui/core/Paper"
import Typography from "@material-ui/core/Typography";
import { withStyles } from "@material-ui/core/styles";
import { Field, reduxForm, SubmissionError } from 'redux-form';

import TextFieldPlaceholder from "components/commons/textFields/TextFieldPlaceholder/TextFieldPlaceholder";
import ButtonPrimary from "../Commons/Buttons/ButtonPrimary";
import styles from "./AuthorizationForm.css";

class AuthorizationForm extends Component {
    static getDerivedStateFromProps(nextProps) {
        return {
            accessToken: nextProps.auth && nextProps.auth.accessToken,
            refreshToken: nextProps.auth && nextProps.auth.refreshToken
        };
    }

    submmit = (values) => {
        const errors = {}

        if (!values.login) {
            errors.login = '*Обязательное поле'
        }
        if (!values.password) {
            errors.password = '*Обязательное поле'
        }

        if (!(JSON.stringify(errors) === "{}")) {
            throw new SubmissionError(errors)
        }

        const { authorization } = this.props;
        authorization(values.login, values.password);
    }

    render() {
        const { classes, error, handleSubmit } = this.props;
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
                                    <form onSubmit={handleSubmit(this.submmit)}>
                                        <Field
                                            component={TextFieldPlaceholder}
                                            name="login"
                                            type="text"
                                            placeholder="Введите логин"
                                            label="Логин"
                                        />
                                        <Field
                                            component={TextFieldPlaceholder}
                                            name="password"
                                            type="password"
                                            placeholder="Введите пароль"
                                            label="Пароль"
                                        />
                                        {error && (
                                            <>
                                                <span style={{ color: "red" }}>
                                                    {error}
                                                </span>
                                                <br />
                                            </>
                                        )}
                                        <ButtonPrimary text="Войти" type="submit"/>
                                    </form>
                                </Typography>
                            </div>
                        </div>
                    </Paper>
                </div>
            );
    }
}

AuthorizationForm.propTypes = {
    classes: PropTypes.object.isRequired,
    handleSubmit: PropTypes.func,
    authorization: PropTypes.func,
    error: PropTypes.string
};

export default reduxForm({ form: 'authorization' })(
    withStyles(styles)(AuthorizationForm)
);