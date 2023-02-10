using UnityEngine;

public class StepTextPanelWithSounds : MonoBehaviour
{

}
/*, IStep
{
[SerializeField] private bool _isCanBeForceCompleted;
[TextArea(3,10)]
[SerializeField] private string[] _message;
[SerializeField] private AudioClip[] _audioClips;
[SerializeField] private TextPanelWithSounds _textPanel;
[SerializeField] private bool _hideOnComplete;
>>>>>>> feature/valerii

>>>>>>> Stashed changes

private ITextWritingService _textService;
private bool _isFinished;
private bool _isCompleted;

public void StartStep()
{
    _textService = AllServices.Container.Single<ITextWritingService>();
    _textPanel.ShowPanel(_message, _audioClips, _textService);
    _textPanel.OnPanelDone += CompleteStep;
}


private void CompleteStep()
{
    _isCompleted = true;
    _textPanel.OnPanelDone -= CompleteStep;
}

public void ForceComplete()
{
    if (_isCanBeForceCompleted)
    {
        _textPanel.ForceComplete();
        _isCompleted = true;
    }
}

<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public void FinishStep()
    {
        if(_hideOnComplete)
            _textPanel.HidePanel();
        
        _isFinished = true;
    }
=======
=======
>>>>>>> Stashed changes
public void CloseStep()
{
    if(_hideOnComplete)
        _textPanel.HidePanel();
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    
    _isFinished = true;
}

public bool IsCompleted()
{
    return _isCompleted;
}

public bool IsCanBeForceCompleted()
{
    return _isCanBeForceCompleted;
}
}*/