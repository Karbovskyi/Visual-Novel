namespace Code.Services.Interfaces
{
    public interface ILinearDialogService
    { 
        public void StartDialog();
        public void NextSentences();
        public void EndDialog();
    }
}