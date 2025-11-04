namespace SD_HW2;

public static class CategoryRepository
{
    private static Dictionary<int, Category> _categories = [];

    public static IEnumerable<Category> GetCategories => _categories.Values;

    public static bool AddCategory(Category cat)
    {
        if (_categories.Values.Any(category => 
                cat.Name == category.Name && 
                cat.Type == category.Type)) return false;
        
        _categories.Add(cat.Id, cat);
        
        return true;
    }

    public static void RemoveCategory(Category cat)
    {
        _categories.Remove(cat.Id);
    }
}