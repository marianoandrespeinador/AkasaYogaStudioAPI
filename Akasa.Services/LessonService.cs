using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akasa.Data;
using Akasa.Model;
using Akasa.Services.Core;

namespace Akasa.Services
{
    public class LessonService : AkasaService<Lesson>
    {
        public LessonService(AkasaDBContext context) 
            : base(context)
        {
        }
    }
}
