function SendPageSpeedTimings(controller, action) {

    var pageEndTime = new Date().getTime();
    var timeSpent = pageEndTime - pageStartTime;
    ga('send', 'timing', controller, action, timeSpent);
}