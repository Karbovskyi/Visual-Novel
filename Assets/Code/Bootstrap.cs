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
        [SerializeField] private SOLinerDialogue _soLinerDialogue;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
    
        private void Start()
        {
            AllServices services = AllServices.Container;
            
            
           // ITextWritingService textWritingService = new TextWritingService1(this, _text);
           // ILinearDialogService linearDialogService = new LinearDialogService(textWritingService, _image);
            //IMainStoryService mainStoryService = new MainStoryService(linearDialogService);
            
           // _button.onClick.AddListener(linearDialogService.TryShowNextSentence);
        
           // mainStoryService.LoadDialog(_soLinerDialogue);
            
           // services.RegisterSingle<ITextWritingService>(textWritingService);
            
        }
    }
}
