$("#SelectLocation").change(function () {
    $(this).parents("form").submit();
});

    function goToNewPage()
    {
        var url = document.getElementById('SelectLocation').value;
    if(url != 'none') {
        window.location = url;
        }
    }