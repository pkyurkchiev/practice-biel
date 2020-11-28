var AssignmentViewModel = function () {
    let self = this;
    let baseUrl = "http://localhost:55814/api/assignments";

    self.assignments = ko.observableArray();
    self.error = ko.observable();

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

    getAllAssignments();
};

ko.applyBindings(new AssignmentViewModel);