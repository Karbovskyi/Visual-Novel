using TMPro;
using UnityEngine;

public class StepTextPanel : MonoBehaviour, IStep
{
    [SerializeField] private bool _isCanBeForceCompleted;
    [SerializeField] private string _message;
    [SerializeField] private TextPanel _textPanel;

    private ITextWritingService _textService;
    private bool _isFinished;
    private bool _isCompleted;
    
    public void StartStep()
    {
        _textService = AllServices.Container.Single<ITextWritingService>();
        _textPanel.ShowPanel(_message, _textService);
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

    public void FinishStep()
    {
        _textPanel.HidePanel();
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
}