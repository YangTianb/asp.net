﻿requirejs.config({
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
        'datatimepicker': '/lib/bootstrap/js/bootstrap-datetimepicker'
    },
    shim: {
        'bootstrap': {
            deps: ['jquery'],
            exports: 'jQuery'
        }
    }
});

define(['durandal/system', 'durandal/app'], function (system, app) {
    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    app.title = '外联管理';

    app.configurePlugins({
        router: true,
        dialog: true
    });

    app.start().then(function () {

        app.setRoot('account/shell', 'entrance');
    });
});