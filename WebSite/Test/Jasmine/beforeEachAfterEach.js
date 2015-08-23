var $window;

function sharedSetup() {

    // mainApp
    beforeEach(module('mainApp'));

    // before each
    beforeEach(module('mainApp').$inject = ['ngMock']);

    // window
    beforeEach(function () {
        module(mockUpWindow);
    });


    // after
    afterEach(function () {
    });



    // $window
    function mockUpWindow($provide) {
        $window = {
            Track: jasmine.createSpy('Track'),
            location: {
                reload: jasmine.createSpy('reload'),
                href: jasmine.createSpy('href')
            },
            App: {
                baseUrl: '/'
            },
            jQuery: {
                cookie: jasmine.createSpy('cookie')
            }
        };

        $provide.value('$window', $window);
    }

};