using cars.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (var context = new CarContext())
            {
                var request = new Car();
                {
                    return Ok(context.Cars.ToList());
                };
            }
        }
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            using (var context = new CarContext())
            {
                var result = context.Cars.FirstOrDefault(x => x.Id == id);
                return Ok(result);
            }
        }
        [HttpPost]
        public ActionResult<CarDto> Post(CreatedCarDto createCar) 
        {
            using (var context = new CarContext())
            {
                var request = new Car()
                {
                    Id = Guid.NewGuid(),
                    Modelname = createCar.Modelname,
                    Description = createCar.Description,
                    Created = DateTime.Now
                };
                context.Cars.Add(request);
                context.SaveChanges();
                return Ok(request);
            }
        }
        [HttpPut]
        public ActionResult Put(Guid id,UpdatedCarDto updateCar) 
        {
            using (var context = new CarContext())
            {
                var old = context.Cars.Find(id);
                var request = new Car()
                {
                    Id = id,
                    Modelname = updateCar.Modelname,
                    Description = updateCar.Description,
                    Created = old!.Created
                };
                
                context.Cars.Update(request);
                context.SaveChanges();
                return Ok(request);
            }
        }
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            using (var context = new CarContext())
            {
                var old = context.Cars.Find(id);
                context.Cars.Remove(old!);
                context.SaveChanges();
                return Ok(old);
            }
        }
    }
}
