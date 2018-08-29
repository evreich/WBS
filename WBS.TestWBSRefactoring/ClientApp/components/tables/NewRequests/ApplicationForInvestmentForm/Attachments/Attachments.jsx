import React from "react";
import PropTypes from "prop-types";

import Gallery from "react-fine-uploader";
import FineUploaderTraditional from "fine-uploader-wrappers";

import Table, { TableBody, TableCell, TableRow } from "@material-ui/core/Table";

import AttachmentConstants from "constants/attachment";
import { getAttachment } from "./helpersAPI";

const uploader = new FineUploaderTraditional({
    options: {
        chunking: {
            //enabled: true
        },
        deleteFile: {
            enabled: true
            //endpoint: AttachmentConstants.ATTACHMENT_DELETE_URL
        },
        request: {
            endpoint: AttachmentConstants.ATTACHMENT_UPLOAD_URL
        },
        retry: {
            enableAuto: true
        }
    }
});

class Attachments extends React.PureComponent {
    constructor(props) {
        super(props);
        this.state = {
            attachments: []
        };
    }

    static propTypes = {
        classes: PropTypes.object.isRequired,
    };

    componentDidMount() {
        //set attachemnts
        const { attachments } = this.state;
        uploader.on("complete", (id, name, responseJSON) => {
            attachments.push({ id: responseJSON.id });
            this.setState({ attachments });
        });
        //set values for selects
    }

    render() {
        const { classes } = this.props;
        const { attachments } = this.state;

        return (
            <div>
                <Gallery uploader={uploader} />
                <Table className={classes.table}>
                    <TableBody>
                        {attachments &&
                            attachments.map(
                                (a, i) =>
                                    typeof a.daiId === "number" && (
                                        <TableRow key={i}>
                                            <TableCell className={classes.cell}>
                                                <a
                                                    href=""
                                                    onClick={e => {
                                                        e.preventDefault();
                                                        getAttachment(
                                                            a.id,
                                                            a.fileName
                                                        );
                                                    }}
                                                >
                                                    {a.fileName}
                                                </a>
                                            </TableCell>
                                        </TableRow>
                                    )
                            )}
                    </TableBody>
                </Table>
            </div>
        );
    }
}

export default Attachments;
