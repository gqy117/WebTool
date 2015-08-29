var gulp = require('gulp'),
ts = require('gulp-typescript'),
path = './WebTool/Views/**/*.ts';

// ts
gulp.task('ts', function () {
  var tsResult = gulp.src(path)
    .pipe(ts({
        noImplicitAny: true
      }));

  return tsResult.js.pipe(gulp.dest(function(f) {
     return f.base;
  }));
});


// init
gulp.task('default',function() {
    gulp.watch(path,['ts']);
});
