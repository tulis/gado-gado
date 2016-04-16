module.exports.routers = module.exports.routers || {};
module.exports.routers.api = module.exports.routers.api || {};
module.exports.routers.api.users = (function exportsUsersApiRouter(){

    function listUsers(request, response){
        var dataRepo = require("../../data").repo;
        dataRepo.getUsers(function onGetUsersDataDone(rawUsersData){
            var users = JSON.parse(rawUsersData);
            response.render("api/users", users);
        });
    };

    return {
        listUsers: listUsers
    }
})();
