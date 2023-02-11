using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;

public delegate void SomeMethod();

public class TextPanel : MonoBehaviour
{

    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TMP_Text _text;
    
    private TweenerCore<float, float, FloatOptions> _showing;
    private ITextWritingService _textWritingService;
    
    private string _message;
    private bool _isForceCompleted;
    private bool _continueTyping;
    private SomeMethod _onPanelDoneCallback;

    private void Awake()
    {
        _canvasGroup.alpha = 0;
    }

    public void ShowPanel(string message, ITextWritingService textWritingService, bool continueTyping, SomeMethod onPanelDoneCallback)
    {
        Debug.Log("ShowPanel");
        _onPanelDoneCallback = onPanelDoneCallback;
        _continueTyping = continueTyping;
        
        if (!_continueTyping)
        {
            _text.text = String.Empty;
        }

        _isForceCompleted = false;
        _textWritingService = textWritingService;
        _message = message;

        if (_canvasGroup.alpha < 1)
        {
            _showing = _canvasGroup.DOFade(1, 1).OnComplete(StartTyping);
        }
        else
        {
            StartTyping();
        }
    }

    public void ForceComplete()
    {
        
        if(!_isForceCompleted)
        { 
            _isForceCompleted = true;
        
            _showing.Kill();
            _canvasGroup.alpha = 1;

            _textWritingService.ShowText(_message, _text);
        }
        
        _onPanelDoneCallback();
    }

    public void HidePanel()
    {
        _canvasGroup.DOFade(0, 1);
    }

    private void StartTyping()
    {
        _textWritingService.TypeText(_message, _text, _onPanelDoneCallback,_continueTyping);
    }
    
}