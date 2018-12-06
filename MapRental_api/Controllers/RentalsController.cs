using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapRental_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MapRental_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        //db ref//
        private MapRentalModel db;

        public RentalsController(MapRentalModel db)
        {
            this.db = db;
        }

        //GET: api/rentals
        [HttpGet]
        public IEnumerable<Rental> GET()
        {
            return db.Rentals.OrderBy(r => r.Title).ToList();
        }
        //GET: api/rentals/:id
        [HttpGet("{id}")]
        public ActionResult GET(int id)
        {
            Rental rental = db.Rentals.Find(id);
            //check/validation for id//
            if (rental == null)
            {
                return NotFound();
            }
            return Ok(rental);
        }
        //POST: api/rentals 
        [HttpPost]
        public ActionResult Post([FromBody] Rental rental)
        {

            if(!ModelState.IsValid)
            {
                //badrequest if model is not valid
                return BadRequest();
            }
            db.Rentals.Add(rental);
            db.SaveChanges();
            //model is valid, send a 201 status code with newly created rental
            return CreatedAtAction("Post", rental); 
        }
        //PUT: api/rentals
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Rental rental)
        {
            if (!ModelState.IsValid)
            {
                //badrequest if model is not valid
                return BadRequest();
            }
            db.Entry(rental).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }
        //DELETE: api/rentals/:id
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Rental rental = db.Rentals.Find(id);
            //check/validation for id//
            if (rental == null)
            {
                return NotFound();
            }
            db.Rentals.Remove(rental);
            db.SaveChanges();
            return Ok();
        }
    }
}