import { addTask } from 'domain-task';
import { TableActions, Constants } from '../constants';
import { fetch } from '../utils';

const actionsCreators = {
    getDataTable: () => (dispatch, getState) => {
        let fetchTask = fetch(Constants.PROVIDER_CONTROLLER_URL, {
            method: 'GET',
        }, dispatch, getState().auth)
            .then(response => 
               
                 response.json()
                    .then(result => {
                        dispatch({
                            type: TableActions.FETCH_DATA_TABLE_SUCCESS,
                            payload: result,
                        });
                    })
            )
            .catch(response => {                
                alert(response);
            });
        addTask(fetchTask)
    },
    deleteDataTable: (Id) => (dispatch, getState) => {
        let fetchTask = fetch(`${Constants.PROVIDER_CONTROLLER_URL}/${Id}`, {
            method: 'DELETE',
        } ,dispatch, getState().auth)
            .then(response =>
                response.json()
                    .then(result => {
                        dispatch({
                            type: TableActions.DELETE_DATA_TABLE_SUCCESS,
                            payload: result,
                        });
                    }))
            .catch(response => {
                alert(response);
            });
        addTask(fetchTask)
    },
    createDataTable: (Item) => (dispatch, getState) => {
        let fetchTask = fetch(Constants.PROVIDER_CONTROLLER_URL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(Item)
        }, dispatch, getState().auth)
            .then(response =>
                response.json()
                    .then(result => {
                        dispatch({
                            type: TableActions.CREATE_DATA_TABLE_SUCCESS,
                            payload: result,
                        });
                    }))
            .catch(response => {
                alert(response);
            
        });
        addTask(fetchTask)
    },
    updateDataTable: (Item) => (dispatch, getState) => {
        let fetchTask = fetch(Constants.PROVIDER_CONTROLLER_URL, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(Item)
        }, dispatch, getState().auth)
            .then(response =>
                response.json()
                    .then(result => {
                        dispatch({
                            type: TableActions.UPDATE_DATA_TABLE_SUCCESS,
                            payload: result,
                        });
                    }))
            .catch(response => {
                alert(response);
            });
        addTask(fetchTask)
    },
};

export const reducer = (state = {}, action) => {
    switch (action.type) {
        case TableActions.FETCH_DATA_TABLE_SUCCESS:
            return {
                data: action.payload
            };
        case TableActions.DELETE_DATA_TABLE_SUCCESS:
            return {
                data: state.data && state.data.filter(item => item.id !== action.payload.id)
            }
        case TableActions.CREATE_DATA_TABLE_SUCCESS:
            return {
                data: [
                    ...state.data,
                    action.payload,
                ]
            }
        case TableActions.UPDATE_DATA_TABLE_SUCCESS:
            return {
                data: state.data && state.data.map(item => (item.id === action.payload.id ? action.payload : item))
            }
        default:
            return state.data || { data: [], };
    }
};

export default actionsCreators;