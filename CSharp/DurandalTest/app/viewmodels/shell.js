define(['plugins/router', 'durandal/app'], function (router, app) {
    return {
        router: router,
        activate: function () {
            router.map([
                { route: '', title: '相册管理', moduleId: 'viewmodels/albumIndex' },
                { route: 'Album/Index', title: '相册管理', moduleId: 'viewmodels/albumIndex', nav: true },
                { route: 'Album/Upload', title: '上传图片', moduleId: 'viewmodels/albumUpload', nav: true }
            ]).buildNavigationModel();
            return router.activate();
        }
    };
});