import React from "react";

import REQUEST_METHOD from "constants/httpMethods";
import request from 'utils/fetchUtil';

const onClickHandler = () => {
    const url = "http://localhost:50122/api/Permissions/GetPermissionsForType/CategoryGroup";
    request({
        method: REQUEST_METHOD.HTTP_GET,
        route: url,
    },
        (data) => {
            console.log(data);
        },
        (ex) => { console.log("Error" + ex); }
    );
}

const home = () =>
    <React.Fragment>
        <br />
        Home page
        <button value="GetDescriptor" onClick={onClickHandler} />
    </React.Fragment>

export default home;
