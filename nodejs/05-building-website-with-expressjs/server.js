var express = require("express");
var app = express();

app.get("/", function(request, response) {
    response.send("<html><body><h1>Hello World!!!!!</h1></body></html>");
});

app.get("/api/users/", function(request, response){
    response.set("Content-Type", "application/json");
    response.send({name: "Tulis", isValid: true, group: "Admin"});
});

app.listen(3000, function(){
    console.log("Example app listening on port 3000!!!");
});
