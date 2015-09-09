(function () {
    "use strict";

    beforeEach(function () {
        $httpBackend.whenPOST("/Tool/WakeUp")
            .respond(200, "Done");
    });
}());