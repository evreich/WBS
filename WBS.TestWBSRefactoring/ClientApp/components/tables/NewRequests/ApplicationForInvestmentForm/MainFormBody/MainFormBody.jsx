import React from "react";
import PropTypes from "prop-types";

import Divider from "@material-ui/core/Divider";

import Radio from "../../../../Commons/Radio/Radio";
import DatePicker from "../../../../Commons/DatePicker";
import Checkbox from "../../../../Commons/Checkbox/Checkbox";
import TextFieldSelect from "../../../../Commons/TextFields/TextFieldSelect";
import TextFieldPlaceholder from "../../../../Commons/TextFields/TextFieldPlaceholder";
import transformFieldsToState from "../../../../../helpers/transformFieldsToState";
import {
    getSites,
    getResultCentres,
    getTechnicalServs
} from "../../../helpersAPI";

class MainFormBody extends React.PureComponent {
    constructor(props) {
        super(props);
        this.fields = transformFieldsToState(Object.values(props.formFields));

        this.state = {
            id: 0,
            isShowTechServs: "false",
            sits: [],
            resultCentres: [],
            technicalServs: [],
            ...this.fields
        };
    }

    static propTypes = {
        errors: PropTypes.object,
        data: PropTypes.object,
        onRef: PropTypes.func,
        formFields: PropTypes.object,
        classes: PropTypes.object
    };

    static getDerivedStateFromProps(nextProps) {
        if (nextProps.data) {
            const isShowTechServs =
                nextProps.data.technicalServices.length > 0 ? "true" : "false";

            return { ...nextProps.data, isShowTechServs };
        } else return null;
    }

    setSites = data =>
        this.setState({
            sits: data
        });

    setResultCentres = data =>
        this.setState({
            resultCentres: data
        });

    setTechServs = data => {
        const technicalServicesFromProps =
            this.props.data && this.props.data.technicalServices;

        const technicalServs = data
            .map(serv_elem => {
                const checked = technicalServicesFromProps
                        ? technicalServicesFromProps.find(
                            prop_elem => prop_elem.title === serv_elem.title
                        )
                            ? true
                            : false
                        : false;
                        
                    return { ...serv_elem, checked };
            })
            .reduce((accum, currValue) => ({...accum, [currValue.title] : currValue }), {});

        this.setState({ technicalServs });
    };

    showError = () => {};

    componentDidMount() {
        const onRef = this.props.onRef;
        //связываем с родительским компонентом,
        //чтобы он имел доступ к методам дочернего компонента
        onRef(this);

        getSites(this.setSites, this.showError);
        getResultCentres(this.setResultCentres, this.showError);
        getTechnicalServs(this.setTechServs, this.showError);
    }

    getDataToSave = () => {
        const {
            number,
            directorApprovalDate,
            siteId,
            resultCentreId,
            deliveryTime,
            technicalServs,
        } = this.state;
        const technicalServices = Object.values(technicalServs)
            .filter(item =>
                item.checked
            )
            .map(item => ({ id: item.id, title: item.title}) )
        return {
            number,
            directorApprovalDate,
            siteId,
            resultCentreId,
            deliveryTime,
            technicalServices
        };
    };

