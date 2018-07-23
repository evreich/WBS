export const profileColums = {
    FIO: 'fio',
    JOBPOSITION: 'jobPosition',
    DEPARTMENT: 'department',
    MARKED_DELETED: 'deletionMark'
}

export const columnTitle = [
    { id: profileColums.FIO, numeric: false, disablePadding: true, label: 'ФИО' },
    { id: profileColums.JOBPOSITION, numeric: false, disablePadding: false, label: 'Должность' },
    { id: profileColums.DEPARTMENT, numeric: false, disablePadding: false, label: 'Подразделение' },
    { id: profileColums.MARKED_DELETED, numeric: false, disablePadding: false, label: 'Помечено на удаление' },
];