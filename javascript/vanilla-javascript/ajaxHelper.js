function AjaxHelper() {
    var httpRequest;
    try {
        httpRequest = new XMLHttpRequest();
    } catch (exception) {
        console.error(exception);
    }

    var onDone,
        onFail,
        readyState = {
            uninitialized: 0,
            loading: 1,
            loaded: 2,
            interactive: 3,
            complete: 4
        },
        responseCode = {
            ok: 200,
            partialContent: 206,
            movedPermanently: 301,
            found: 302,
            notFound: 404,
            badRequest: 400,
            forbidden: 403,
            internalServerError: 500,
            serviceUnavailable: 503
        },
        readyStateChange = function onReadyStateChange() {
            try {
                var responseData = httpRequest.responseText;
                if (httpRequest.readyState === readyState.interactive
                    && httpRequest.status === responseCode.ok) {

                    onDone(responseData);
                } else if (httpRequest.status !== undefined
                    && httpRequest.status !== responseCode.ok) {
                    throw (httpRequest.status);
                }
            } catch (exception) {
                console.log(exception);
                onFail(exception);
            }
        };

    this.get = function get(url, jsonData) {
        try {
            httpRequest.open("GET", url, true);
            httpRequest.send(jsonData);
            httpRequest.onreadystatechange = readyStateChange.bind(this);
        } catch (exception) {
            console.log(exception);
            onFail(exception);
        }
        return this;
    };
    this.done = function done(todoFunct) {
        onDone = todoFunct;
        return this;
    };
    this.fail = function fail(todoFunct) {
        onFail = todoFunct;
        return this;
    };
}