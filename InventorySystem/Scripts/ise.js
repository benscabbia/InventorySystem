'use strict';

$(function () {
    var ajaxFormSubmit = function () {
        console.log("in ajaxformsubmit");
        var $form = $(this);

        if ($form == undefined) $form = $("form[data-ise-ajax='true']");

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        }

        console.log(options);

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-ise-target"));
            $target.replaceWith(data);
        });

        return false;
    };

    var submitAutocompleteForm = function (event, ui) {
        console.log("in submitautocompleteform");
        var $input = $(this);
        
        var $form = $("#ItemSearchForm");

        $input.val(ui.item.label);        
    
        var status = $("#status").val();
        console.log(ui.item.label + "&statusTerm=" + status);
        
        var $form = $input.parents("form:first");
        $form.submit();
    };

    var createAutocomplete = function () {
        console.log("in createautocomplete");
        var $input = $(this);

        console.log("IN createUtomComple");
        var options = {
            source: $input.attr("data-ise-autocomplete"),
            select: submitAutocompleteForm
        };

        console.log(options);
        $input.autocomplete(options);
    };


    var getItemStatus = function () {
        console.log("in getitemstatus");
        var $input = $(this);
        console.log($input.val());
                              
        var $form = $("#ItemSearchForm");

        //$form.attr("method", "get");
        //$form.attr("action", $input.attr("data-ise-status"));
        //$(document.body).append($form);
        //$form.submit();
        //var options = {
        //    url: $form.attr("action"),
        //    type: $form.attr("post"),
        //    data: $form.serialize()
        //}

        $.post($input.attr("data-ise-status"), $form.serialize());


        ajaxFormSubmit();
        return false;
    }


    $("form[data-ise-ajax='true']").submit(ajaxFormSubmit);

    //$("#status").change(getItemStatus);

    $("input[data-ise-autocomplete]").each(createAutocomplete);



});