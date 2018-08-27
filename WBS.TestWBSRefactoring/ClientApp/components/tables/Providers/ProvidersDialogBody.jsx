import React from "react";
import PropTypes from "prop-types";

import TextFieldMultiline from "../../Commons/TextFields/TextFieldMultiline";
import TextFieldMultiSelect from "../../Commons/TextFields/TextFieldMultiSelect";
import transformFieldsToState from "helpers/transformFieldsToState";
import { getTechnicalServs } from "../helpersAPI";

class ProvidersDialogBody extends React.PureComponent {
    constructor(props) {
        super(props);
        const fields = transformFieldsToState(Object.values(props.formFields));

        this.state = {
            id: 0,
            technicalServs: [],
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
                  profiles: nextProps.data.profiles.map(elem => elem.title)
              }
            : null;
    }

    componentDidMount() {
        const onRef = this.props.onRef;
        //связываем с родительским компонентом,
        //чтобы он имел доступ к методам дочернего компонента
        onRef(this);
        getTechnicalServs(this.setTechnicalServs, this.showErrors);
    }

    setTechnicalServs = data =>
        this.setState({
            technicalServs: data
        });

    showErrors = () => {};

    getDataToSave = () => {
        const { profiles, title, id, technicalServs } = this.state;
        return {
            profiles: technicalServs.filter(item =>
                profiles.includes(item.title)
            ),
            title,
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
        const { profiles, title, technicalServs } = this.state;
        const { profiles: profilesName, title: titleName } = formFields;

        return (
            <>
                <TextFieldMultiline
                    muProps={{
                        name: titleName.propName,
                        label: titleName.label,
                        value: title,
                        onChange: this.handleChange,
                        fullWidth: true
                    }}
                />
                <TextFieldMultiSelect
                    muProps={{
                        name: profilesName.propName,
                        label: profilesName.label,
                        value: profiles,
                        onChange: this.handleChange
                    }}
                    items={technicalServs && technicalServs.map(ts => ts.title)}
                />

                {/*TODO: VALIDATION */}
                {errors && <span style={{ color: "red" }}>{errors}</span>}
            </>
        );
    }
}

export default ProvidersDialogBody;
