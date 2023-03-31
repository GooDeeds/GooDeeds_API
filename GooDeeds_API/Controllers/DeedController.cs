using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Dapper;

namespace GooDeeds_API.Controllers
{
    [ApiController]
    [Route("[controller]/{id?}")]
    public class DeedController : Controller
    {
        private MySqlConnection _connection;

        public DeedController(MySqlConnection connection)
        {
            _connection = connection;
        }

        [HttpGet(Name = "GetDeed")]
        public IEnumerable<Deed> Get(int? id)
        {
            if (id.HasValue)
            {
                return _connection.Query<Deed>("select * from deeds where Id = @Id", new { Id = id });
            }
            else
            {
                return _connection.Query<Deed>("select * from deeds");
            }
        }
    }
}
