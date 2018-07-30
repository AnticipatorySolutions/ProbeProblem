function ArticleViewModel(app, dataModel) {
    var self = this;
    self.UserId = ko.observable("");

//    self.Title = ko.observable("");
	//self.Content = ko.observable("");

    Sammy(function () {
        this.get('api/ArticleModels', function () {
            $.ajax({
                method: 'get',
                url: app.dataModel.articleInfoUrl,
                contentType: "application/json; charset=utf-8",
                headers: {
                    'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
                },
                success: function (data) {
                    alert(urlPath);
                    console.log(data);
  //                  self.Title(data.Title);
    //                self.Content(data.Content);
                    self.UserId(data.UserId);
                },
                error: function (err) {
                    if (err.responseText == "success") {
                		alert(urlPath);
                		window.location.href = urlPath + '/';
                	} else {
                		alert(err.responseText)
                	}
                },
                complete: function () {
                    alert(err.responseText)
                }
            });
        });
        this.get('/', function () { this.app.runRoute('get', 'api/ArticleModels'); console.log("*******************************");});
    });

    return self;
}

app.addViewModel({
    name: "Articles",
    bindingMemberName: "articles",
    factory: ArticleViewModel
});
