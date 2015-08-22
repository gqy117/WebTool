var $window;

function sharedSetup() {

    // mainApp
    beforeEach(module('mainApp'));

    // before
    beforeEach(function () {
        module(mockUpWindow);
    });

    // after
    afterEach(function () {
    });



    // window
    function mockUpWindow($provide) {
        $window = {
            Track: jasmine.createSpy('Track'),
            location: {
                reload: jasmine.createSpy('reload')
            },
            jQuery: {
                cookie: jasmine.createSpy('cookie')
            }
        };

        $provide.value('$window', $window);
    }
};