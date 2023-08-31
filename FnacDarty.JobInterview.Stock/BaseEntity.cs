using System.ComponentModel.DataAnnotations;

namespace FnacDarty.JobInterview.Stock
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
