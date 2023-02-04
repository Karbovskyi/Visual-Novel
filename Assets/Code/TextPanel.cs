using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;

public class TextPanel : MonoBehaviour
{
    public Action OnPanelDone;

    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TMP_Text _text;
    
    private TweenerCore<float, float, FloatOptions> _showing;
    private ITextWritingService _textWritingService;
    
    private string _message;
    private bool _isTypingText;
    
    private void Awake()
    {
        _canvasGroup.alpha = 0;
    }

    public void ShowPanel(string message, ITextWritingService textWritingService)
    {
        _text.text = String.Empty;
            _isTypingText = false;
        _textWritingService = textWritingService;
        _message = message;
        _showing = _canvasGroup.DOFade(1, 1).OnComplete(StartTyping);
    }

    public void ForceComplete()
    {
        _showing.Kill();
        _canvasGroup.alpha = 1;
        _isTypingText = false;

        if (_isTypingText)
        {
            _textWritingService.SkipTyping();
        }
        else
        {
            _textWritingService.ShowText(_message, _text);
            OnPanelDone.Invoke();
        }
    }

    public void HidePanel()
    {
        _canvasGroup.DOFade(0, 1);
    }

    private void StartTyping()
    {
        _isTypingText = true;
        _textWritingService.TypeText(_message, _text, OnPanelDone);
    }
}