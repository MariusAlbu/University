var MenuController = function (serviceContext) {
    //trick to preserve the instance of the MenuController where 'this' changes its meaning
    var _self = this;

    var _studentController = new StudentsController(serviceContext);

    var _menuElements = [
        {
            Id: "Home",
            ContainerId: "divHomeContainer",
            Controller: null
        },
        {
            Id: "Students",
            ContainerId: "divStudentsContainer",
            Controller: _studentController
        },
        {
            Id: "Courses",
            ContainerId: "divCoursesContainer",
            Controller: null
        },
        {
            Id: "About",
            ContainerId: "divAboutContainer",
            Controller: null
        }
    ];

    this.GenerateMenu = function () {
        var jqNavbarContainer = $("#navbarContainer"); //ul ID
        for (i = 0; i < _menuElements.length; i++) {
            //this creates a li jQuery object
            var jqListItem = $("<li id='" + _menuElements[i].Id +"' class='nav-item'>")
                                .append("<a class='nav-link' href='#'>" + _menuElements[i].Id + "</a>");
            jqNavbarContainer.append(jqListItem);
        }

        jqNavbarContainer.on("click", "li", goToPage); 
    }

    function goToPage() {
        var jqSelectedListItem = $(this); //'this' is not the same as the one from 'this.GenerateMenu'
        //get the id of the clicked list item
        var selectedId = jqSelectedListItem.attr("id");
        var menuElementId;
        //get the containerId for the selected Id
        var selectedContainerId;
        for (index = 0; index < _menuElements.length; index++) {
            if (_menuElements[index].Id === selectedId) {
                selectedContainerId = _menuElements[index].ContainerId;
                menuElementId = index;
                //we found it, we exit the for
                break;
            }
        }

        if (!selectedContainerId) //is not undefined, null or ''
            return;

        var mainContainers = $("main > div");
        for (i = 0; i < mainContainers.length; i++) {
            if (mainContainers[i].id != selectedContainerId) {
                $(mainContainers[i]).hide();
            }
            else {
                $(mainContainers[i]).show();
                _menuElements[menuElementId].Controller.RenderPage();
            }
        }
    }
}