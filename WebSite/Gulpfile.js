var gulp = require('gulp'),
    eol = require('gulp-eol'),
    map = require('map-stream'),
    jshint = require('gulp-jshint'),
    ts = require('gulp-typescript'),
    tslint = require('gulp-tslint'),
    concat = require('gulp-concat'),
    rebaseCssUrls = require('gulp-rebase-css-urls'),
    cleanCSS = require('gulp-clean-css'),
    jsPath = ['./WebTool/Views/**/*.js', './Test/Jasmine/Views/**/*.js'],
    tsPath = './WebTool/**/*.ts',
    tsLintPath = './WebTool/Views/**/*.ts';


// jshint
gulp.task('jshint', function() {
    return gulp.src(jsPath)
        .pipe(jshint())
        .pipe(jshint.reporter('default'))
        .pipe(jshint.reporter('fail'));
});

// ts
gulp.task('ts', function() {
    var tsResult = gulp.src(tsPath)
        .pipe(ts({
            noImplicitAny: true
        }));

    return tsResult.js
        .pipe(eol())
        .pipe(gulp.dest(function(f) {
            return f.base;
        }));
});

// tsLint
gulp.task('tslint', function() {
    var tsResult = gulp.src(tsLintPath)
        .pipe(tslint())
        .pipe(tslint.report('prose'));
});

// bundle css
gulp.task('bundle-css', function() {
    var baseFolder = './WebTool/Content/',
        cssFiles,
        allCss = 'all.css',
        allMinCss = 'all.min.css',
        allCssPath = baseFolder + allCss,
        allCssResult,
        allCssMinResult,
        saveToDest;

    cssFiles = gulp.src([
        "./WebTool/Content/assets/bootstrap/css/bootstrap.min.css",
        "./WebTool/Content/assets/css/metro.css",
        "./WebTool/Content/assets/font-awesome/css/font-awesome.css",
        "./WebTool/Content/assets/css/style.css",
        "./WebTool/Content/assets/css/sprite-home.css",
        "./WebTool/Content/assets/css/themes/default.css",
        ////"./WebTool/Content/assets/css/themes/light.css",
        "./WebTool/Content/assets/uniform/css/uniform.default.css",
        "./WebTool/Content/assets/bootstrap/css/bootstrap-responsive.min.css",
        "./WebTool/Content/Site.css",
        "./WebTool/Content/assets/css/style_responsive.css",
        "./WebTool/Content/assets/data-tables/DT_bootstrap.css",
        "./WebTool/Content/assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.css",
        "./WebTool/Content/assets/plugins/bootstrap-modal/css/bootstrap-modal.css"
    ]);

    saveToDest = function(concatedResult) {
        concatedResult.pipe(eol())
            .pipe(gulp.dest(baseFolder));
    };


    // bundle css files to all.css

    allCssResult = cssFiles.pipe(rebaseCssUrls(baseFolder))
        .pipe(concat(allCss));

    saveToDest(allCssResult);


    // minify all.css

    allCssMinResult = gulp.src(allCssPath)
        .pipe(cleanCSS({
            rebase: false
        }))
        .pipe(concat(allMinCss));
        
    saveToDest(allCssMinResult);
});




// watch
gulp.task('watch', function() {
    gulp.watch(jsPath, ['jshint']);
    gulp.watch(tsPath, ['ts']);
    gulp.watch(tsPath, ['tslint']);
    gulp.watch(tsPath, ['bundle-css']);
});

// init
gulp.task('default', ['jshint', 'ts', 'tslint', 'bundle-css']);
