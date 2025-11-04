namespace SD_HW2.ConsoleInteraction;

public sealed class AddCategoryPage : Page
{
    protected override void Render()
    {
        string name = ConsoleMethods.AskForInput<string>("Введите название");
        var type = ConsoleMethods.AskForOperationType();
        if (!CategoryRepository.AddCategory(
                new Category(name, type)))
        {
            Console.WriteLine("Такая категория уже существует");
            return;
        }
        Console.WriteLine("Успешно добавлено!");
    }
}