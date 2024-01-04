using KTStoreSite.Models.Abstract;

namespace KTStoreSite.Models
{
    public class Category:LongCommonProperty
    {
        public List<Product>? Products { get; set; }
    }
}
