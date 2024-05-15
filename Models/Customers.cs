
namespace BHBE.Models
{
    public class Customers
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public double Balance { get; set; }

        public List<Accounts>? Accounts { get; set; }

    }
}
