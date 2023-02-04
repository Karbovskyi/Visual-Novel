using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TextWritingService1 : ITextWritingService
{
    private readonly MonoBehaviour _coroutineRunner;
    public State TypingState = State.Completed;
    private bool _isNeedSkipWriting;
    private Action _onComplete;
    private Coroutine _typingCoroutine;
    
    
    private int _wordIndex;
    private string _message;
    private TMP_Text _text;

    public TextWritingService1(MonoBehaviour coroutineRunner) => 
        _coroutineRunner = coroutineRunner;
    
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

    public void TypeText(string message, TMP_Text text, Action onComplete, bool appendText = false)
    {
        _wordIndex = 0;
        _message = message;
        _text = text;
        _onComplete = onComplete;

        if(!appendText)
            _text.text = String.Empty;
        
        _typingCoroutine = _coroutineRunner.StartCoroutine(WriteText());
    }

    public void SkipTyping()
    {
        if(TypingState == State.Completed) return;

        TypingState = State.Completed;
        _text.text += _message.Substring(_wordIndex);
        _coroutineRunner.StopCoroutine(_typingCoroutine);
        _onComplete.Invoke();
    }

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
        
        _onComplete.Invoke();
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