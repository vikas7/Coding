// .then().catch() format is promise call

const ajaxWithCallback = function (success, fail) {
    setTimeout(
        function () {
            success('call succeeds');
        }, 3000
    );

    setTimeout(
        function () {
            fail('call failed');
        }, 5000
    )
}

ajaxWithCallback(
    function (data) {
        console.log('success', data);
    },
    function (err) {
        console.log('error', err);
    }
);