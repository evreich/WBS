import download from "downloadjs";

import request from "../../../../../utils/fetchUtil";
import REQUEST_METHOD from "../../../../../settings/httpMethods";

export function getAttachment(currRoute, onSuccess, onError, id, filename) {
    if (!currRoute) throw new Error("Can't resolve URI");

    request(
        {
            method: REQUEST_METHOD.HTTP_GET,
            route: currRoute + `${id}/`
        },
        reader => {
            const readableStream = new ReadableStream({
                start(controller) {
                    return pump();
                    function pump() {
                        return reader.read().then(({ done, value }) => {
                            // When no more data needs to be consumed, close the stream
                            if (done) {
                                controller.close();
                                return;
                            }
                            // Enqueue the next data chunk into our target stream
                            controller.enqueue(value);
                            return pump();
                        });
                    }
                }
            });
            const response = new Response(readableStream);
            download(response.blob(), filename, "text/plain");
        },
        ex => console.log(ex)
    );
}
