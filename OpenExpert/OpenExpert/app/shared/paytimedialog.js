define(['plugins/dialog', 'knockout', 'datatimepicker','layer'], function (dialog, ko, datetimepicker,layer) {
    return function() {
        var self = this;

        self.oldendtime = ko.observable();
        self.endtime = ko.observable();
        self.activate = function () {
           $(".form_datetime").datetimepicker(
           {
               format: 'yyyy-mm-dd',
               language: 'zh-CN',
               autoclose: true,
               startDate: Date.now(),
               minView: 'month'
           });
                self.oldendtime = ko.observable("2016-1514");
             
            },
        self.submit = function() {
            console.log("submit");
        }
        return self;
    }
});