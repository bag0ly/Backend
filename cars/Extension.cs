using System.Runtime.CompilerServices;

namespace cars
{
    public static class Extension
    {
        public static CarDto AsDto(this CarDto car) 
        {
            return new CarDto(car.Id, car.Modelname, car.Description, car.Created);
        }
    }
}
