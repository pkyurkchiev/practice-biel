var BookViewModel = function () {
    let self = this;
    const baseUrl = "https://localhost:44309/api/library";

    self.library = ko.observableArray();
    self.error = ko.observable();
    self.newBook = {
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

    function getAllLibrary() {
        ajaxHelper(baseUrl, 'GET').done(function (data) {
            self.library(data.library);
            console.log(data.library);
        });
    };

    self.addBook = function (formElement) {
        let book = {
            title: self.newBook.title(),
            description: self.newBook.description(),
            startedOn: self.newBook.startedOn(),
            endedOn: self.newBook.endedOn()
        };

        ajaxHelper(baseUrl, 'POST', book).done(function (data) {
            console.log(data.book);
            self.library.push(data.book);
            self.checkBook();
        });
    };

    self.checkBook = function () {
        self.isNew(!self.isNew());
    };

    getAllLibrary();
};

ko.applyBindings(new BookViewModel);
