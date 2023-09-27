using Asp.netcorewebapi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


//using statements allows us to acess various clases and namespace provided by asp.net
namespace Asp.netcorewebapi.Controllers
{
    //route template for the controller so the base url for controller will be /api/students
    //web api default route format,
    [Route("api/[controller]")]

    //below line indicates classs in apicontroller
    [ApiController]

    public class StudentsController : ControllerBase
    {

        //created a list of students with hard coded data 
        List<student> _oStudents = new List<student>()
        {
            new student(){ Id=1,Name="Shakib",Roll=1001},
            new student(){ Id=2,Name="Rabbi",Roll=1002},
            new student(){ Id=3,Name="Kiran",Roll=1003},
            new student(){ Id=4,Name="Rahul",Roll=1004},
            new student(){ Id=5,Name="mahi",Roll=1005},
        };


                //created get,get with its id,post,delete

        //in this get we can get all  the student details we have 
        //this makes gets method as a http get end point,allows us to retrive a list of students
        [HttpGet]

        //Web api that will call all the student
        public IActionResult Gets() {

            //this checks students list is empty,it returns a notfound,else ok
            if (_oStudents.Count == 0)
            {
                return NotFound("No List found");

            }
            return Ok(_oStudents);

        }



        //in this get we can get a  specific student by there id(so need to use id) and GetStudent as well
        //GET ALL THE STUDENT DETAILS
        //it marks get method as  an http get endpoint ,
        [HttpGet("GetStudent")]
        //Api that return student by student id
        public IActionResult Get(int id)
        {

            //this method uses linq(singleordefault) to find student with a specific id
            var oStudent = _oStudents.SingleOrDefault(x => x.Id == id);
            //if student is not there then notfound else ok
            if (oStudent == null)
            {
                return NotFound("Not Found Studentl");
            }
            return Ok(oStudent);
        }



        //with this we can create a new student details(need to use json format) in raw

        /*{   "id":1,
            "name":"String",
            "roll":3
        }*/
        //CREATING PURPOSE

        //this method makes save method as a http post end point,this allows to create a new student by sending json object in request body  
        [HttpPost]
        //Api that will save student

        //The ostudent parameter is automatically populated from the JSON data in the request body
        public IActionResult Save(student ostudent)
        {
            _oStudents.Add(ostudent);   
            if(_oStudents.Count==0)
            {
                return NotFound("No list Found"); 
            }
            return Ok(_oStudents);


        }


        //this is for deleting a particular student detail with there id
        //DELETING PURPOSE

        //delete student as an  http delete endpoint
        [HttpDelete]
        //Api for deleting student by
        //
        //id parameter is passed in the url as a part of url
        public IActionResult Deletestudent(int id)
        {
            var ostudent = _oStudents.SingleOrDefault(x => x.Id == id);

            //is students are empty also then notfound
            if (ostudent ==null)
            {
                return NotFound("No list Found");
            }

            //if student is found ok else notfound
            _oStudents.Remove(ostudent);
            if (_oStudents.Count == 0)
            {
                return NotFound("No list Found");
            }
            return Ok(_oStudents);  


        }



    }
}
