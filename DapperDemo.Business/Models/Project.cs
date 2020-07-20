
using Dapper.Contrib.Extensions;

namespace DapperDemo.Business.Models
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
