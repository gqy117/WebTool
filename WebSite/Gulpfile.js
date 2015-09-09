var gulp = require('gulp'),
    eol = require('gulp-eol'),
    map = require('map-stream'),
    jshint = require('gulp-jshint'),
    ts = require('gulp-typescript'),
    tslint = require('gulp-tslint'),
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

// watch
gulp.task('watch', function() {
    gulp.watch(jsPath, ['jshint']);
    gulp.watch(tsPath, ['ts']);
    gulp.watch(tsPath, ['tslint']);
});

// init
gulp.task('default', ['jshint', 'ts', 'tslint']);
