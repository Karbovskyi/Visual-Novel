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
        
        public void LoadDialog() // put SO
        {
            _linearDialogService.StartDialog(); // put SO
        }
    }
}