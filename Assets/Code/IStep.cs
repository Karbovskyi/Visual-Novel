public interface IStep
{
    public void StartStep();

    public void ForceComplete();
    public void FinishStep();
    public bool IsCompleted();
    
    public bool IsCanBeForceCompleted();
}