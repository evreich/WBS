import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import Dialog, {
    DialogActions,
    DialogContent,
    DialogTitle,
} from 'material-ui/Dialog';
import DatePicker from '../../Commons/DatePicker';
import Button from 'material-ui/Button';
import TextFieldSelect from '../../Commons/TextFields/TextFieldSelect';
import TextFieldPlaceholder from '../../Commons/TextFields/TextFieldPlaceholder';
import TextFieldMultiline from '../../Commons/TextFields/TextFieldMultiline';
import Divider from 'material-ui/Divider';
import Checkbox from '../../Commons/Checkbox';
import { connect } from 'react-redux';
import Radio from '../../Commons/Radio';
import Tabs, { Tab } from 'material-ui/Tabs';
import Paper from 'material-ui/Paper';
import Budget from './Budget/Budget'
import OutBudget from './OutBudget/OutBudget';
import Investment from './Investment/Investment';
import Vendors from './Vendors/Vendors';
import InvestmentEfficiency from './InvestmentEfficiency/InvestmentEfficiency';
import ExpansionPanel, {
    ExpansionPanelSummary,
    ExpansionPanelDetails,
} from 'material-ui/ExpansionPanel';
import ExpandMoreIcon from 'material-ui-icons/ExpandMore';
import actionsCreators from '../../../reducers/helpers';
import ChooseVendorModalForm from './Vendors/ChooseVendorModalForm';

import Typography from 'material-ui/Typography';
import Grid from 'material-ui/Grid';
import { withStyles } from 'material-ui/styles';
import styles from './ApplicationForInvestmentForm.css';


function TabContainer({ children }) {
    return (
        <Typography component="div" style={{ padding: 8 * 3 }}>
            {children}
        </Typography>
    );
}

TabContainer.propTypes = {
    children: PropTypes.any,
    dir: PropTypes.any,
};

export class ApplicationForInvestmentForm extends React.Component {
    constructor(props, context) {
        super(props, context);
        this.state = {
            tab: 0,
            radioBlock: "",
            providers: [],
            isProvidersModalWindowOpen: false,
        };
    }

    //заносим все поля объекта в state компонента;
    //каждому элементу массива объектов technicalServices соответсвует чекбокс на форме, поэтому 
    //расскладываем массив technicalServices в state на поля вида [technicalServices.title]:true 
    static getDerivedStateFromProps(nextProps) {
        if (nextProps.data) {
            const techServsIsNotEmpty = nextProps.data.technicalServices.length > 0
            const techServs = techServsIsNotEmpty ? nextProps.data.technicalServices.map(t => ({ [t.title]: true })).reduce((a, b) => a = { ...a, ...b }) : {}
            const radioBlock = techServsIsNotEmpty ? "techServsSelected" : "aribaSelected"

            return { ...nextProps.data, ...techServs, radioBlock }
        }
        else return null
    }


    componentDidMount() {
        const { getSitsForSelect, getResultCentresSelect, getTechnicalsServsSelect, getInvestmentRationalSelect } = this.props;
        getSitsForSelect();
        getResultCentresSelect();
        getTechnicalsServsSelect();
        getInvestmentRationalSelect();
    }



    submmit = (event) => {
        event.preventDefault();
        const { save, technicalServs } = this.props;
        const values = { ...this.state };
        values.technicalServices = technicalServs.filter(s => { if (values[s.title]) return s });
        save(values);

    }

    cancel = () => {
        const { cancel } = this.props
        cancel();
    }

