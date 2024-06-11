const createUserCourse = (userId, courseId) => ({ userId, courseId });
const createCourse = (id, title, url, rating, numberOfReviews, instructorsId, imageReference, duration, lastUpdate) => ({ id, title, url, rating, numberOfReviews, instructorsId, imageReference, duration, lastUpdate });

$(document).ready(function () {
    GetAdminCourses();
    $("#insertCourseBTN").click(function () {
        insertCourse();
    });
    InstructorSelect();
});

//-------------------------------------------------------//
//----------------Render Admin Courses-------------------//
//-------------------------------------------------------//
function GetAdminCourses() {
    let api = `https://localhost:7020/api/UserCourse/` + localStorage.getItem("loggedUser");
    ajaxCall("GET", api, "", getSCBF, getECBF)
}

function getSCBF(result) {
    RenderCourses(result);
    console.log(result);
}

function getECBF(err) {
    console.log(err);

}

function RenderCourses(data) {

    const container = document.getElementById('containerCourses');
    for (let course of data) {
        const courseDiv = document.createElement('div');
        courseDiv.id = "courseDiv";
        const html = `
                        <img src="${course.imageReference}" alt="${course.title}">
                        <h2>${course.title}</h2>
                        <p>Instructor: ${localStorage.getItem(course.instructorsId)}</p>
                        <p>Rating: ${course.rating.toFixed(2)}</p>
                        <p>Number of Reviews: ${course.numberOfReviews}</p>
                        <p>Last Update Date: ${course.lastUpdate}</p>
                        <p>Duration: ${course.duration}</p>
                        <a href="https://udemy.com${course.url}" target="_blank">View Course</a>
                                   `;
        courseDiv.innerHTML = html;
        let btn = document.createElement('button');
        btn.innerText = 'Edit Course';
        btn.onclick = function () {

            //let api = `https://localhost:7020/api/Instructor/` + course.instructorsId;
            //ajaxCall("GET", api, "", getICSCBF, getICECBF);


        }
        courseDiv.appendChild(btn);

        container.appendChild(courseDiv);
    }
}

//-------------------------------------------------------//
//-------------------Insert Courses----------------------//
//-------------------------------------------------------//
function insertCourse() {
    document.getElementById('containerCourses').innerHTML = "";
    editCourseForm.style.display = "block";
    document.getElementById("labelInstructorID").style.display = "block";
    document.getElementById("instructorIDTB").style.display = "block";
    document.getElementById("labelimageURL").style.display = "block";
    document.getElementById("imageURLTB").style.display = "block";
    document.getElementById("labelImageUpload").style.display = "none";
    document.getElementById("imageUpload").style.display = "none";
    $('#instructorIDTB, #imageURLTB').attr('required', 'required');
    $("#editCourseForm").submit(function (e) {
        e.preventDefault();
        submitInsertCourse();
        $("#instructorIDTB").removeAttr('required');
        $("#imageURLTB").removeAttr('required');
        $('#courseIDLabel').hide();
        $('#labelInstructorID').hide();
        $('#labelimageURL').hide();
        $('#instructorIDTB').hide();
        $('#imageURLTB').hide();
        $('#labelImageUpload').show();
        location.reload();
    });

}

//render all instructor to select option for insert course
function InstructorSelect() {
    let instructorSelect = document.getElementById('instructorIDTB');
    for (let i = 1; i <= 80; i++ ) {
        let instructorOption = document.createElement('option')
        instructorOption.text = localStorage.getItem(i);
        instructorOption.value = i;
        instructorSelect.appendChild(instructorOption);
    }
}

function submitInsertCourse() {
    let newCourse = createCourse(1, $("#courseTitleTB").val(), $("#courseURLTB").val(), 0, 0, $("#instructorIDTB").val(), $("#imageURLTB").val(), $("#courseDuration").val(), 'date')
    let api = `https://localhost:7020/api/Course`;
    ajaxCall("POST", api, JSON.stringify(newCourse), insertSCBF, insertECBF);
}

function insertSCBF(result) {
    console.log("Inserted successfully:", result);
    //let adminCourse = createUserCourse(1, result.id) 
    //let api = 'https://localhost:7020/api/UserCourse';
    //ajaxCall("POST", api, JSON.stringify(adminCourse), adminSCBF, adminECBF); //add to admin this course
    //editCourseForm.style.display = "none";
    //document.getElementById('editCourseForm').reset();
    //GetAdminCourses();
    alert("Course created successfully!");
}

function insertECBF(err) {
    console.log("Update failed:", err);
    alert("Failed to insert the course.");
  
}
function adminSCBF(result) {
    console.log(result);

}
function adminECBF(err) {
    console.log(err);
}