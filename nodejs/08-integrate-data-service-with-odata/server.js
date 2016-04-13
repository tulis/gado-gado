(function main(){

    var express = require("express");
    var app = express();
    app.set("views", __dirname + "/views");
    app.set("view engine", "jsx");

    var expressReactViews = require("express-react-views");
    var options = {beautify: true};
    app.engine("jsx", expressReactViews.createEngine(options));

    var routers = require("./routers").routers;
    routers.map(app);

    app.listen(3000, function(){
        console.log("Example app listening on port 3000!!!");
    });

})();
