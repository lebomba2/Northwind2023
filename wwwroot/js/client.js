$(function () {
    // preload audio
    var toast = new Audio('media/toast.wav');

    $('.code').on('click', function (e) {
        $("#product").text($(this).data("product"));
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
