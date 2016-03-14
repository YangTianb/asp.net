define(['plugins/http', 'durandal/app', '../../lib/knockout/knockout-3.1.0'], function (http, app, ko) {
    var account = function () {
        this.title = '账户概述';
        this.userBeginTime = "2016年5月1日";
        this.serviceEndTime = "2016年7月1日";
        this.drawProject = "5";
        this.drawProjectEnd = "55";
        this.drawExperts = "275";
    };

    return account;
});