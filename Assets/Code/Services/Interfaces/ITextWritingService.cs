public interface ITextWritingService
{
    public void TypeText(string message);

    public bool TrySkipTyping();
}