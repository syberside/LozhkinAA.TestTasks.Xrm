using System.Data.Entity.Migrations;

namespace LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.EntityFramework.Migrations
{
    /// <summary>
    /// Auto migrations configuration
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<AnnotattionsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AnnotattionsContext context)
        {

        }
    }
}