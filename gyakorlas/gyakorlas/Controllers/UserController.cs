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
                throw;
            }
        }
    }
}
