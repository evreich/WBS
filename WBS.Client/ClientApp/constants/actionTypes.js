﻿const actionTypes = {
    AUTHORIZATION: 'AUTHORIZATION',
    LOGOUT: 'LOGOUT',
    REFRESHING_TOKEN: 'REFRESHING_TOKEN',

    GET_TABLE_SUCCESS: 'GET_TABLE_SUCCESS',
    GET_TABLE_ERROR: 'GET_TABLE_ERROR',
    CLEAR_TABLE: 'CLEAR_TABLE',
    UPDATE_TABLE: 'UPDATE_TABLE',
    SET_UPDATING_ITEM: 'SET_UPDATING_ITEM',
    CLEAR_UPDATING_ITEM: 'CLEAR_UPDATING_ITEM',

    REQUEST_IS_FETCHING: 'REQUEST_IS_FETCHING',
    REQUEST_IS_FETCHED: 'REQUEST_IS_FETCHED',
    CLEAR_COMPONENT_DATA: 'CLEAR_COMPONENT_DATA',

    DESCRIPTORS_IS_FETCHED: 'DESCRIPTORS_IS_FETCHED',
    PERMISSIONS_IS_FETCHED: 'PERMISSIONS_IS_FETCHED'
};

export default actionTypes;