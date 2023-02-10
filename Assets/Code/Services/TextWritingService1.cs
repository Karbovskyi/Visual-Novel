using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TextWritingService1 : ITextWritingService
{
    private readonly MonoBehaviour _coroutineRunner;
    public State TypingState = State.Completed;
    private bool _isNeedSkipWriting;
    private SomeMethod _onComplete;
    private Coroutine _typingCoroutine;
    
    
    private int _wordIndex;
    private string _message;
    private TMP_Text _text;

    public TextWritingService1(MonoBehaviour coroutineRunner) => 
        _coroutineRunner = coroutineRunner;

   // public void TypeText(string message, TMP_Text text, bool appendText = false)
    //{
   //     StartTyping(message, text, appendText);
   // }

    public void ShowText(string message, TMP_Text text, bool appendText = false)
    {
        if (_typingCoroutine != null)
        {
            _coroutineRunner.StopCoroutine(_typingCoroutine);
        }
        
        _message = message;
        _text = text;

        if (appendText)
        {
            _text.text += _message;
        }
        else
        {
            _text.text = _message;
        }
        
    }

    public void TypeText(string message, TMP_Text text, SomeMethod onComplete, bool appendText = false)
    {
        _onComplete = onComplete;
        StartTyping(message, text, appendText);
    }

    private void StartTyping(string message, TMP_Text text, bool appendText)
    {
        _wordIndex = 0;
        _message = message;
        _text = text;

        if (!appendText)
            _text.text = String.Empty;

        _typingCoroutine = _coroutineRunner.StartCoroutine(WriteText());
    }

    /*public void SkipTyping()
    {
        if(TypingState == State.Completed) return;

        TypingState = State.Completed;
        _text.text += _message.Substring(_wordIndex);
        _coroutineRunner.StopCoroutine(_typingCoroutine);
        Debug.Log("Skip writing ");
        _onComplete.Invoke();
    }*/

    private IEnumerator WriteText()
    {
        TypingState = State.Playing;
        
        while (TypingState != State.Completed)
        {
            char letter = _message[_wordIndex];
            _wordIndex++;
            
            _text.text += letter;
            
            yield return new WaitForSeconds(GetTimeToWait(letter));
            CheckMessageEnd();
        }
        
        Debug.Log("Complete writing ");
        _onComplete();
    }

    private void CheckMessageEnd()
    {
        if (_wordIndex >= _message.Length) 
            TypingState = State.Completed;
    }

    private static float GetTimeToWait(char letter)
    {
        float waitTime;
        switch (letter)
        {
            case '.':
            case '!':
            case '?':
                waitTime = 0.7f;
                break;
           // case ' ':
           //     waitTime = 0.12f;
           //     break;
            default:
                waitTime = 0.05f;
                break;
        }

        return waitTime;
    }


    public enum State
    {
        Playing = 0,
        Completed = 1
    }
}