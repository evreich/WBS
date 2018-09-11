import React from "react";

import DataFieldsInfo from "./DataFieldsInfo";
import ProfilesContainer from "containers/tables/Profiles/Profiles";
import ProfilesAddItemDialogBody from "./ProfilesAddItemDialogBody";
import ProfilesEditItemDialogBody from "./ProfilesEditItemDialogBody";
import ProfilesInformationForm from './ProfilesInformationForm'
import ProviderTableRow from "./ProfilesTableRow";

const Profiles = () => {
    const Profiles = ProfilesContainer(
        DataFieldsInfo,
        ProfilesAddItemDialogBody,
        ProfilesEditItemDialogBody,
        ProfilesInformationForm,
        ProviderTableRow
    );

    return <Profiles />;
};

export default Profiles;
