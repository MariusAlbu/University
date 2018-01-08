var EventsService = function () {
    var _events = [{
        "id": 1,
        "name": "Team Building"
    },
    {
        "id": 2,
        "name": "Workshop"
    }
        ,
    {
        "id": 3,
        "name": "Birthday"
    }
    ];

    this.ReadAll = function () {
        return _events;
    }

    this.Insert = function (event) {
        _event.Add(event);
    }
}