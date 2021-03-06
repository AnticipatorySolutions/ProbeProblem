﻿function AppViewModel(dataModel) {
    // Private state
    var self = this;

    // Private operations
    function cleanUpLocation() {
        window.location.hash = "";

        if (typeof history.pushState !== "undefined") {
            history.pushState("", document.title, location.pathname);
        }
    }
    // Data
    self.Views = {
        Loading: {}
    };
    self.dataModel = dataModel;

    // UI state
    self.view = ko.observable(self.Views.Loading);

    self.loading = ko.computed(function () {
        return self.view() === self.Views.Loading;
    });

    
    self.addViewModel = function (options) {
        var viewItem = new options.factory(self, dataModel),
            navigator;

        self.Views[options.name] = viewItem;

        self[options.bindingMemberName] = ko.computed(function () {
            if (!dataModel.getAccessToken()) {
                var fragment = common.getFragment();

                if (fragment.access_token) {
                    window.location.hash = fragment.state || '';
                    dataModel.setAccessToken(fragment.access_token);
                } else {
                    window.location = "/Account/Authorize?client_id=web&response_type=token&state=" + encodeURIComponent(window.location.hash);
                }
            }

            return self.Views[options.name];
        });

        if (typeof options.navigatorFactory !== "undefined") {
            navigator = options.navigatorFactory(self, dataModel);
        } else {
            navigator = function () {
                window.location.hash = options.bindingMemberName;
            };
        }

        self["navigateTo" + options.name] = navigator;
    };

    self.initialize = function () {
        Sammy().run();
    };
}

var app = new AppViewModel(new AppDataModel());
