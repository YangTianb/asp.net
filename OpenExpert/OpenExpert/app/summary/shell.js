define(['plugins/router', 'durandal/app'], function (router, app) {
    return {
        router: router,
        search: function () {
            app.showMessage('Search not yet implemented...');
        },
        activate: function () {
            router.map([
                { route: '', title: '上传图片', moduleId: 'summary/index' }
            ]).buildNavigationModel();

            return router.activate();
        }
    };
});