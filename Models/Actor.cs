using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ActorId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<MovieActor> MovieActors { get; set; }
    }
}
