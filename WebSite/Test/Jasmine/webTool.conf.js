// Karma configuration
// Generated on Sat Aug 22 2015 13:17:30

module.exports = function (config) {
    var webToolPath = '../../WebTool/',
        frameworkFiles,
        includedFiles,
        testFiles,
        files;

    frameworkFiles = [
        webToolPath + 'Scripts/jquery/jquery-1.8.3.min.js',
        webToolPath + 'Scripts/jquery.cookie.js',
        webToolPath + 'Scripts/angular/angular.js',
        webToolPath + 'Scripts/angular-mocks.js',
        webToolPath + 'Content/assets/js/app.js'
    ];

    includedFiles = [
        webToolPath + 'Views/Shared/Library/main.app.js',
        webToolPath + 'Views/Shared/Library/jQuery.service.js',
        webToolPath + 'Views/**/*.js'
    ];

    testFiles = [
        'BeforeEach/beforeEachAfterEach.js',
        'BeforeEach/httpBackend/**/*.js',
        'Views/**/*.js'
    ];

    files = [].concat(frameworkFiles, includedFiles, testFiles);

    config.set({

        // base path that will be used to resolve all patterns (eg. files, exclude)

        // frameworks to use
        // available frameworks: https://npmjs.org/browse/keyword/karma-adapter
        frameworks: ['jasmine'],


        // list of files / patterns to load in the browser
        files: files,


        // list of files to exclude
        exclude: [],


        // preprocess matching files before serving them to the browser
        // available preprocessors: https://npmjs.org/browse/keyword/karma-preprocessor
        preprocessors: {},


        // test results reporter to use
        // possible values: 'dots', 'progress'
        // available reporters: https://npmjs.org/browse/keyword/karma-reporter
        reporters: ['spec'],


        // web server port
        port: 9876,


        // enable / disable colors in the output (reporters and logs)
        colors: true,


        // level of logging
        // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
        logLevel: config.LOG_INFO,


        // enable / disable watching file and executing tests whenever any file changes
        autoWatch: true,


        // start these browsers
        // available browser launchers: https://npmjs.org/browse/keyword/karma-launcher
        browsers: ['Chrome'],


        // Continuous Integration mode
        // if true, Karma captures browsers, runs the tests and exits
        singleRun: true

    });
}
