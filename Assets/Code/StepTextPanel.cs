using System;
using TMPro;
using UnityEngine;



public class StepTextPanel : MonoBehaviour, IStep
{
    [SerializeField] private bool _isCanBeForceCompleted;
    [TextArea(3,10)]
    [SerializeField] private string _message;
    [SerializeField] private TextPanel _textPanel;

    [SerializeField] private bool _hideOnComplete;
    [SerializeField] private bool _continueTyping;

    [SerializeField] private bool _autoNextStep;
     private bool _isDone;


    private ITextWritingService _textService;
    private bool _isClosed;
    private bool _isCompleted;
    
    private Action _onComplete;
    private LinearStepsService _linearStepsService;
    
    public void StartStep(LinearStepsService linearStepsService)
    {

        Debug.Log("Start  " + gameObject.name);
        _linearStepsService = linearStepsService;
        _onComplete += _linearStepsService.NextStep;
        
        _textService = AllServices.Container.Single<ITextWritingService>();
        _textPanel.ShowPanel(_message, _textService,_continueTyping, CompleteStep);
    }

    private void CompleteStep()
    {
        Debug.Log("Complete  " + gameObject.name);
        _isCompleted = true;
        _isCanBeForceCompleted = true;

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
            _autoNextStep = false;
            _textPanel.ForceComplete();
        }
    }

    public void CloseStep()
    {
        if(_hideOnComplete)
            _textPanel.HidePanel();
        
        _isClosed = true;
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