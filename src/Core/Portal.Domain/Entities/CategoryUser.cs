using Portal.Domain.Entities.Common;
using Portal.Domain.Entities.Users;

namespace Portal.Domain.Entities
{
    // kullanıcıların kategorilere abone olması için manuel cross table
    public class CategoryUser
    {
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public User? User { get; set; }
        public int? UserId { get; set; }
    }
}
