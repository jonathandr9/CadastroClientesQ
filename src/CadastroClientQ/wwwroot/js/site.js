// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var baseUrl = document.location.origin;

function displayMessage(s, e) {
    var classDetails = 'jq-has-icon jq-toast-info';

    switch (e) {
        case "error":
            classDetails = 'jq-toast-danger';
            break;
        case "success":
            classDetails = 'jq-has-icon jq-toast-success';
            break;
        case "warning":
            classDetails = 'jq-has-icon jq-toast-warning';
            break;
        default:
            classDetails = 'jq-has-icon jq-toast-info';
    }

    $.toast({
        text: s,
        position: 'top-center',
        loaderBg: '#dfe3eb',
        class: classDetails,
        hideAfter: 7000,
        stack: 6,
        showHideTransition: 'fade'
    })
};