var ServiceContext = function () {
    var _studentService;

    this.StudentService = function () {
        if (!_studentService) {
            _studentService = new StudentService();
        }

        return _studentService;
    }
}