var express = require("express");
var app = express();

app.set("views", __dirname + "/views");
app.set("view engine", "jsx");

var options = {beautify: true};
app.engine("jsx", require("express-react-views").createEngine(options));

app.get("/", require("./routes").index);

app.get("/api/users/", require("./routes/api/users.js").users);

app.listen(3000, function(){
    console.log("Example app listening on port 3000!!!");
});
