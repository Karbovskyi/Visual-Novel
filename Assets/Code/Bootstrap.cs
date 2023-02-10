using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private StoryBlock _introBlock;
        [SerializeField] private AudioService _audio; 
        [SerializeField] private Button _tryForceScipButton; 
        
        private LinearStepsService _linearStepsService;
        private ITextWritingService _textWritingService;
        
    
        private void Start()
        {
            AllServices services = AllServices.Container;
            
            _textWritingService = new TextWritingService1(this);
            _linearStepsService = new LinearStepsService();
            
            services.RegisterSingle<ITextWritingService>(_textWritingService);
            services.RegisterSingle<LinearStepsService>(_linearStepsService);
            services.RegisterSingle<IAudioService>(_audio);
            
            _introBlock.StartBlock();
            
            _tryForceScipButton.onClick.AddListener(_linearStepsService.TryForceStepComplete);
        }
    }
}
