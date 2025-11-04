namespace SD_HW2.ConsoleInteraction;

public sealed class RemoveCategoryPage : Page
{
    protected override void Render()
    {
        if (CategoryRepository.IsEmpty)
        {
            Console.WriteLine("Категорий нет");
            return;
        }
        var cat = ConsoleMethods.PickCategory();
        CategoryRepository.RemoveCategory(cat);
        Console.WriteLine("Успешно удалено");
    }
}