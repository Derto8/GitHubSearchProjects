var GithubPage = function () {

    function init() {

        let $inputValue = $("#inputName");

        let inputValue = sessionStorage.getItem("searchStr");
        if (inputValue != undefined) $inputValue.val(inputValue);

        $("#find_btn").on("click", function () {
            sessionStorage.setItem("searchStr", $inputValue.val());
        })
    }

    return {
        init: function () {
            init();
        }
    }
}();

