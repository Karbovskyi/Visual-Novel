using TMPro;

public interface ITextWritingService :  IService
{
    public void TypeText(string message, TMP_Text text);

    public bool TrySkipTyping();
}