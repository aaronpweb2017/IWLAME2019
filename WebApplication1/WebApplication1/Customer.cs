using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    //This is another commit (in Customer Class)...
    //This is another commit (doing in Mac PC)...
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}