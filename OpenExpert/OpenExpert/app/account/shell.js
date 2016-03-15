define(['plugins/router', 'durandal/app'], function (router, app) {
    return {
        router: router,
        search: function () {
            app.showMessage('Search not yet implemented...');
        },
        activate: function () {
            router.map([
                { route: '', title: '账户详情', moduleId: 'account/index' },
                { route: 'index', title: '账户详情', moduleId: 'account/index', nav: true },
                { route: 'regist', title: '接入申请', moduleId: 'account/regist', nav: true },
                { route: 'document', title: '文档', moduleId: 'account/document', nav: true },
                { route: 'data', title: '数据', moduleId: 'account/data', nav: true }
            ]).buildNavigationModel();

            return router.activate();
        }
    };
});