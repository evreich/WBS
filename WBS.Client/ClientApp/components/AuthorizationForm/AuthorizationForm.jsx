import React, { Component } from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import PropTypes from "prop-types";
import { withStyles } from "material-ui/styles";
import Paper from "material-ui/Paper";
import Typography from "material-ui/Typography";
import TextFieldPlaceholder from "../Commons/TextFields/TextFieldPlaceholder";
import ButtonPrimary from "../Commons/Buttons/ButtonPrimary";
import actionsCreators from "../../reducers/Authorization";
import styles from "./AuthorizationForm.css";

class PaperSheet extends Component {
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
        const { authorization } = this.props;
        const { login, password } = this.state;
        const values = { login, password };
        authorization(values);
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
                                            onChange: this.handleChange
                                        }}
                                    />
                                    <TextFieldPlaceholder
                                        muProps={{
                                            name: "password",
                                            type: "password",
                                            placeholder: "Введите пароль",
                                            label: "Пароль",
                                            onChange: this.handleChange
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

PaperSheet.propTypes = {
    classes: PropTypes.object.isRequired,
    authorization: PropTypes.func,
    error: PropTypes.string
};

const mapStateToProps = state => ({ auth: state.auth });
const mapDispatchToProps = { ...actionsCreators };

export default withStyles(styles)(
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(PaperSheet)
);
