var $window, $http;

function sharedSetup() {

    // mainApp
    beforeEach(module('mainApp'));

    // before
    beforeEach(function () {
        module(mockUpWindow);
        module(mockUpHttp);
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

    // $http
    function mockUpHttp($provide) {
        $http = {
            post: function () { }
        };


        spyOn($http, 'post').and.callFake(function () {
            return {
                success: function (callback) { callback({ things: 'and stuff' }) }
            };
        });

        $provide.value('$http', $http);
    }
};