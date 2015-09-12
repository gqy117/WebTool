(function () {
    "use strict";

    // mainApp
    beforeEach(module('mainApp'));

    // window
    beforeEach(module(mockUpWindow));

    // mock GaService
    beforeEach(module(mockUpGaService));

    // setup
    beforeEach(inject(function (_$httpBackend_) {
        window.$httpBackend = _$httpBackend_;
    }));

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

    // gaService
    function mockUpGaService($provide) {
        var gaService = {
            Track: jasmine.createSpy('Track')
        };

        $provide.value('gaService', gaService);
    }
}());
