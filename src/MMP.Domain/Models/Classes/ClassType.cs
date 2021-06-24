using System.Collections.Generic;

namespace MMP.Domain.Models.Classes
{
    public class ClassType : Entity
    {
        public ClassType(string title)
        {
            Title = title;
        }
        
        public string Title { get; set; }

        /* EF Relations */
        public IEnumerable<Class> Classes { get; set; }
    }
}