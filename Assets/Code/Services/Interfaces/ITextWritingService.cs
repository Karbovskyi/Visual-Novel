using System;
using TMPro;

public interface ITextWritingService :  IService
{
    public void TypeText(string message, TMP_Text text, SomeMethod onComplete, bool appendText = false);
    public void ShowText(string message, TMP_Text text, bool appendText = false);
}