using Code.Services;
using Code.Services.Interfaces;
using UnityEngine;

namespace Code
{
    public class Bootstrap : MonoBehaviour
    {
    
        // public Stater SO
    
        private void Start()
        {

            ILinearDialogService linearDialogService = new LinearDialogService();
            IMainStoryService mainStoryService = new MainStoryService(linearDialogService);
        
            mainStoryService.LoadDialog();
        }
    }
}
