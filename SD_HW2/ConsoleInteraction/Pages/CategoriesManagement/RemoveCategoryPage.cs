namespace SD_HW2.ConsoleInteraction;

public sealed class RemoveCategoryPage : Page
{
    protected override void Render()
    {
        var cat = ConsoleMethods.PickCategory();
        CategoryRepository.RemoveCategory(cat);
        Console.WriteLine("Успешно удалено");
    }
}