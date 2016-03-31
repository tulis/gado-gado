var http = require('http');

var server = http.createServer(function(request, response){
    console.log(request.url);

    response.write("<html><body><h1>" + request.url +"</h1></body></html>");
    response.end();
});

// server.listen(portNumber);
// Usually the port number would be 80, because it would be a public-facing
// web server
server.listen(3000);

// Next, run the server through following command:
//
//      > node server.js
//
// Then, open browser, navigate to http://localhost:3000
// Try different path but on same domain to see different response, for e.g.
// http://localhost:3000/hello/world
//
// Should have feedback on both node server command line and browser
