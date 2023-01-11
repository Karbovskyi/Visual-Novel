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
            ILinearDialogService linearDialogService = new LinearDialogService(_text, _image,this);
            IMainStoryService mainStoryService = new MainStoryService(linearDialogService);
            
            _button.onClick.AddListener(linearDialogService.NextSentences);
        
            mainStoryService.LoadDialog(_soLinerDialogue);
        }
    }
}
