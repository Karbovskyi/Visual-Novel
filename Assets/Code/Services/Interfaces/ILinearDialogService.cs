using Assets.Code.ScriptableObjects;
using TMPro;

namespace Code.Services.Interfaces
{
    public interface ILinearDialogService
    { 
        public void StartDialog(SOLinerDialogue soLinerDialogue);
        public void NextSentences();
        public void EndDialog();
    }
}