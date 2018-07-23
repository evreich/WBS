
import React from 'react'
import PropTypes from 'prop-types';

import ButtonDelete from '../Commons/Buttons/ButtonDelete'
import ButtonUpdate from '../Commons/Buttons/ButtonUpdate'

import Dialog, {
    DialogActions,
    DialogContent,
    DialogTitle,
  } from 'material-ui/Dialog';
import Button from 'material-ui/Button';

export class InformationForm extends React.Component {

    handleDeleteButtonClick = () => {
        const {elem: {id}, handleDeleteButtonClick} = this.props
        handleDeleteButtonClick(id)
        this.cancel();
    }

    handleUpdateButtonClick = () => {
        const {elem, handleUpdateButtonClick} = this.props       
        handleUpdateButtonClick(elem)      
    }

    cancel=() => {
        const {cancel} = this.props
        cancel();
    }


    render(){
        const {elem} = this.props
        return(
           
            <Dialog
            open={true}
            onClose={this.cancel}
            maxWidth={false}
            >
          
             <DialogTitle style={{backgroundColor: '#296E50'}} id="form-dialog-title">
              <div style={{ display: 'flex', justifyContent: 'space-between'}}>
                <div style={{ marginTop: 5 , color: '#fafafa',}}> Ситы - {elem.title}</div>
              </div>
            </DialogTitle>
            <DialogContent>
                <div style={{ marginTop: '2%', fontSize: '20px', fontFamily: '"Roboto", "Helvetica", "Arial", sans-serif'}}>   
               
                <table maxWidth="650" border="0" cellpadding="5" cellspacing="0">
                    <col width="250" valign="top"/>
                    <col width="180" valign="top" />
                    <col width="120" valign="top" />
                    <tr style={{height: '55px'}} >
                        <td>Формат:</td> 
                        <td><div style={{ fontWeight: 'bolder'}}>{elem.formatTitle}</div></td>
                        <td> <ButtonDelete style={{marginLeft: '25%', marginRight: '5%'}} onClick={this.handleDeleteButtonClick} size={'small'} />
                        <ButtonUpdate onClick={this.handleUpdateButtonClick} size={'small'} /></td>
                    </tr>
                    <tr style={{height: '55px'}}>
                        <td>Название:</td>
                        <td><div style={{ fontWeight: 'bolder'}}>{elem.title}</div></td>
                    </tr>
                    <tr style={{height: '55px'}}>
                        <td>Технический эксперт:</td>
                        <td><div style={{ fontWeight: 'bolder'}}>{elem.technicalExpertFio}</div></td>
                    </tr>
                    <tr style={{height: '55px'}}>
                        <td>КУ Сита:</td>
                        <td><div style={{ fontWeight: 'bolder'}}>{elem.kySitFio}</div></td>
                    </tr>
                    <tr style={{height: '55px'}}>
                        <td>Директор Сита:</td>
                        <td><div style={{ fontWeight: 'bolder'}}>{elem.directorOfSitFio}</div></td>
                    </tr>
                    <tr style={{height: '55px'}}>
                        <td>Создатель:</td>
                        <td><div style={{ fontWeight: 'bolder'}}>{elem.createrOfBudgetFio}</div></td>
                    </tr>
                    <tr style={{height: '55px'}}>
                        <td>КУ региональный:</td>
                        <td><div style={{ fontWeight: 'bolder'}}>{elem.kyRegionFio}</div></td>
                    </tr>
                    <tr style={{height: '55px'}}>
                        <td>Операционный директор:</td>
                        <td><div style={{ fontWeight: 'bolder'}}>{elem.operationDirectorFio}</div></td>
                    </tr>
                </table>
                </div >
                <DialogActions>                 
                <Button onClick={this.cancel} variant="raised" style={{color: 'green'}}>ОК</Button>
              </DialogActions>     
          </DialogContent>         
         </Dialog>    
        )
    }
}
InformationForm.propTypes = {
    cancel: PropTypes.func,
    classes: PropTypes.object.isRequired,
    elem: PropTypes.object.isRequired,
    handleDeleteButtonClick: PropTypes.func,
    handleUpdateButtonClick: PropTypes.func,

}



