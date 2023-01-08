using Assets.Code.ScriptableObjects;
using Code.Services;
using Code.Services.Interfaces;
using TMPro;
using UnityEngine;

namespace Code
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private SOLinerDialogue _soLinerDialogue;
        [SerializeField] private TMP_Text _text;
    
        private void Start()
        {
            ILinearDialogService linearDialogService = new LinearDialogService(_text);
            IMainStoryService mainStoryService = new MainStoryService(linearDialogService);
        
            mainStoryService.LoadDialog(_soLinerDialogue);
        }
    }
}
