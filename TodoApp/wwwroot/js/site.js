// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    Mask();
    AlertIsDone();
    AlertAction();
});

function Mask() {
    $(".dateConclusion").mask("99/99/9999");
}

function AlertAction() {
    $(".alertAction").click(function (e) {
        var result = confirm("Deseja realmente concluir esta ação?");

        if (result == false) {
            e.preventDefault();
        }
    });
}

function AlertIsDone() {
    $(".btnIsDone").click(function (e) {
        var result = confirm("Deseja cumprir esta tarefa?");

        if (result == false) {
            e.preventDefault();
        }
    });
}