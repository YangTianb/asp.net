requirejs.config({
    paths: {
        'text': '/lib/require/text',
        'durandal': '/lib/durandal/js',
        'plugins': '/lib/durandal/js/plugins',
        'transitions': '/lib/durandal/js/transitions',
        'knockout': '/lib/knockout/knockout-3.1.0',
        'mapping': '/lib/knockout/knockout.mapping-latest',
        'bootstrap': '/lib/bootstrap/js/bootstrap',
        'jquery': '/lib/jquery/jquery-1.9.1',
        'layer': '/lib/layer/layer',
        'datatimepicker': '/lib/bootstrap/js/bootstrap-datetimepicker',
        'validation': '/lib/knockout/knockout.validation'
    },
    shim: {
        'bootstrap': {
            deps: ['jquery'],
            exports: 'jQuery'
        }
    }
});

define(['durandal/system', 'durandal/app', 'plugins/dialog', 'shared/dialogContext', 'datatimepicker', 'layer'],
    function (system, app, dialog, dialogContext, datatimepicker, layer) {
    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    app.title = '外联管理';

    app.configurePlugins({
        router: true,
        dialog: true
    });

    app.start().then(function () {
        dialog.addContext("MyDialog", dialogContext);
        app.setRoot('account/shell', 'entrance');
    });
});