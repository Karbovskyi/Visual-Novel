public interface IStep
{
    public void StartStep(LinearStepsService linearStepsService);

    public void ForceComplete();
    public void CloseStep();
    public bool IsCompleted();
    
    public bool IsCanBeForceCompleted();
}