$(document).ready(function () {
    $('form').submit(function (e) {
        e.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: 'POST',
            data: $(this).serialize(),
            success: function (response) {
                if (response.success) {
                    $('#notification').html(response.message);
                    $('#notification').show();
                    // You can add additional logic here, such as redirecting after a delay
                    // setTimeout(function () { window.location.href = '/ $(document).ready(function () {
        $('form').submit(function (e) {
            e.preventDefault();

            $.ajax({
                url: $(this).attr('action'),
                type: 'POST',
                data: $(this).serialize(),
                success: function (response) {
                    if (response.success) {
                        $('#notification').html(response.message);
                        $('#notification').show();
                        // additional logic here - redirecting after a delay
                        // setTimeout(function () { window.location.href = '/addProduct'; }, 3000);
                    }
                }
            });
        });
    });'; }, 3000);
                }
            }
        });
    });
});