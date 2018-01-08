var StudentService = function () {
    var _students = [
        {
            Id: "1",
            FirstName: "Marius",
            LastName: "Albu",
            City: "Cluj"
        },
        {
            Id: "2",
            FirstName: "George",
            LastName: "Mihali",
            City: "Bucuresti"
        },
        {
            Id: "3",
            FirstName: "Mihai",
            LastName: "Zamfir",
            City: "Timisoara"
        },
        {
            Id: "4",
            FirstName: "Razvan",
            LastName: "Parcalab",
            City: "Carei"
        },
        {
            Id: "5",
            FirstName: "Teodora",
            LastName: "Popescu",
            City: "Mures"
        },
        {
            Id: "6",
            FirstName: "Mihai",
            LastName: "Cioban",
            City: "Timisoara"
        },
        {
            Id: "7",
            FirstName: "Gabriela",
            LastName: "Coman",
            City: "Constanta"
        },
    ];

    this.ReadAll = function () {
        return _students;
    }

    this.ReadById = function (id) {
        for (var index = 0; index < _students.length; index++) {
            if (index == _students[index].Id) {
                return _students[index];
            }
        }

        return null;
    }
}