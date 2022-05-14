using System.Collections.Generic;
using DAL.Domain.Base;

namespace DAL.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
    }
}