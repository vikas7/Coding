// .then().catch() format is promise call

const ajaxWithPromise = function () {
    return new Promise
        (
            function (resolve, reject) {
                setTimeout(
                    function () {
                        resolve('call succeeds');
                    }, 3000
                );
                setTimeout(
                    function () {
                        reject('call fails');
                    }, 5000
                );
            }
        )

}

ajaxWithPromise().
    then(function (data) {
        console.log('success', data);
    }).catch(function (err) {
        console.log('error', err);
    })

