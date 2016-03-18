define(['knockout', 'validation','plugins/dialog'], function (ko, validation,dialog) {

    return function() {
        var self = this;

        self.name = ko.observable().extend({ required: { params: true,message:'必填' } });
        self.type = ko.observable().extend({required:true});
        self.types = ko.observableArray([{ name: '类型1', id: '1' }, { name: '类型2', id: '2' }]);

        self.activate = function() {
            //ko.applyBindings(self);
        };
        self.submit = function () {

            self.errors = ko.validation.group(self);

            console.log(self);
            if (self.errors().length===0) {
                dialog.showMessage("提交成功");
            } else {
                self.errors.showAllMessages();
            }
        };
        return self;
    };
})