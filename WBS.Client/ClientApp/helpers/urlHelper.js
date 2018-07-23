
export const makeURL = (pathLocation, params) => {
    const url = new URL(pathLocation);
    const data = { ...params };
    data && Object.keys(data).forEach(key =>
        url.searchParams.append(key, data[key])
    );
    return url
}