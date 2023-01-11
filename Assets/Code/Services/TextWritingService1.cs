using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class TextWritingService1 : ITextWritingService
{
    private readonly MonoBehaviour _coroutineRunner;
    private readonly TMP_Text _text;
    private State _state = State.Completed;
    private bool _isNeedSkipWriting;

    public TextWritingService1(MonoBehaviour coroutineRunner , TMP_Text text)
    {
        _coroutineRunner = coroutineRunner;
        _text = text;
    }

    public void TypeText(string message) => 
        _coroutineRunner.StartCoroutine(WriteText(message));

    public bool TrySkipTyping() => 
        _isNeedSkipWriting = _state == State.Playing;

    private IEnumerator WriteText(string message)
    {
        _isNeedSkipWriting = false;
        _state = State.Playing;
        _text.text = String.Empty;
        int wordIndex = 0;

        while (_state != State.Completed)
        {
            char letter = message[wordIndex];
            wordIndex++;
            
            _text.text += letter;

            if (_isNeedSkipWriting)
            {
                _text.text += message.Substring(wordIndex);
                _state = State.Completed;
            }
            else
            {
                yield return new WaitForSeconds(GetTimeToWait(letter));
                CheckMessageEnd(message.Length, wordIndex);
            }
        }
    }

    private void CheckMessageEnd(int length, int wordIndex)
    {
        if (wordIndex >= length) _state = State.Completed;
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


    private enum State
    {
        Playing = 0,
        Completed = 1
    }
}