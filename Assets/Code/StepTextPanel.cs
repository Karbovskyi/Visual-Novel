using System;
using TMPro;
using UnityEngine;

public class StepTextPanel : MonoBehaviour, IStep
{
    [SerializeField] private bool _isCanBeForceCompleted;
    [TextArea(3,10)]
    [SerializeField] private string _message;
    [SerializeField] private TextPanel _textPanel;
<<<<<<< HEAD
    [SerializeField] private bool _hideOnComplete;
=======
<<<<<<< Updated upstream
=======
    [SerializeField] private bool _hideOnComplete;
    [SerializeField] private bool _autoNextStep;
     private bool _isDone;
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> feature/valerii

    private ITextWritingService _textService;
    private bool _isClosed;
    private bool _isCompleted;
    
    private Action _onComplete;
    private LinearStepsService _linearStepsService;
    
    public void StartStep(LinearStepsService linearStepsService)
    {
        _linearStepsService = linearStepsService;
        _onComplete += _linearStepsService.NextStep;
        
        _textService = AllServices.Container.Single<ITextWritingService>();
        _textPanel.ShowPanel(_message, _textService);
        _textPanel.OnPanelDone += CompleteStep;
    }

    private void CompleteStep()
    {
        Debug.Log("000 ");
        _isCompleted = true;
        _textPanel.OnPanelDone -= CompleteStep;

        if (_autoNextStep || _isDone)
        {
            _onComplete.Invoke();
            _onComplete -= _linearStepsService.NextStep;
        }
        
        _isDone = true;
    }
    
    public void ForceComplete()
    {
        if (_isCanBeForceCompleted)
        {
            _textPanel.ForceComplete();
        }
    }

    public void CloseStep()
    {
<<<<<<< HEAD
        if(_hideOnComplete)
            _textPanel.HidePanel();
        
=======
<<<<<<< Updated upstream
        _textPanel.HidePanel();
>>>>>>> feature/valerii
        _isFinished = true;
=======
        if(_hideOnComplete)
            _textPanel.HidePanel();
        
        _isClosed = true;
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
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