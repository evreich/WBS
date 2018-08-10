import TypesOfColumnData from "../../../constants/typesOfColumnData";

//Cвойства объекта должны соответствовать свойствам данных,
//получаемых с сервера
const commonFields = {
    fio: {
        propName: "fio",
        label: "ФИО",
        type: TypesOfColumnData.STRING
    },
    jobPosition: {
        propName: "jobPosition",
        label: "Должность",
        type: TypesOfColumnData.STRING
    },
    department: {
        propName: "department",
        label: "Подразделение",
        type: TypesOfColumnData.STRING
    },
    deletionMark: {
        propName: "deletionMark",
        label: "Помечено на удаление",
        type: TypesOfColumnData.BOOLEAN
    },
    login: {
        propName: "login",
        label: "Логин",
        type: TypesOfColumnData.STRING
    },
    password: {
        propName: "password",
        label: "Пароль",
        type: TypesOfColumnData.STRING
    },
    roles: {
        propName: "roles",
        label: "Полномочия",
        type: TypesOfColumnData.ARRAY 
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

export default { 
    createWindowFields, 
    editWindowFields, 
    infoWindowModel, 
    tableHeaders, 
    titleTable 
};
