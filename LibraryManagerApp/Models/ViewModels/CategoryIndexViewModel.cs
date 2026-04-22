namespace LibraryManagerApp.Models.ViewModels
{
    public class CategoryIndexViewModel
    {

        public List<Category> Categories { get; set; } = new List<Category>();
        public Category NewCategory { get; set; } = new Category();

    }
}
