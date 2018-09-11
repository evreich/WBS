import React from "react";
import PropTypes from "prop-types";

import TextFieldMultiline from "../../Commons/TextFields/TextFieldMultiline";
import TextFieldMultiSelect from "../../Commons/TextFields/TextFieldMultiSelect";
import TextFieldPlaceholder from "../../Commons/TextFields/TextFieldPlaceholder";
import transformFieldsToState from "helpers/transformFieldsToState";
import { getRolesForSelect } from "../helpersAPI";

class ProfilesAddItemDialogBody extends React.PureComponent {
    constructor(props) {
        super(props);
        const fields = transformFieldsToState(Object.values(props.formFields));

        this.state = {
            id: 0,
            allRoles: [],
            submitted: false,
            ...fields
        };
    }

    static propTypes = {
        errors: PropTypes.object,
        data: PropTypes.object,
        onRef: PropTypes.func,
        formFields: PropTypes.object
    };

    //lifecycles
    static getDerivedStateFromProps(nextProps) {
        return nextProps && nextProps.data
            ? {
                  ...nextProps.data,
                  roles: nextProps.data.roles.map(elem => elem.title)
              }
            : null;
    }

    componentDidMount() {
        const onRef = this.props.onRef;
        //связываем с родительским компонентом,
        //чтобы он имел доступ к методам дочернего компонента
        onRef(this);
        getRolesForSelect(this.setAllRoles, this.showError);
    }

    setAllRoles = data => {
        this.setState({
            allRoles: data
        });
    };

    showError = () => {};

    getDataToSave = () => {
        const {
            roles,
            login,
            password,
            fio,
            department,
            jobPosition,
            id,
            allRoles
        } = this.state;

        this.setState({ submitted: true });
        if (fio !== "" && password !== "")
            return {
                roles: allRoles.filter(item => roles.includes(item.title)),
                login,
                password,
                fio,
                department,
                jobPosition,
                id
            };
    };

    //handlers
    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    render() {
        const { errors, formFields } = this.props;
        const {
            login,
            password,
            fio,
            department,
            jobPosition,
            roles,
            allRoles,
            submitted
        } = this.state;
        const {
            login: loginName,
            password: passwordName,
            fio: fioName,
            department: departmentName,
            jobPosition: jobPositionName,
            roles: rolesName
        } = formFields;

        return (
            <>
                <TextFieldMultiline
                    muProps={{
                        name: fioName.propName,
                        label: fioName.label,
                        value: fio,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <div>
                    {submitted &&
                        !fio && (
                            <div style={{ color: "red" }}>
                                *Поле обязательно для заполнения
                            </div>
                        )}
                </div>
                <TextFieldPlaceholder
                    muProps={{
                        name: loginName.propName,
                        label: loginName.label,
                        value: login,
                        type: "text",
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldMultiline
                    muProps={{
                        name: jobPositionName.propName,
                        label: jobPositionName.label,
                        value: jobPosition,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldMultiline
                    muProps={{
                        name: departmentName.propName,
                        label: departmentName.label,
                        value: department,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldMultiSelect
                    muProps={{
                        name: rolesName.propName,
                        label: rolesName.label,
                        value: roles,
                        onChange: this.handleChange
                    }}
                    items={allRoles && allRoles.map(ts => ts.title)}
                />
                <TextFieldPlaceholder
                    muProps={{
                        name: passwordName.propName,
                        label: passwordName.label,
                        value: password,
                        type: "password",
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <div>
                    {submitted &&
                        !password && (
                            <div style={{ color: "red" }}>
                                *Поле обязательно для заполнения
                            </div>
                        )}
                </div>

                {/*TODO: VALIDATION */}
                {errors && <span style={{ color: "red" }}>{errors}</span>}
            </>
        );
    }
}

export default ProfilesAddItemDialogBody;
