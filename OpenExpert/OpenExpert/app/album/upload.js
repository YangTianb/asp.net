/**
 * Created by pc-hp on 2016/3/7.
 */
define(['plugins/http', 'durandal/app', 'knockout','mapping'], function (http, app, ko,mapping) {

    return function(app){
        var self = this;
        ko.mapping = mapping;
        self.title="选择上传类型";
        self.albumInfo = ko.mapping.fromJS({
            "albumId" :null,
            "name" : null,
            "desc" :null,
            "createDate": "0001-01-01T00:00:00+00:00",
            "privacyLevel": null,
            "visitPassword": null,
            "coverFileId": null,
            "categoryCode": null,
            "lastUploadDate": "0001-01-01T00:00:00+00:00"
        });
    };
});