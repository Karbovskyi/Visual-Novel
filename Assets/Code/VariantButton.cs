using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Assets.Code
{
    public class VariantButton:MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TMP_Text Text;
        [SerializeField] private Button _button;
        [TextArea(3, 10)] [SerializeField] private string _message;
        [SerializeField] private UnityEvent<StepFinishCallback> _action;
        [SerializeField] private UnityEvent _FinishBlockAction;
        
        
        private TweenerCore<float, float, FloatOptions> _showing;
        private ITextWritingService _textWritingService;
        private StepFinishCallback _someMethod;

        private void Start()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
            _button.onClick.AddListener(OnClick);
            Debug.LogError("AAAA" + gameObject.name);
        }
        public void Show(ITextWritingService textWritingService, StepFinishCallback someMethod)
        {
            _someMethod = someMethod;
            _textWritingService = textWritingService;
            _canvasGroup.blocksRaycasts = true;
        
            _showing =  _canvasGroup.DOFade(1, 1).OnComplete((() =>
            {
                textWritingService.ShowText(_message, Text);
            }));
        }
        
        public void Hide()
        {
            _canvasGroup.DOFade(0, 1);
            _canvasGroup.blocksRaycasts = false;
        }

        public void OnClick()
        {
            
            if (_action.GetPersistentEventCount() != 0)
            {

                if (_FinishBlockAction.GetPersistentEventCount() != 0)
                {
                    _action.Invoke(X);
                }
                else
                {
                    _action.Invoke(_someMethod);
                }
            }
            else
            {
                X();
            }
        }


        public void X()
        {
            _FinishBlockAction?.Invoke();
        }

    }
}