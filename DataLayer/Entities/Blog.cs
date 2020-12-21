//Vo Huu Tri - 18521531 UIT
using System;

namespace DataLayer.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime DateCreate { get; set; }
    }
}