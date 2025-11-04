namespace SD_HW2.ConsoleInteraction;

public abstract class Page
{
    protected virtual void Prepare()
    {
        Console.Clear();
    }
    protected abstract void Render();

    protected virtual void Finish()
    {
        ConsoleMethods.AwaitInput();
    }

    public void Run()
    {
        Prepare();
        Render();
        Finish();
    }
}