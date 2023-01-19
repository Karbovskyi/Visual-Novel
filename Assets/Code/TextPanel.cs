using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;

public class TextPanel : MonoBehaviour
{
    public TMP_Text Text;

    [SerializeField] private CanvasGroup _canvasGroup;

    private TweenerCore<float, float, FloatOptions> _showing;
    private ITextWritingService _textWritingService;
    
    private void Start()
    {
        _canvasGroup.alpha = 0;
    }

    public void ShowPanel(string message, ITextWritingService textWritingService)
    {
        _textWritingService = textWritingService;
        
        _showing =  _canvasGroup.DOFade(1, 1).OnComplete((() =>
        {
            textWritingService.TypeText(message, Text);
        }));
    }

    public void ForceComplete()
    {
        _showing.Kill();
        _canvasGroup.alpha = 1;
        _textWritingService.TrySkipTyping();
    }

    public void HidePanel()
    {
        _canvasGroup.DOFade(0, 1);
    }
}