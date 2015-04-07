using System.Data.Entity;
using LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.Models;

namespace LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.EntityFramework
{
    /// <summary>
    ///     DbContext for EntityFramework
    /// </summary>
    public class AnnotattionsContext : DbContext
    {
        /// <summary>
        ///     Annotations descriptions stored in DB
        /// </summary>
        public DbSet<AnnotationDescription> Annotations { get; set; }
    }
}