define(['plugins/router', 'knockout', 'durandal/system', 'plugins/http'], function (router, ko, system, http) {
    var self = this;
    self.editMode = ko.observable(false);
    self.ID = ko.observable(0);
    self.firstName = ko.observable("");
    self.lastName = ko.observable("");

    return {
        activate: function (id) {
            return http.get('/api/personnel/getperson/' + id).then(
                function (response) {
                    self.ID(id);
                    self.firstName(response.FirstName);
                    self.lastName(response.LastName);
                }
            );
        },

        Delete: function (id) {
            $.post("/api/personnel/deleteperson/" + self.ID()).then(
                function () {
                    router.navigate('personnel');
                }
            );
        },

        Edit: function () {;
            self.editMode(true);
        },

        Save: function () {
            $.post("api/personnel/updateperson/", {
                "ID": self.ID(),
                "FirstName": self.firstName(),
                "LastName": self.lastName()
            }).then(function () {
                self.editMode(false);
            });
        },

        Cancel: function () {
            self.editMode(false);
        }
    };
});