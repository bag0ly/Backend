using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;
using users.Models;
using static users.Dtos;

namespace users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly List<UserDto> users=new();
        Connect connect = new Connect();
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            try
            {
                connect.connection.Open();
                string sql = "SELECT * FROM `users`";
                MySqlCommand cmd = new MySqlCommand(sql, connect.connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    var item = new UserDto(
                        reader.GetGuid(0),//0 oszlopok tehat = Id
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
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(Guid id)
        {

            try
            {
                connect.connection.Open();

                string sql = "SELECT * FROM users WHERE Id=@ID";

                MySqlCommand cmd = new MySqlCommand(sql, connect.connection);

                cmd.Parameters.AddWithValue("Id", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    var result = new UserDto(
                        reader.GetGuid("Id"),
                        reader.GetString("Name"),
                        reader.GetString("Email"),
                        reader.GetInt32("Age"),
                        reader.GetString("Created")
                        );

                    connect.connection.Close();
                    return StatusCode(200, result);
                }
                else
                {
                    Exception e = new();
                    connect.connection.Close();
                    return StatusCode(404, e.Message);
                }

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public ActionResult<User> Post(CreateUserDto createUser)
        {
            DateTime dateTime = DateTime.Now;
            string time = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = createUser.Name,
                Email = createUser.Email,
                Age = createUser.Age,
                Created = time
            };
            try
            {
                connect.connection.Open();
                string sql = $"INSERT INTO `users` (`Id`, `Name`, `Email`, `Age`, `Created`) VALUES ('{user.Id}', '{user.Name}', '{user.Email}', {user.Age}, '{user.Created}')";
                MySqlCommand cmd= new MySqlCommand(sql, connect.connection);
                cmd.ExecuteNonQuery();
                connect.connection.Close();
                return StatusCode(201, user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpDelete]
        public ActionResult Delete(DeleteUserDto deleteUserDto) 
        {
            var user = new User
            {
                Id = Guid.NewGuid()
            };
            try
            {
                connect.connection.Open();
                string sql = $"DELETE FROM `users` WHERE `users`.`Id` = '{deleteUserDto.Id}'";
                MySqlCommand cmd = new MySqlCommand(sql, connect.connection);
                cmd.ExecuteNonQuery();
                connect.connection.Close();
                return StatusCode(201, user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]

        public ActionResult UpdateUserDto(Guid Id,UpdateUserDto UpdateUser)
        {
            var user = new User
            {
                Name = UpdateUser.Name,
                Email = UpdateUser.Email,
                Age = UpdateUser.Age,
            };
            try
            {
                connect.connection.Open();
                string sql = $"UPDATE `users` SET `Name`='{user.Name}',`Email`='{user.Email}',`Age`='{user.Age}' WHERE `Id` = '{Id}'";

                MySqlCommand cmd = new MySqlCommand(sql, connect.connection);
                cmd.ExecuteNonQuery();

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
