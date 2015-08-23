(function () {

    // mainApp
    beforeEach(module('mainApp'));

    // window
    // TODO move it to the constructor
    beforeEach(module(mockUpWindow));


    // after
    afterEach(function () {
    });



    // $window
    function mockUpWindow($provide) {
        window.$window = {
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
}());
