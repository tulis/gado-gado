(function (module){
    module.exports.repo = module.exports.repo || {};
    module.exports.repo.getUsers = function getUsers(onGetUsersDataDone){
        var http = require("http");
        var getOptions = {
                hostname: "services.odata.org",
                port: 80,
                path: "/v4/(S(xbepigqxo34w35nxsgf32tsw))/TripPinServiceRW/People",
                json: true
        };
        var rawUsersData = "";

        http.get(getOptions, function onGetUsersResponsed(response){
            response.on("data", function handleUsersDataChunk(usersDataChunk){
                rawUsersData += usersDataChunk;
            });
            response.on("end", function handleUsersDataOnDone(){
                onGetUsersDataDone(rawUsersData);
            });
        }).on("error", function onGetUsersError(exception){
            console.log("onGetUsersError: " + exception.message);
        });

    };
})(module);
