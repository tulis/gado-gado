module.exports.routers = module.exports.routers || {};
module.exports.routers.map = function mapRouters(express){
    var routers = {
        api: {
            users: require("./api/users.js").routers.api.users
        },
        home: require("./home.js").routers.home
    };

    express.get("/", routers["home"].getHomepage);
    express.get("/api/users/", routers["api"]["users"].listUsers);
};
