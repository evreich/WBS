import TypesOfColumnData from "constants/typesOfColumnData";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    fio: {
        propName: "fio",
        label: "ФИО",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true,
        fieldComponent: 'TextFieldMultiline'
    },
    jobPosition: {
        propName: "jobPosition",
        label: "Должность",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true,
        fieldComponent: 'TextFieldMultiline'
    },
    department: {
        propName: "department",
        label: "Подразделение",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true,
        fieldComponent: 'TextFieldMultiline'
    },
    deletionMark: {
        propName: "deletionMark",
        label: "Помечено на удаление",
        type: TypesOfColumnData.BOOLEAN,
        isVisible: true,
        canEdit: true,
        fieldComponent: ''
    },
    login: {
        propName: "login",
        label: "Логин",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true,
        fieldComponent: 'TextFieldPlaceholder'
    },
    password: {
        propName: "password",
        label: "Пароль",
        type: TypesOfColumnData.STRING,
        isVisible: true,
        canEdit: true,
        fieldComponent: 'TextFieldPlaceholder'
    },
    roles: {
        propName: "roles",
        label: "Полномочия",
        type: TypesOfColumnData.ARRAY,
        isVisible: true,
        canEdit: true,
        fieldComponent: 'RoleMultiSelect'
    }
};

const createWindowFields = {
    [commonFields.login.propName]: commonFields.login,
    [commonFields.password.propName]: commonFields.password,
    [commonFields.fio.propName]: commonFields.fio,
    [commonFields.department.propName]: commonFields.department,
    [commonFields.jobPosition.propName]: commonFields.jobPosition,
    [commonFields.roles.propName]: commonFields.roles,
}

const editWindowFields = {
    [commonFields.fio.propName]: commonFields.fio,
    [commonFields.department.propName]: commonFields.department,
    [commonFields.jobPosition.propName]: commonFields.jobPosition,
    [commonFields.roles.propName]: commonFields.roles,
}

const infoWindowModel = {
    [commonFields.fio.propName]: commonFields.fio,
    [commonFields.department.propName]: commonFields.department,
    [commonFields.jobPosition.propName]: commonFields.jobPosition,
    [commonFields.deletionMark.propName]: commonFields.deletionMark,
}

const tableHeaders = {
    [commonFields.fio.propName]: commonFields.fio,
    [commonFields.department.propName]: commonFields.department,
    [commonFields.jobPosition.propName]: commonFields.jobPosition,
    [commonFields.deletionMark.propName]: commonFields.deletionMark,
};

const titleTable = "Пользователи";
const tableId = "Profiles";

export default { 
    createWindowFields, 
    editWindowFields, 
    infoWindowModel, 
    tableHeaders, 
    titleTable,
    tableId
};
