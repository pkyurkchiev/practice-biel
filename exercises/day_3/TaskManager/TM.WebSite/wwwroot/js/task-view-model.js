var TaskViewModel = function () {
    let self = this;
    let baseUrl = 'https://localhost:44301/api/tasks';

    self.tasks = ko.observableArray();
    self.error = ko.observable();
    self.newTask = {
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

    function getAllTasks() {
        ajaxHelper(baseUrl, 'GET').done(function (data) {
            self.tasks(data.tasks);
            console.log(data.tasks);
        });
    };

    self.addTask = function (formElement) {
        let task = {
            title: self.newTask.title(),
            description: self.newTask.description(),
            startedOn: self.newTask.startedOn(),
            endedOn: self.newTask.endedOn()
        };

        ajaxHelper(baseUrl, 'POST', task).done(function (data) {
            self.tasks.push(task);
            self.checkTask();
        });
    };

    self.checkTask = function () {
        self.isNew(!self.isNew());
    };

    getAllTasks();
};

ko.applyBindings(new TaskViewModel);