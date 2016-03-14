/**
 * Created by pc-hp on 2016/3/8.
 */
define(['plugins/http','durandal/app','knockout'], function (http,app,ko) {
    var self = {};
    self.create=function(name,style,publiclevel){
        $.ajax({
            url:"",
            data:"",
            type:"post"
        }).done(function(result){

        }).fail(function(e){

        });
        return true;
    };

    self.edit=function(albumid,name,style,publiclevel){
        alert("修改成功！");
        return true;
    };

    self.deleted=function(albumid){
        alert("删除成功！");
        return true;
    };

    self.detail=function(albumid){
        return { albumid:"1",name:"相册1" };
    };
});