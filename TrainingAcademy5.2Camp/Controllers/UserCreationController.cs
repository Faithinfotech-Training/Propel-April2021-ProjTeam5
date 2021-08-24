using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingAcademy5._2Camp.Models;

namespace TrainingAcademy5._2Camp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCreationController : ControllerBase
    {        
        private readonly Alien51Context _Context;


        //create parametrized constructor for getting db:Alien51


        public UserCreationController(Alien51Context _context)
        {
            _Context = _context;
        }

        //Endpoint Get Post Put Delete
        [HttpGet]
        //[EnableCors("CorsPolicy")]
        public ActionResult<List<User>> Get()
        {
            return Ok(_Context.User.ToList());
        }
        //Endpoint Get Post Put Delete

        //insert
        [HttpPost]
        //[EnableCors("CorsPolicy")]
        public ActionResult<User> Post(User user)
        {
            _Context.User.Add(user);
            _Context.SaveChanges();
            return Ok(user);
        }
        //update put
        [HttpPut]
       // [EnableCors("CorsPolicy")]
        public ActionResult<User> Put(User user)
            
        {
            var userInDb = _Context.User.FirstOrDefault(em => em.Userid== user.Userid);
            userInDb.Username = user.Username;
            userInDb.Orgid = user.Orgid;
            userInDb.Rolename = user.Rolename;
            userInDb.Password = user.Password;
            userInDb.Email = user.Email;
            userInDb.Contact = user.Contact;
            userInDb.Address = user.Address;
            userInDb.State = user.State;
            userInDb.District = user.District;
            //userInDb.Userimage = user.Userimage;
            userInDb.Createddate = user.Createddate;
            userInDb.Setpermission = user.Setpermission;
            userInDb.Isactive = user.Isactive;
            

            

            _Context.SaveChanges();
            return Ok(user);
        }

        //delete https://localhost:44351/api/Employee?id=5
        [HttpDelete]
        //[EnableCors("CorsPolicy")]
        public ActionResult<User> Delete(int id)
        {
            var userInDb = _Context.User.FirstOrDefault(em => em.Userid== id);
            _Context.Remove(userInDb);
            _Context.SaveChanges();
            return Ok(userInDb);
        }
        [HttpGet("St")]
        public JsonResult Getst(string StType)
        {
            string query = @"Select lookupname from lookup where type =" + StType;
            DataTable table = new DataTable();
            string sqlDataSource = @"Data Source=faithpropelapril.cyjryyniianp.ap-south-1.rds.amazonaws.com;Initial Catalog=Alien51;User ID=team5;Password=team5";
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);

        }




        //search by Id 
        //[HttpGet("GetUser")]
        //[EnableCors("CorsPolicy")]
        //public ActionResult<User> Get(int id)
        //{
        //    var userInDb = _Context.User.FirstOrDefault(em => em.Userid == id);//linq query
        //    return Ok(userInDb);
        //}


    }
}