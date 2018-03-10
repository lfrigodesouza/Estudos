var http = require('http');
var app = require('./config/express');
let port = 3000;
http.createServer(app).listen(port	, function() {
	console.log('Servidor iniciado em http://localhost:'+port);
});
