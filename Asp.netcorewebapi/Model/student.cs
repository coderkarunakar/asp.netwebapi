
//namespace are used to group classes and types in c#code
namespace Asp.netcorewebapi.Model
{
        
    //classes are used encapsulate data and behaviour  into single unit  
    public class student
    {

        //only 3 collections i.e id ,name,roll ,id and roll are integer and name is string 

        //it represents the id of a student with integer with initial value as zero
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public int Roll { get; set; } = 0;
    }
}
