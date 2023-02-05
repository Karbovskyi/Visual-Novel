using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;

public class TextPanelWithSounds : MonoBehaviour
{
    public Action OnPanelDone;
    public Action OnTextPartComplete;

    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TMP_Text _text;
    
    private TweenerCore<float, float, FloatOptions> _showing;
    private ITextWritingService _textWritingService;
    private IAudioService _audioService;
    private AudioClip[] _audioClips;
    
    private string[] _message;
    private int _i;
    
    private bool _isTypingText;


    private void Awake()
    {
        _canvasGroup.alpha = 0;
    }

    public void ShowPanel(string[] message, AudioClip[] audioClips, ITextWritingService textWritingService)
    {
        _audioService = AllServices.Container.Single<IAudioService>();
        _text.text = String.Empty;
        _audioClips = audioClips;
        _textWritingService = textWritingService;
        _message = message;
        _isTypingText = false;

        OnTextPartComplete += MessagePartComplete;
        
        _showing = _canvasGroup.DOFade(1, 1).OnComplete(() => {
            _isTypingText = true;
            WriteTextPart(message, textWritingService);
        });
    }

    private void WriteTextPart(string[] message, ITextWritingService textWritingService)
    {
        string m = message[_i];
        textWritingService.TypeText(m, _text, OnTextPartComplete, true);
    }

    private void MessagePartComplete()
    {
        PlayAudio();
        
        _i++;

        if (_i < _message.Length)
        {
            WriteTextPart(_message, _textWritingService);
        }
        else
        {
            OnTextPartComplete -= MessagePartComplete;
            OnPanelDone.Invoke();
        }
    }

    private void PlayAudio()
    {
        if (_i < _audioClips.Length)
        {
            _audioService.PlayAudio(_audioClips[_i]);
        }
    }

    public void ForceComplete()
    {
        _showing.Kill();
        _canvasGroup.alpha = 1;
        _i = 0;
        _text.text = String.Empty;

        foreach (string m in _message)
        {
            _textWritingService.ShowText(m, _text, true);
            _i++;
        }

        _i--;
        
        PlayAudio();
        
        OnPanelDone.Invoke();
    }

    public void HidePanel()
    {
        _canvasGroup.DOFade(0, 1);
    }
    
}