using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly SchoolContext context;

        public ClassroomController(SchoolContext context)
        {
            this.context = context;
        }

        // get all
        // GET: api/Classroom
        [HttpGet]
        public async Task<ActionResult<List<Classroom>>> GetClassrooms()
        {
            return await context.Classrooms
                                .Include(c => c.Students)
                                .Include(c => c.Teacher)
                                .ToListAsync();
        }

        // get by id
        // GET: api/Classroom/5
        [HttpGet("{classroomId}")]
        public async Task<ActionResult<Classroom>> GetClassroom(int classroomId)
        {
            if (classroomId <= 0)
                return BadRequest();

            var classroom = await context.Classrooms.FindAsync(classroomId);
            //var classroom = await context.Classrooms.FirstAsync(c => c.ClassroomId == classroomId);
            //var classroom = await context.Classrooms.SingleAsync(c => c.ClassroomId == classroomId);

            if (classroom == null)
                return NotFound();

            return classroom;
        }

        // add a classroom
        // POST: api/Classroom
        [HttpPost]
        public async Task<ActionResult<Classroom>> PostClassroom(Classroom classroom)
        {
            context.Classrooms.Add(classroom);
            await context .SaveChangesAsync();

            return Created($"api/classroom/{classroom.ClassroomId}", classroom);
        }

        // update a classroom
        // PUT: api/Classroom/5
        [HttpPut("{classroomId}")]
        public async Task<ActionResult<Classroom>> PutClassroom(int classroomId, Classroom classroom)
        {
            if (classroomId <= 0)
                return BadRequest();

            //context.Entry(classroom).State = EntityState.Modified;
            context.Classrooms.Update(classroom);
            await context.SaveChangesAsync();

            return NoContent();
        }

        // delete a classroom
        // DELETE: api/Classroom/5
        [HttpDelete("{classroomId}")]
        public async Task<IActionResult> DeleteClassroom(int classroomId)
        {
            if (classroomId <= 0)
                return BadRequest();

            var classroom = context.Classrooms.Single(c => c.ClassroomId == classroomId);

            if (classroom == null)
                return NotFound();

            context.Classrooms.Remove(classroom);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