    handleChange = (e) => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    }

    handleChangeTab = (e, value) => {
        if (typeof e === 'number')
            this.setState({ tab: e });
        else
            this.setState({ tab: value });
    }

    handleChangeCheckbox = name => event => {
        this.setState({ [name]: event.target.checked });
    };

    handleChangeRadio = (event) => {
        this.setState({ radioBlock: event.target.value });
    }

    handleDateChange = (name) => (date) => {
        this.setState({ [name]: date });
    }

    handleChangeStateValue = (name, value) => {
        this.setState({ [name]: value });
    }

    handleDeleteProviderButtonClick = (id) => {
        this.setState(prevState => ({
            providers: prevState.providers.filter(p => { p.id !== id })
        }))
    }

    handleOpenProvidersWindow = () => {
        this.setState({ isProvidersModalWindowOpen: true });
    }

    handleCloseProvidersWindow = () => {
        this.setState({ isProvidersModalWindowOpen: false });
    }

    handleAddProvider = (provider) => {
        const { providers } = this.state;
        if (providers.map(p => p.id).indexOf(provider.id) === -1) providers.push(provider)
        this.setState({ providers: providers })
    }


    render() {
        const { classes,
            submitting,
            sits,
            resultCentres,
            technicalServs,
            investmentRational,
        } = this.props;
        const { tab,
            providers,
            isProvidersModalWindowOpen,
            radioBlock,
            number,
            directorApprovalDate,
            sitId,
            resultCentreId,
            deliveryTime,
            approvalOfTechExpertIsRequired,
            rationaleForInvestmentId,
            commentForDirectorGeneral,
            reasonForDAI,
            totalInvestment,
            estimatedOperationPeriod,
            additionalSalesPerYear,
            savingsPerYear,
            periodOfPayback,
            netMargin,
            internalRateOfReturn,
            netPresentValue,
            marginOnAddedValue,
            extraAnnualCost
        } = this.state;
        const removeButtonEnable = true;

        return (
            <Dialog
                open={true}
                onClose={this.cancel}
                maxWidth={false}
            >

                <DialogTitle style={{ backgroundColor: '#296E50' }} id="form-dialog-title">
                    <div style={{ display: 'flex', justifyContent: 'space-between' }}>
                        <div style={{ marginTop: 5, color: '#50bd8e', }}> Заявка на получение инвестиции</div>
                        <Button color="secondary" style={{ color: '#fafafa' }}>
                            Запустить рабочий процесс
                        </Button>
                    </div>
                </DialogTitle>
                <DialogContent>
                    <form onSubmit={this.submmit}>
                        <div className={classes.flexRow}>
                            <TextFieldPlaceholder name="number" label="Номер заявки" value={number} disabled={true} style={{ width: 300 }} onChange={this.handleChange} />
                            <DatePicker name="directorApprovalDate" label="Дата утверждения директором" value={directorApprovalDate ? directorApprovalDate : null} disabled={true} style={{ width: 300 }} onChange={this.handleDateChange('directorApprovalDate')} />
                            <TextFieldPlaceholder name="" label="Текущий этап" value={""} disabled={true} style={{ width: 300, color: '#296E50' }} onChange={this.handleChange} />
                        </div>
                        <div className={classes.flexRow}>
                            <div className={classes.flexColomn}>
                                <TextFieldSelect name="sitId" label="Название сита" value={sitId} items={sits && sits.map((s) => ({ value: s.id, text: s.title }))} style={{ width: 300, marginTop: 20 }} onChange={this.handleChange} />
                                <TextFieldPlaceholder name="" label="Ответственный в сите" value={""} disabled={true} style={{ width: 300, marginTop: 20 }} onChange={this.handleChange} />
                            </div>
                            <div className={classes.flexColomn}>
                                <TextFieldSelect name="resultCentreId" label="Центр результата" value={resultCentreId} items={resultCentres && resultCentres.map((s) => ({ value: s.id, text: s.title }))} style={{ width: 300, marginTop: 20 }} onChange={this.handleChange} />
                                <DatePicker name="deliveryTime" label="Желаемый срок поставки" value={deliveryTime ? deliveryTime : null} style={{ width: 300, marginTop: 20 }} onChange={this.handleDateChange('deliveryTime')} />
                            </div>
                            <div style={{ width: 300, display: 'flex', flexDirection: 'column' }}>
                                <Radio
                                    name="technicalServices"
                                    label={
                                        <Fragment>
                                            <span>Ariba </span>
                                            <a style={{ color: '#ed1a21' }} href="#">запустить</a>
                                        </Fragment>
                                    }
                                    checked={radioBlock === "aribaSelected"}
                                    value={"aribaSelected"}
                                    style={{ marginTop: 12 }}
                                    radioStyle={{ height: 25 }}
                                    onChange={this.handleChangeRadio}
                                />
                                <Radio name="technicalServices" label="Выбор технической службы*" value={"techServsSelected"} onChange={this.handleChangeRadio}
                                    checked={radioBlock === "techServsSelected"} style={{ marginBottom: 4 }} radioStyle={{ height: 25 }} />
                                <Divider />
                                {radioBlock === "techServsSelected" && <Fragment>
                                    {technicalServs && technicalServs.map(s => <Checkbox name={s.title} label={s.title} checkboxStyle={{ height: 24 }} defaultChecked={this.state[s.title]} onChange={this.handleChangeCheckbox(s.title)} />)}
                                </Fragment>}
                            </div>
                        </div>
                        <div className={classes.tabs}>
                            <Paper>
                                <Tabs
                                    value={tab}
                                    onChange={this.handleChangeTab}
                                    indicatorColor="primary"
                                    textColor="secondary"
                                    centered
                                >
                                    <Tab label="Бюджет" />
                                    <Tab label="Вне бюджета" />
                                    <Tab label="Инвестиции" />
                                    <Tab label="Поставщик" />
                                </Tabs>
                            </Paper>
                            {tab === 0 && <TabContainer>
                                <Paper>
                                    <Budget budgetData={{ rowBudget: { sum: 11, rest: 22, dai: 33 }, totalSit: { sum: 11, rest: 22, dai: 33 } }} />
                                </Paper>
                            </TabContainer>}
                            {tab === 1 && <TabContainer>
                                <TextFieldSelect name="" value={""} items={[{ id: "1", text: "Новый" }, { id: "2", text: "Замена" }]} style={{ width: 150, marginBottom: 5 }} onChange={this.handleChange} />
                                <Paper>
                                    <OutBudget outBudgetData={{ sum: 1000 }} />
                                </Paper>
                            </TabContainer>}
                            {tab === 2 && <TabContainer>
                                <Paper>
                                    <Investment />
                                </Paper>
                            </TabContainer>}
                            {tab === 3 && <TabContainer>
                                <Paper>
                                    <Vendors vendors={providers} onDelete={this.handleDeleteProviderButtonClick} onAddNew={this.handleOpenProvidersWindow} />
                                    {isProvidersModalWindowOpen && <ChooseVendorModalForm onAdd={this.handleAddProvider} onClose={this.handleCloseProvidersWindow} technicalServs={technicalServs} />}
                                </Paper>
                            </TabContainer>}
                        </div>
                        <Divider />
                        <div className={classes.flexRow} style={{ width: 1200, justifyContent: 'space-around' }}>
                            <div style={{ width: 500, flexDirection: 'column' }}>
                                <TextFieldSelect name="rationaleForInvestmentId" label="Обоснование необходимости инвестиций" value={rationaleForInvestmentId} items={investmentRational && investmentRational.map((s) => ({ value: s.id, text: s.title }))} onChange={this.handleChange} style={{ width: 350, marginTop: 20, marginBottom: 20 }} />
                                <Checkbox name="approvalOfTechExpertIsRequired" label="Требуется одобрение технического эксперта" defaultChecked={approvalOfTechExpertIsRequired} checkboxStyle={{ height: 24 }} onChange={this.handleChangeCheckbox('approvalOfTechExpertIsRequired')} />
                            </div>
                            <TextFieldMultiline name="commentForDirectorGeneral" value={commentForDirectorGeneral} label="Комментарий для генерального директора" rows={4} style={{ width: 500, marginTop: 20, marginBottom: 20 }} onChange={this.handleChange} />
                        </div>
                        <ExpansionPanel>
                            <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />} style={{ display: 'flex', justifyContent: 'space-between' }}>
                                <Grid container='true'>
                                    <Typography>
                                        {(() => {
                                            if (rationaleForInvestmentId > 2)
                                                return investmentRational[rationaleForInvestmentId - 1].title
                                            else
                                                return 'Эффективность инвестиций'
                                        })()}
                                    </Typography>
                                </Grid>
                                <Grid container='true' justify='flex-end' full-width>
                                    {
                                        rationaleForInvestmentId < 3
                                            ? <Button variant='raised' color='primary' style={{ ...styles().btnSmall }}
                                                onClick={(event) => { event.stopPropagation(); this.efficiencyForm.calculationEfficiency() }}>Рассчитать</Button>
                                            : ""
                                    }
                                </Grid>
                            </ExpansionPanelSummary>
                            <ExpansionPanelDetails>
                                <div className={classes.flexRow} style={{ justifyContent: 'space-around' }}>
                                    {
                                        rationaleForInvestmentId <= 2 ?
                                            (<InvestmentEfficiency
                                                onRef={ref => (this.efficiencyForm = ref)}
                                                rationaleForInvestmentId={rationaleForInvestmentId}
                                                handleChange={this.handleChange}
                                                handleChangeParentState={this.handleChangeStateValue}
                                                fields={
                                                    {
                                                        totalInvestment,
                                                        estimatedOperationPeriod,
                                                        additionalSalesPerYear,
                                                        savingsPerYear,
                                                        periodOfPayback,
                                                        netMargin,
                                                        internalRateOfReturn,
                                                        netPresentValue,
                                                        marginOnAddedValue,
                                                        extraAnnualCost
                                                    }}
                                            />)
                                            : (
                                                <TextFieldMultiline name="reasonForDAI" value={reasonForDAI} rows={5} style={{ width: '100%' }} onChange={this.handleChange} />
                                            )

                                    }
                                </div>
                            </ExpansionPanelDetails>
                        </ExpansionPanel>
                        <br />
                        <ExpansionPanel>
                            <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />}>
                                <Typography>Заполняет КУ сита</Typography>
                            </ExpansionPanelSummary>
                            <ExpansionPanelDetails>
                                <div className={classes.flexRow} style={{ justifyContent: 'space-around' }}>
                                    <TextFieldSelect name="" label="Классификация инвестиций" value={""} disabled={true} items={[]} style={{ width: 350, marginTop: 20 }} onChange={this.handleChange} />
                                    <TextFieldPlaceholder name="" label="Тип факт" value={""} disabled={true} style={{ width: 350, marginTop: 20 }} onChange={this.handleChange} />
                                </div>
                            </ExpansionPanelDetails>
                        </ExpansionPanel>
                        <br />
                        <ExpansionPanel>
                            <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />}>
                                <Typography>Заполняет инициатор при закрытии заявки</Typography>
                            </ExpansionPanelSummary>
                            <ExpansionPanelDetails>
                                <div className={classes.flexRow} style={{ justifyContent: 'space-around' }}>
                                    <TextFieldPlaceholder name="" label="Внутренний инвентарный номер" value={""} disabled={true} style={{ width: 350, marginTop: 20 }} onChange={this.handleChange} />
                                    <DatePicker name="" label="Дата ввода основных средств в эксплуатацию" value={null} disabled={true} items={[]} style={{ width: 350 }} onChange={this.handleDateChange('deliveryTime')} />
                                </div>
                            </ExpansionPanelDetails>
                        </ExpansionPanel>
                        <br />

                        <DialogActions>
                            <span style={{ flex: 1 }}>
                                <Button onClick={this.cancel} variant="raised" disabled={removeButtonEnable} style={{color: 'green'}}>
                                    Удалить
                        </Button>
                            </span>
                            <Button onClick={this.cancel} style={{color: 'green'}}>
                                Отмена
                    </Button>
                            <Button type="submit" disabled={submitting} variant="raised" style={{color: 'green'}}>
                                Сохранить
                    </Button>
                        </DialogActions>
                    </form>
                </DialogContent>
            </Dialog >
        )
    }
}

ApplicationForInvestmentForm.propTypes = {
    cancel: PropTypes.func,
    change: PropTypes.func,
    formSelector: PropTypes.func,
    classes: PropTypes.object.isRequired,
    save: PropTypes.func,
    submitting: PropTypes.bool,
    onSubmit: PropTypes.func,
    error: PropTypes.object,
    sits: PropTypes.array,
    investmentRational: PropTypes.array,
    resultCentres: PropTypes.array,
    technicalServs: PropTypes.array,
    getSitsForSelect: PropTypes.func.isRequired,
    getResultCentresSelect: PropTypes.func.isRequired,
    getTechnicalsServsSelect: PropTypes.func.isRequired,
    getInvestmentRationalSelect: PropTypes.func.isRequired,
    rationaleForInvestmentIdValue: PropTypes.number,

}

const mapDispatchFromProps = {
    ...actionsCreators
}

const mapStateToProps = state => ({
    sits: state.helpers.sits,
    resultCentres: state.helpers.resultCentres,
    technicalServs: state.helpers.technicalServs,
    investmentRational: state.helpers.investmentRational,
})

export default withStyles(styles)(connect(mapStateToProps, mapDispatchFromProps)(ApplicationForInvestmentForm))


