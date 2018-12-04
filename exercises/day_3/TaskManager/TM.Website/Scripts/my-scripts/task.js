var ViewModelTask = function () {
    let self = this;
    let baseUrl = 'http://localhost:60502/api/tasks';

    self.tasks = ko.observableArray();
    self.error = ko.observable();
    self.newTask = {
        name: ko.observable(),
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
        }).fail(function () { self.error("Error!"); });
    };

    function getAllTasks() {
        ajaxHelper(baseUrl, 'GET').done(function (data) {
            self.tasks(data);
            // console.log(self.tasks);
        });
    };


    self.addTask = function (formElement) {
        let task = {
            name: self.newTask.name(),
            description: self.newTask.description(),
            startedOn: self.newTask.startedOn(),
            endedOn: self.newTask.endedOn()
        };

        ajaxHelper(baseUrl, 'POST', task).done(function (item) {
            self.tasks.push(item);
            self.checkTask();
        });
    };

    self.checkTask = function () {
        self.isNew(!self.isNew());
    };

    getAllTasks();
};

ko.applyBindings(new ViewModelTask());