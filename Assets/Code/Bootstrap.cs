using Assets.Code.ScriptableObjects;
using Code.Services;
using Code.Services.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private StoryBlock _introBlock;
        
        private LinearStepsService _linearStepsService;
        private ITextWritingService _textWritingService;
        
    
        private void Start()
        {
            AllServices services = AllServices.Container;
            
            _textWritingService = new TextWritingService1(this);
            _linearStepsService = new LinearStepsService();
            
            services.RegisterSingle<ITextWritingService>(_textWritingService);
            services.RegisterSingle<LinearStepsService>(_linearStepsService);
            
            _introBlock.StartBlock();
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                _linearStepsService.TryForceStepComplete();
            }
        }
    }
}
