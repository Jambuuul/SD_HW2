namespace SD_HW2;

public interface ICommand
{
    void Execute();
    void Undo();
}