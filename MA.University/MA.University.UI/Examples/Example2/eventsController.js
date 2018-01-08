var EventsController = function () {
    this.PopulateList = function (events) {
        var jqEventsUL = $("#eventsList"); //jquery
        for (var i = 0; i < events.length; i++) {
            jqEventsUL.append("<li class='myILClass' id='" + events[i].id + "'>" + events[i].name + "</li>");
        }
        $("#eventsContainer").append(jqEventsUL);
        lowLetter();
    }

    function lowLetter() {

    }
}