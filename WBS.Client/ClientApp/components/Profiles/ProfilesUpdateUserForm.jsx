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
import actionsCreators from '../../reducers/helpers';
import { connect } from 'react-redux'

class ProfileChangeItemForm extends React.Component {

  constructor(props) {
    super(props)
    this.state = {
      submitted: false
    }

  }

  static getDerivedStateFromProps(nextProps){
    return {...nextProps.user, selectedRoles: nextProps.user.roles? nextProps.user.roles.map(r => r.id):[]}
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
    const { fio, jobPosition, department, selectedRoles, id } = this.state

    if (fio !== '') {
      const { save } = this.props;
      const roles = selectedRoles.map(r => ({ id: r }))
      const values = { fio, jobPosition, department, roles, id }
      save(values)
    }
  }

  componentDidMount() {
    const { getRolesForSelect } = this.props;
    getRolesForSelect()
  }

  render() {
    const { roles, error, header } = this.props
    const { selectedRoles, submitted, fio, jobPosition, department } = this.state

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
            <div>
              <TextFieldMultiline name="fio" label="ФИО" value={fio} onChange={this.handleChange} />
              {submitted && !fio &&
                <div style={{ color: 'red'}}>*Поле обязательно для заполнения</div>}
            </div>
            <div>
              <TextFieldMultiline name="jobPosition" label="Должность" value={jobPosition} onChange={this.handleChange} />
            </div>
            <div>
              <TextFieldMultiline name="department" label="Подразделение" value={department} onChange={this.handleChange} />
            </div>
            <div>
              <TextFieldMultiSelect name="roles" values={selectedRoles} label="Полномочия" items={roles} onChange={this.handleChangeMultiSelect} />
            </div>
            {error && <span style={{ color: 'red' }}>{error}</span>}
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
  error: PropTypes.object,
  roles: PropTypes.array,
  getRolesForSelect: PropTypes.func.isRequired,
};

const mapDispatchFromProps = { ...actionsCreators }
const mapStateToProps = state => ({ roles: state.helpers.roles, errors: state.monolithic.errors })

export default (connect(mapStateToProps, mapDispatchFromProps)(ProfileChangeItemForm))