    //handlers
    handleChange = e => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    };

    handleChangeRadio = event => {
        this.setState({ isShowTechServs: event.target.value });
    };

    handleDateChange = name => date => {
        this.setState({ [name]: date });
    };
    handleChangeCheckbox = name => event => {
        event.persist();
        this.setState(prevState => {
            const technicalServs = {...prevState.technicalServs};
            technicalServs[name].checked = event.target.checked;

            return { technicalServs };
        });
    };

    render() {
        const { errors, formFields, classes } = this.props;
        const {
            number,
            directorApprovalDate,
            siteId,
            resultCentreId,
            deliveryTime,
            sits,
            resultCentres,
            technicalServs,
            isShowTechServs
        } = this.state;

        const {
            number: numberName,
            directorApprovalDate: directorApprovalDateName,
            siteId: siteIdName,
            resultCentreId: resultCentreIdName,
            deliveryTime: deliveryTimeName,
            technicalServices: technicalServsName
        } = formFields;

        return (
            <>
                <div className={classes.flexRow}>
                    <TextFieldPlaceholder
                        muProps={{
                            name: numberName.propName,
                            label: numberName.label,
                            value: number,
                            type: "number",
                            onChange: this.handleChange,
                            disabled: true,
                            style: { width: 300 }
                        }}
                    />
                    <DatePicker
                        name={directorApprovalDateName.propName}
                        label={directorApprovalDateName.label}
                        value={directorApprovalDate || null}
                        disabled={true}
                        onChange={this.handleDateChange(
                            directorApprovalDateName.propName
                        )}
                        style={{ width: 300, marginTop: "15px" }}
                    />
                    <TextFieldPlaceholder
                        muProps={{
                            name: "",
                            label: "Текущий этап",
                            value: "",
                            type: "number",
                            onChange: this.handleChange,
                            disabled: true,
                            style: { width: 300, color: "#296E50" }
                        }}
                    />
                </div>
                <div className={classes.flexRow}>
                    <div className={classes.flexColomn}>
                        <TextFieldSelect
                            muProps={{
                                name: siteIdName.propName,
                                label: siteIdName.label,
                                value: siteId,
                                onChange: this.handleChange,
                                style: { width: 300, marginLeft: 0 }
                            }}
                            items={
                                sits &&
                                sits.map(elem => ({
                                    value: elem.id,
                                    text: elem.title
                                }))
                            }
                        />
                        <TextFieldPlaceholder
                            muProps={{
                                name: "",
                                label: "Ответственный в сите",
                                value: "",
                                onChange: this.handleChange,
                                disabled: true,
                                style: { width: 300 }
                            }}
                        />
                    </div>
                    <div className={classes.flexColomn}>
                        <TextFieldSelect
                            muProps={{
                                name: resultCentreIdName.propName,
                                label: resultCentreIdName.label,
                                value: resultCentreId,
                                onChange: this.handleChange,
                                style: { width: 300, marginLeft: 0 }
                            }}
                            items={
                                resultCentres &&
                                resultCentres.map(elem => ({
                                    value: elem.id,
                                    text: elem.title
                                }))
                            }
                        />
                        <DatePicker
                            name={deliveryTimeName.propName}
                            label={deliveryTimeName.label}
                            value={deliveryTime ? deliveryTime : null}
                            onChange={this.handleDateChange(
                                deliveryTimeName.propName
                            )}
                            style={{ width: 300, marginTop: "16px" }}
                        />
                    </div>
                    <div className={classes.dialogBodyColumn}>
                        <Radio
                            label={
                                <>
                                    <span>Ariba </span>
                                    <a style={{ color: "#ed1a21" }} href="#">
                                        запустить
                                    </a>
                                </>
                            }
                            checked={isShowTechServs === "false"}
                            value={"false"}
                            style={{ marginTop: 12 }}
                            radioStyle={{ height: 25 }}
                            onChange={this.handleChangeRadio}
                        />
                        <Radio
                            label={technicalServsName.label}
                            value={"true"}
                            onChange={this.handleChangeRadio}
                            checked={isShowTechServs === "true"}
                            style={{ marginBottom: 4 }}
                            radioStyle={{ height: 25 }}
                        />
                        <Divider />
                        {isShowTechServs === "true" && (
                            <>
                                {technicalServs &&
                                    Object.values(technicalServs).map(s => (
                                        <Checkbox
                                            name={s.title}
                                            label={s.title}
                                            checkboxStyle={{
                                                height: 24
                                            }}
                                            key={s.title}
                                            checked={s.checked}
                                            onChange={this.handleChangeCheckbox(
                                                s.title
                                            )}
                                        />
                                    ))}
                            </>
                        )}
                    </div>
                </div>

                {/*TODO: VALIDATION */}
                {errors && <span style={{ color: "red" }}>{errors}</span>}
                <br />
            </>
        );
    }
}

export default MainFormBody;
