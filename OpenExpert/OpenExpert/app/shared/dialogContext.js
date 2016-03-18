define(['jquery', 'knockout', 'transitions/entrance', 'plugins/dialog', 'bootstrap'],
    // Create a dialog using Bootstrap 3
    function ($, ko, entrance, dialog) {
        return {
            addHost: function(theDialog) {
                var body = $('body');
                $('<div id="myModal" style="display: none"></div>').appendTo(body);
                theDialog.host = $('#myModal').get(0);
            },
            removeHost: function(theDialog) {
                setTimeout(function() {
                    $('#myModal').modal('hide');
                    $('body').removeClass('modal-open');
                    $('.modal-backdrop').remove();
                }, 200);

            },
            compositionComplete: function (child, parent, context) {
                
                var theDialog = dialog.getDialog(context.model);
                //$('#myModal').modal('show');
                layer.open({
                    type: 0,
                    title: '抽取时长续费',
                    maxmin: true, //开启最大化最小化按钮
                    area: ['550px', 'auto'],
                    content: $("#myModal").html()
                });
            }
        };
    });