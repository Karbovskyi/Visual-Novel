using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public delegate void StepFinishCallback();
public delegate void OnStepComplete();

public class StepAction : MonoBehaviour, IStep
{
    [SerializeField] private bool _isCanBeForceCompleted;
    
    [SerializeField] private UnityEvent<StepFinishCallback> _action;
    private Action _onComplete;
    private LinearStepsService _linearStepsService;
    
    private bool _isClosed;
    private bool _isCompleted;
    
    public void StartStep(LinearStepsService linearStepsService)
    {
        Debug.Log("StartStep");
        _linearStepsService = linearStepsService;
        _onComplete += _linearStepsService.NextStep;
        _action.Invoke(CompleteStep);
    }

    private void CompleteStep()
    {
        Debug.Log("CompleteStep");
        _isCompleted = true;
        _onComplete.Invoke();
        _onComplete -= _linearStepsService.NextStep;
    }
    
    public void ForceComplete()
    {
        if (_isCanBeForceCompleted)
        {
            CompleteStep();
        }
    }

    public void CloseStep()
    {
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
