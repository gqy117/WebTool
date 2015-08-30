var gulp = require('gulp'),
    map = require('map-stream'),
    jshint = require('gulp-jshint'),
    ts = require('gulp-typescript'),
    jsPath = './WebTool/Views/**/*.js',
    tsPath = './WebTool/**/*.ts',
    exitOnJshintError;

// On Jshint Error
exitOnJshintError = map(function(file, cb) {
    if (!file.jshint.success) {
        console.error('jshint failed');
        process.exit(1);
    }
});

// jshint
gulp.task('jshint', function() {
    return gulp.src(jsPath)
        .pipe(jshint())
        .pipe(jshint.reporter('default')
            .pipe(exitOnJshintError));
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
gulp.task('default', ['jshint', 'ts']);
