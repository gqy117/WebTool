(function () {

    beforeEach(function () {
        $httpBackend.whenPOST('/Tool/WakeUp')
            .respond(200, "Done");
    });
}());
