using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class VariantButton:MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TMP_Text Text;
        [SerializeField] private Button _button;
        [TextArea(3, 10)] [SerializeField] private string _message;
        
        private TweenerCore<float, float, FloatOptions> _showing;
        private ITextWritingService _textWritingService;
        
        private void Start()
        {
            _canvasGroup.alpha = 0;
            _button.interactable = false;
        }
        public void Show(ITextWritingService textWritingService)
        {
            _button.interactable = true;
            _textWritingService = textWritingService;
        
            _showing =  _canvasGroup.DOFade(1, 1).OnComplete((() =>
            {
                textWritingService.ShowText(_message, Text);
            }));
        }
    }
}