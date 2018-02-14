using System.Data.Entity;

namespace TrainSystem.Models
{
    public class TrainSystemDbContext : DbContext
    {
        public virtual IDbSet<Trip> Trips { get; set; }

        public TrainSystemDbContext() : base("TrainSystem")
        {
        }
    }
}