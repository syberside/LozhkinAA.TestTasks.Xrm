using System;
using System.Collections.Generic;
using System.Linq;
using LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.Models;
using LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.Services.Abstract;

namespace LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.EntityFramework
{
    /// <summary>
    ///     Represents IAnnotationDetailsService based on EntityFramework
    /// </summary>
    public class AnnotationService : IAnnotationDetailsService
    {
        private readonly AnnotattionsContext _context;

        public AnnotationService(AnnotattionsContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            _context = context;
        }

        public bool TryAdd(AnnotationDescription description)
        {
            if (description == null)
            {
                throw new ArgumentNullException("description");
            }
            var founded = _context.Annotations.Find(description.Id);
            if (founded == null)
            {
                _context.Annotations.Add(description);
                _context.SaveChanges();
            }
            return founded == null;
        }

        public IEnumerable<AnnotationDescription> All()
        {
            return _context.Annotations.OrderBy(a => a.Time).AsEnumerable();
        }
    }
}