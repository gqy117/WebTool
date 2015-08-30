var gulp = require('gulp'),
    ts = require('gulp-typescript'),
    path = './WebTool/**/*.ts';

// ts
gulp.task('ts', function() {
    var tsResult = gulp.src(path)
        .pipe(ts({
            noImplicitAny: true
        }));

    return tsResult.js.pipe(gulp.dest(function(f) {
        return f.base;
    }));
});

gulp.task('watch', function(){
	gulp.watch(path, ['ts']);
});

// init
gulp.task('default', ['ts', 'watch']);
