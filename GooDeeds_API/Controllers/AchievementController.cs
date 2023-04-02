using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Xml.Linq;

namespace GooDeeds_API.Controllers
{
    [ApiController]
    [Route("[controller]/{id?}")]
    public class AchievementController : Controller
    {
        private MySqlConnection _connection;

        public AchievementController(MySqlConnection connection)
        {
            _connection = connection;
        }

        [HttpGet(Name = "GetAchievement")]
        public IEnumerable<Achievement> Get(int? id)
        {
            if (id.HasValue)
            {
                return _connection.Query<Achievement>("select * from achievements where Id = @Id", new { Id = id });
            }
            else
            {
                return _connection.Query<Achievement>("select * from achievements");
            }
        }
    }
}
