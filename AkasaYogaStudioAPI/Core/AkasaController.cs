using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akasa.Data;
using Microsoft.AspNetCore.Mvc;

namespace AkasaYogaStudioAPI.Core
{
    public class AkasaController : Controller
    {
        protected AkasaDBContext _context;

        public AkasaController(AkasaDBContext context)
        {
            _context = context;
        }
    }
}
