define([],function () {
    var self = this;
    var ko = require('knockout');
    self.firstName = ko.observable();
    self.lastName = ko.observable();
    self.people = ko.observableArray([]);

    self.activate = function () {
        return $.get("/api/personnel/?" + Math.random()).done(function (data) {
            self.people([]);
            $.each(data, function (key, item) {
                self.people.push(item);
            });
        });
    },
    
    self.Submit = function () {
        var newPerson = { "ID": 0, "FirstName": firstName(), "LastName": lastName() };
        $.post("/api/personnel/createperson", {
            FirstName: firstName,
            LastName: lastName
        }).done(function (data) {
            self.firstName("");
            self.lastName("");
            newPerson.ID = Number(data);
            self.people.push(newPerson);
        });
    };

    return self;
});