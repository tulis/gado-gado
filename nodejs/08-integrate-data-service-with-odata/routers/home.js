module.exports.routers = module.exports.routers || {};
module.exports.routers.home = (function exportsHomeRouter(){

    function getHomepage(request, response){
        response.render("home", {name: "World"});
    }

    return {
        getHomepage: getHomepage
    };
})();
