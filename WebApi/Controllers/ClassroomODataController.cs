using Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class ClassroomODataController : ODataController
    {
        private readonly SchoolContext context;

        public ClassroomODataController(SchoolContext context)
        {
            this.context = context;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.context.Classrooms);
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get(int key)
        {
            var classroom = this.context.Classrooms.Find(key);
            if (classroom == null)
            {
                return NotFound($"Not found classroom with id = {key}");
            }

            return Ok(classroom);
        }
    }
}
