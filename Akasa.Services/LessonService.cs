using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akasa.Data;
using Akasa.Model;
using Akasa.Services.Core;
using Microsoft.EntityFrameworkCore;

namespace Akasa.Services
{
    public class LessonService : AkasaService<Lesson>
    {
        public LessonService(AkasaDBContext context) 
            : base(context)
        {
        }

        public override async Task<Lesson> Get(int id)
        {
            return await ThisDbSet
                .Where(e => e.Id == id)
                .Include(e => e.LstLessonCost)
                .FirstAsync();
        }

    }
}
