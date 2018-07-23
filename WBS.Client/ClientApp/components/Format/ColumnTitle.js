export const formatColums = {
    TITLE: 'title',
    PROFILE: 'profile',
    DIRECTOR_OF_FORMAT: 'directorOfFormatFio',
    DIRECTOR_OF_KY_FORMAT: 'directorOfKYFormatFio',
    KY_FORMAT: 'kyFormatFio',
    TYPE_OF_FORMAT: 'typeOfFormat',
    E1: 'e1Limit',
    E2: 'e2Limit',
    E3: 'e3Limit'
}

export const columnTitle = [
    { id: formatColums.TITLE, numeric: false, disablePadding: true, label: 'Название' },
    { id: formatColums.PROFILE, numeric: false, disablePadding: false, label: 'Профиль' },
    { id: formatColums.DIRECTOR_OF_FORMAT, numeric: false, disablePadding: false, label: 'Директор Формата' },
    { id: formatColums.DIRECTOR_OF_KY_FORMAT, numeric: false, disablePadding: false, label: 'Директор КУ Формата' },
    { id: formatColums.KY_FORMAT, numeric: false, disablePadding: false, label: 'КУ Формат' },
    { id: formatColums.TYPE_OF_FORMAT, numeric: false, disablePadding: false, label: 'Тип Формата' },
    { id: formatColums.E1, numeric: true, disablePadding: false, label: 'E1' },
    { id: formatColums.E2, numeric: true, disablePadding: false, label: 'E2' },
    { id: formatColums.E3, numeric: true, disablePadding: false, label: 'E3' },
];