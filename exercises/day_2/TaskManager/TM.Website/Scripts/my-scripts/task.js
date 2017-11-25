var ViewModel = function ()
{
    var self = this;
    self.tasks = ko.observableArray();
    self.error = ko.observable();
    //self.details = ko.observable();
    self.deleteTask = ko.observable();
    self.newTask = {
        Name: ko.observable(),
        Description: ko.observable(),
        StartedOn: ko.observable(),
        EndedOn: ko.observable()
    };
    self.IsNew = ko.observable(false);
    
    var tasksUrl = 'http://localhost:64090/api/tasks/';

    function ajaxHelper(url, method, data) {
        self.error('');
        return $.ajax({
            type: method,
            url: url,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function () { self.error('Error!'); });
    };

    //self.getDetails = function (item)
    //{
    //    ajaxHelper(tasksUrl + item.id, 'GET').done(function (data)
    //    {
    //        self.details(data.response[0]);
    //    });
    //};

    self.deleteTask = function (item)
    {
        ajaxHelper(tasksUrl + item.Id, 'DELETE').done(function (data)
        {
            self.tasks(data);
        });
    };

    self.checkTask = function () {
        self.IsNew(!self.IsNew())
    };

    function getAlltasks() {
        ajaxHelper(tasksUrl, 'GET').done(function (data) {
            self.tasks(data);
        });
    };

    self.addTask = function (fromElement) {
        var task = {
            name: self.newTask.Name(),
            description: self.newTask.Description(),
            startedBy: 1,
            startedOn: self.newTask.StartedOn(),
            endedOn: self.newTask.EndedOn()
        };

        ajaxHelper(tasksUrl, 'POST', task).done(function (item) {
            self.tasks.push(item);
            self.checkTask();
        });
    };

    getAlltasks();
};

ko.applyBindings(new ViewModel());