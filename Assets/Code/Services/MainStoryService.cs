using Assets.Code.ScriptableObjects;
using Code.Services.Interfaces;
using UnityEngine;

namespace Code.Services
{
    public class MainStoryService : IMainStoryService
    {
        private ILinearDialogService _linearDialogService;
        
        public MainStoryService(ILinearDialogService linearDialogService)
        {
            _linearDialogService = linearDialogService;
        }
        
        public void LoadDialog(SOLinerDialogue soLinerDialogue)
        {
            _linearDialogService.StartDialog(soLinerDialogue);
        }
    }
}