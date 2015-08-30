var gulp = require('gulp'),
    jshint = require('gulp-jshint'),
    ts = require('gulp-typescript'),
    jsPath = './WebTool/Views/**/*.js',
tsPath = './WebTool/**/*.ts';

// jshint
gulp.task('jshint', function() {
    return gulp.src(jsPath)
        .pipe(jshint())
        .pipe(jshint.reporter('default'));
});

// ts
gulp.task('ts', function() {
    var tsResult = gulp.src(tsPath)
        .pipe(ts({
            noImplicitAny: true
        }));

    return tsResult.js.pipe(gulp.dest(function(f) {
        return f.base;
    }));
});

// watch
gulp.task('watch', function() {
	gulp.watch(jsPath, ['jshint']);
    gulp.watch(tsPath, ['ts']);
});

// init
gulp.task('default', ['jshint', 'ts', 'watch']);
