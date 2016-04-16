(function (module){
    module.exports.repo = module.exports.repo || {};
    module.exports.repo.getUsers = function getUsers(onGetUsersDataDone){
        var FileSystem = require("fs");
        var usersPath = __dirname + "/users.json";
        FileSystem.readFile(usersPath, "utf8", function onReadUsersDone(error, rawUsersData){
            if(error){
                console.log(error);
            }else{
                onGetUsersDataDone(rawUsersData);
            }
        });
    };
})(module);
