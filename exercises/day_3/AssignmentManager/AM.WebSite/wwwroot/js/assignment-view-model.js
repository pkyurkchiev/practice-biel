var AssignmentViewModel = function () {
    let self = this;
    let baseUrl = "http://localhost:55814/api/assignments";

    self.assignments = ko.observableArray();
    self.error = ko.observable();
    self.newAssignment = {
        title: ko.observable(),
        description: ko.observable(),
        startedOn: ko.observable(),
        endedOn: ko.observable()
    };
    self.isNew = ko.observable(false);

    function ajaxHelper(url, method, data) {
        self.error('');
        return $.ajax({
            type: method,
            url: url,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function () { self.error('Ajax request error'); });
    };

    function getAllAssignments() {
        ajaxHelper(baseUrl, 'GET').done(function (data) {
            self.assignments(data.assignments);
            console.log(data.assignments);
        });
    };

    self.addAssignment = function (formElement) {
        let assignment = {
            title: self.newAssignment.title(),
            description: self.newAssignment.description(),
            startedOn: self.newAssignment.startedOn(),
            endedOn: self.newAssignment.endedOn()
        };

        ajaxHelper(baseUrl, 'POST', assignment).done(function (data) {
            console.log(data.assignment);
            self.assignments.push(data.assignment);
            self.checkAssignment();
        });
    };

    self.checkAssignment = function () {
        self.isNew(!self.isNew());
    };

    getAllAssignments();
};

ko.applyBindings(new AssignmentViewModel);