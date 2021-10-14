using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private static List<Classroom> classrooms = new List<Classroom>()
        {
            new Classroom
            {
                ClassroomId = 1,
                Name = "Salle Bill Gates",
                Floor = 5,
                Corridor = "Rouge",
            },
            new Classroom
            {
                ClassroomId = 2,
                Name = "Salle Satya Nadella",
                Floor = 2,
                Corridor = "Jaune",
            },
            new Classroom
            {
                ClassroomId = 3,
                Name = "Salle Scott Hanselman",
                Floor = 3,
                Corridor = "Bleu",
            },
        };

        // get all
        // GET: api/Classroom
        [HttpGet]
        public ActionResult<List<Classroom>> GetClassrooms()
        {
            return classrooms;
        }

        // get by id
        // GET: api/Classroom/5
        [HttpGet("{classroomId}")]
        public ActionResult<Classroom> GetClassroom(int classroomId)
        {
            if (classroomId <= 0)
                return BadRequest();

            var classroom = classrooms.First(c => c.ClassroomId == classroomId);

            if (classroom == null)
                return NotFound();

            return classroom;
        }

        // add a classroom
        // POST: api/Classroom
        [HttpPost]
        public ActionResult<Classroom> PostClassroom(Classroom classroom)
        {
            //if(ModelState.IsValid)
            //{
            //    ModelState.AddModelError()
            //}

            classrooms.Add(classroom);

            return Created($"api/classroom/{classroom.ClassroomId}", classroom);
        }

        // update a classroom
        // PUT: api/Classroom/5
        [HttpPut("{classroomId}")]
        public ActionResult<Classroom> PutClassroom(int classroomId, Classroom classroom)
        {
            if (classroomId <= 0)
                return BadRequest();

            var classroomToUpdate = classrooms.First(c => c.ClassroomId == classroomId);

            if (classroomToUpdate == null)
                return NotFound();

            classroomToUpdate.Corridor = classroom.Corridor;
            classroomToUpdate.Floor = classroom.Floor;
            classroomToUpdate.Name = classroom.Name;

            return NoContent();
        }

        // delete a classroom
        // DELETE: api/Classroom/5
        [HttpDelete("{classroomId}")]
        public IActionResult DeleteClassroom(int classroomId)
        {
            if (classroomId <= 0)
                return BadRequest();

            var classroom = classrooms.Single(c => c.ClassroomId == classroomId);

            if (classroom == null)
                return NotFound();

            classrooms.Remove(classroom);

            return NoContent();
        }
    }
}
