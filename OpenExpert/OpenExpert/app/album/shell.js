define(['plugins/router', 'durandal/app'], function (router, app) {
    return {
        router: router,
        search: function() {
            //It's really easy to show a message box.
            //You can add custom options too. Also, it returns a promise for the user's response.
            app.showMessage('Search not yet implemented...');
        },
        activate: function () {
            router.map([
                { route: '', title:'上传图片', moduleId: 'album/upload'},
                { route: 'upload', title:'上传图片', moduleId: 'album/upload' ,nav: true},
                { route: 'index', title:'相册管理', moduleId: 'album/index',nav: true },
                { route: 'flickr',title:'flickr',  moduleId: 'album/flickr', nav: true }
            ]).buildNavigationModel();
            
            return router.activate();
        }
    };
});