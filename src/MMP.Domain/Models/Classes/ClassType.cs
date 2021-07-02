using System;
using System.Collections.Generic;

namespace MMP.Domain.Models.Classes
{
    public class ClassType : Entity
    {

        public ClassType() {}

        public ClassType(string title)
        {
            Title = title;
        }

        public ClassType(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public string Title { get; set; }

        /* EF Relations */
        public IEnumerable<Class> Classes { get; set; }
    }
}