$(document).ready(function () {
    $(document).on("change", "#activityId", calculateTotalPoints);
    $(document).on("change", "#units", calculateTotalPoints);

    var strActivities = $("#str-activities").val();
    console.log(strActivities);

    function calculateTotalPoints() {
        var activityFound = false;
        var units = $("#units").val();
        var selectedActivity = $("#activityId").val();

        if (units != "" && selectedActivity != "") {
            if (strActivities != "") {
                var activities = strActivities.split("|");
                var pointsPerUnit = 0;
                var maxPointsPerDay = 0;

                for (var i = 0; i < activities.length; i++) {
                    var currentActivity = activities[i].split("#");
                    if (currentActivity.length == 3 && currentActivity[0] == selectedActivity) {
                        pointsPerUnit = currentActivity[1];
                        maxPointsPerDay = currentActivity[2];

                        var activityFound = true;
                    }
                }

                $("#totalPoints").val(activityFound ? (Math.min(units * pointsPerUnit, maxPointsPerDay)) : "");
            }
        }
        else {
            $("#totalPoints").val("");
        }
    }
});
