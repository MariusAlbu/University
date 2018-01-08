var StudentsController = function (serviceContext) {

    this.RenderPage = function () {
        var allStudents = serviceContext.StudentService().ReadAll();
        for (var i = 0; i < allStudents.length; i++) {
            var studentCardController = new StudentCardController("divStudentCards", allStudents[i]);
            studentCardController.RenderCard();
        }
    }
}