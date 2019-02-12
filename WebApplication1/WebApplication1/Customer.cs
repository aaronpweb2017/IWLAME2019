using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    //This is another commit (in Customer Class)...
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}