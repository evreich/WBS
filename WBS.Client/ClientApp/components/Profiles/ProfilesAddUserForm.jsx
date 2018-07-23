import React from 'react';
import PropTypes from 'prop-types';
import Dialog, {
  DialogActions,
  DialogContent,
  DialogTitle,
} from 'material-ui/Dialog';
import Button from 'material-ui/Button';
import TextFieldMultiline from '../Commons/TextFields/TextFieldMultiline'
import TextFieldMultiSelect from '../Commons/TextFields/TextFieldMultiSelect'
import TextFieldPlaceholder from '../Commons/TextFields/TextFieldPlaceholder';
import actionsCreators from '../../reducers/helpers';
import errorActions from '../../reducers/form'
import { connect } from 'react-redux'

class ProfileChangeItemForm extends React.Component {

  constructor(props) {
    super(props)
    this.state = {
      fio: '',
      jobPosition: '',
      department: '',
      selectedRoles: [],
      login: '',
      password: '',
      submitted: false
    }

  }

  cancel = () => {
    const { cancel } = this.props
    cancel();
  }

  handleChange = (e) => {
    const { name, value } = e.target;
    this.setState({ [name]: value });
  }

  handleChangeMultiSelect = (e) => {
    const { value } = e.target;
    this.setState({ selectedRoles: value });
  }
  submmit = (event) => {
    event.preventDefault()
    this.setState({ submitted: true });
    const { fio, jobPosition, department, selectedRoles, password, login } = this.state

    if (fio !== '' && password !== '') {
      const { save } = this.props;
      const roles = selectedRoles.map(r => ({ id: r }))
      const values = { fio, jobPosition, department, roles, password, login }
      save(values)
    }
  }

  componentDidMount() {
    const { getRolesForSelect } = this.props;
    getRolesForSelect()
  }

  componentWillUnmount() {
    const { clearError, cancel } = this.props
    clearError()
    cancel()
  }

  render() {
    const { roles, errors, header } = this.props
    const { selectedRoles, submitted, fio, password } = this.state

    return (
      <Dialog
        open={true}
        onClose={this.cancel}
        maxWidth={false}
      >
        <DialogTitle id="form-dialog-title">
          <div style={{ display: 'flex', justifyContent: 'space-between' }}>
            <div style={{ marginTop: 5 }}>
              {header}
            </div>
          </div>
        </DialogTitle>
        <DialogContent>
          <form onSubmit={this.submmit}>
          {errors && <span style={{ color: 'red' }}>{errors.error}</span>}    
            <div>
              <TextFieldMultiline name="fio" label="ФИО" onChange={this.handleChange} />
              {submitted && !fio &&
                <div style={{ color: 'red' }}>*Поле обязательно для заполнения</div>}
            </div>
            <div>
              <TextFieldPlaceholder name="login" label="Логин" onChange={this.handleChange} />
            </div>
            <div>
              <TextFieldMultiline name="jobPosition" label="Должность" onChange={this.handleChange} />
            </div>
            <div>
              <TextFieldMultiline name="department" label="Подразделение" onChange={this.handleChange} />
            </div>
            <div>
              <TextFieldMultiSelect name="roles" values={selectedRoles} label="Полномочия" items={roles} onChange={this.handleChangeMultiSelect} />
            </div>
            <div>
              <TextFieldPlaceholder name="password" label={'Пароль'} type='password' onChange={this.handleChange} value={password} />
              {submitted && !password &&
                <div style={{ color: 'red' }}>*Поле обязательно для заполнения</div>}
            </div>           
            <DialogActions>
              <Button type="submit" variant="raised" color="secondary">
                Сохранить
             </Button>
              <Button onClick={this.cancel} color="secondary">
                Отмена
             </Button>
            </DialogActions>
          </form>
        </DialogContent>
      </Dialog>
    )
  }
}

ProfileChangeItemForm.propTypes = {
  header: PropTypes.string,
  cancel: PropTypes.func.isRequired,
  save: PropTypes.func.isRequired,
  errors: PropTypes.object,
  roles: PropTypes.array,
  getRolesForSelect: PropTypes.func.isRequired,
  clearError: PropTypes.func.isRequired,
};

const mapDispatchFromProps = { ...actionsCreators, ...errorActions }
const mapStateToProps = state => ({ roles: state.helpers.roles, errors: state.monolithic.errors })

export default (connect(mapStateToProps, mapDispatchFromProps)(ProfileChangeItemForm))



