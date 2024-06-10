$(document).ready(function () {
    GetCourses();
    GetInstructors();
    $("#backBTN").click(GetCourses);

})

function GetCourses() {
    let api = `https://localhost:7020/api/Course`;
    ajaxCall("GET", api, "", getSCBF, getECBF);
}
function getSCBF(result) {
    RenderCourses(result);
    console.log(result);
}

function getECBF(err) {
    console.log(err);

}

function GetInstructors(id) {
    let api = `https://localhost:7020/api/Instructor`;
     ajaxCall("GET", api, "",getISCBF, getIECBF);
}
function getISCBF(result) {
    renderInstructor(result);
    console.log(result);
}

function getIECBF(err) {
    console.log(err);

}

function renderInstructor(data) {
    for (let instructor of data) {
        localStorage.setItem(instructor.id, instructor.name);
    }
}
function RenderCourses(data)
{
    document.getElementById('backBTN').style.display = 'none';
    const container = document.getElementById('containerCourses');
    const titleDiv = document.getElementById('title');
    titleDiv.textContent = 'Udemy Courses';
    for (let course of data) {
        const courseDiv = document.createElement('div');
        courseDiv.id = "courseDiv";
        const html = `
                        <img src="${course.imageReference}" alt="${course.title}">
                        <h2>${course.title}</h2>
                        <p>Instructor: ${localStorage.getItem(course.instructorsId) }</p>
                        <p>Rating: ${course.rating.toFixed(2)}</p>
                        <p>Number of Reviews: ${course.numberOfReviews}</p>
                        <p>Last Update Date: ${course.lastUpdate}</p>
                        <p>Duration: ${course.duration}</p>
                        <a href="https://udemy.com${course.url}" target="_blank">View Course</a>
                                   `;
        courseDiv.innerHTML = html;
        let btn = document.createElement('button');
        btn.innerText = 'Show more courses of this instructor';
        btn.onclick = function () {

            let api = `https://localhost:7020/api/Instructor/` + course.instructorsId;
            ajaxCall("GET", api, "", getICSCBF, getICECBF);


        }
        courseDiv.appendChild(btn);

        container.appendChild(courseDiv);
    }
}
function getICSCBF(result) {
    RenderInstructorCourses(result);
    console.log(result);
}

function getICECBF(err) {
    console.log(err);

}
function RenderInstructorCourses(courses) {
    document.getElementById('containerCourses').innerHTML = '';
    const container = document.getElementById('containerInstructorCourses');

    //btn back to main
    document.getElementById('backBTN').style.display = 'block'; 
    //render courses
    let name;
    for (let course of courses) {
        const courseDiv = document.createElement('div');
        const title = document.createElement('h1');
        title.textContent = localStorage.getItem(course.instructorsId) + ' Courses';
        courseDiv.appendChild(title);
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
        container.appendChild(courseDiv);
        name = localStorage.getItem(course.instructorsId);
    }

    //title
    const titleDiv = document.getElementById('title');
    titleDiv.textContent = name;
}