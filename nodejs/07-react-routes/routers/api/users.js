module.exports.routers = module.exports.routers || {};
module.exports.routers.api = module.exports.routers.api || {};
module.exports.routers.api.users = (function exportsUsersApi(){

    function listUsers(request, response){
        response.render("api/users", {});
    };

    return {
        listUsers: listUsers
    }
})();
