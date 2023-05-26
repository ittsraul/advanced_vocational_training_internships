using WebApplication1.Domain.Entites;

namespace WebApplication1.infraestructure.persistence
{
    public class DevelopmentDataLoader
    {
        private readonly StoreContext storeContext;
        private readonly byte[] defaultImage = Convert.FromBase64String("");

        public DevelopmentDataLoader(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public void LoadData()
        {
            if (!storeContext.Categories.Any())
            {
                LoadCategories();
            }
            if (!storeContext.Item.Any())
            {
                LoadItems();
            }
        }

        private void LoadCategories()
        {
            var categories = new Category[]
            {
                new Category{ Name="Chaquetas", Image=defaultImage },
                new Category{ Name="Calzado", Image=defaultImage },
            };
            foreach (Category category in categories)
            {
                storeContext.Categories.Add(category);
            }
        }

        private void LoadItems()
        {
            var items = new Item[]
            {
                new Item{ Name="Chaquetas Multi Bolsillos", Price=19.99, CategoryId=1, Image=defaultImage },
                new Item{ Name="Calzado Para montaña",Price=29.99, CategoryId=2, Image=defaultImage },
            };
            foreach (Item item in items)
            {
                storeContext.Item.Add(item);
            }
        }
    }
}
