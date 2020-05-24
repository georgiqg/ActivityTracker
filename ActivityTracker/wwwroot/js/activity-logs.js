$(document).ready(function () {
    $(document).on("change", "#activityId", calculateTotalPoints);
    $(document).on("change", "#units", calculateTotalPoints);

    var strActivities = $("#str-activities").val();

    calculateTotalPoints();

    function calculateTotalPoints() {
        var activityFound = false;
        var units = $("#units").val();
        var selectedActivity = $("#activityId").val();

        if (selectedActivity != "") {
            if (strActivities != "") {
                var activities = strActivities.split("|");
                var pointsPerUnit = 0;
                var maxPointsPerDay = 0;
                var unitName = "";

                for (var i = 0; i < activities.length; i++) {
                    var currentActivity = activities[i].split("#");
                    if (currentActivity.length == 4 && currentActivity[0] == selectedActivity) {
                        pointsPerUnit = currentActivity[1];
                        maxPointsPerDay = currentActivity[2];
                        unitName = currentActivity[3];

                        var activityFound = true;
                    }
                }

                $("#totalPoints").val(activityFound && units != "" ? (Math.min(units * pointsPerUnit, maxPointsPerDay).toFixed(2)) : "");
                $("#activity-units").text(activityFound ? unitName : "");
            }
        }
        else {
            $("#totalPoints").val("");
            $("#activity-units").text("Units");
        }
    }
});
