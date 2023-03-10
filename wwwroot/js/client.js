$(function () {
    // preload audio
    var toast = new Audio('media/toast.wav');

    //the 'code' class references the discount code buttons
    $('.code').on('click', function (e) {
        //this targets the element with the id of product, which is in the toast
        //the data being used to overwrite the data in the 'product' element is referenced in the
        //code class anchor tag      with the attribute 'data-product'
        $("#product").text($(this).data("product"));

        //this targets the element with the id of code, which is in the toast
        //the data being used to overwrite the data in the 'code' id element is referenced in the
        //code class anchor tag with the attribute 'data-code'
        $("#code").text($(this).data("code"));

        e.preventDefault();

        // first pause the audio (in case it is still playing)
        toast.pause();

        // reset the audio
        toast.currentTime = 0;

        // play audio
        toast.play();
        $('#toast').toast({ autohide: false }).toast('show');
    });

    $(document).keydown(function (e) {
        if (e.key == "Escape") {
            $("#toast").toast('hide');
        }
    })
});
