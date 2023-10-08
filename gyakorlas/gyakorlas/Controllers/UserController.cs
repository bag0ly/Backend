using gyakorlas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using static gyakorlas.Dto;

namespace gyakorlas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly List<UserDto> users = new List<UserDto>();
        Connect connect = new Connect();
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get() {
            try
            {
                connect.connection.Open();
                string sql = "SELECT * FROM `users`";
                MySqlCommand command = new MySqlCommand(sql,connect.connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    var item = new UserDto(
                        reader.GetGuid(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetString(4)
                        );
                    users.Add(item);
                }
                connect.connection.Close();
                return StatusCode(200, users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public ActionResult<User> Post(CreatedUserDto createUser)
        {
            DateTime dt = DateTime.Now;
            string time = dt.ToString("yyyy-MM-dd HH:mm:ss");
            var user = new User {
                Id = Guid.NewGuid(),
                Name = createUser.Name,
                Email = createUser.Email,
                Age = createUser.Age,
                Created = time
            };
            try
            {
                connect.connection.Open();
                string sql = "INSERT INTO `users`(`Id`, `Name`, `Email`, `Age`, `Created`) " +
                    $"VALUES ('{user.Id}','{user.Name}','{user.Email}',{user.Age},'{user.Created}')";
                MySqlCommand command = new MySqlCommand(sql,connect.connection);
                command.ExecuteNonQuery();
                connect.connection.Close();
                return StatusCode(201, user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
    
}
