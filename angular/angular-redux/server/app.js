"use strict";

var express = require("express");
var bodyParser = require("body-parser");
var fs = require("fs");

var jsonParser = bodyParser.json();

app.use(express.static(__dirname + "/public"));
app.get("/api/users", function (request, response) {
    var content = fs.readFileSync("users.json", "UTF-8");
    var users = JSON.parse(content);
    response.send(users);
});