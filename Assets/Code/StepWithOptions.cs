using System;
using Assets.Code;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class StepWithOptions : MonoBehaviour, IStep
{
    [SerializeField] private bool _isCanBeForceCompleted;
    [TextArea(3,10)]
    [SerializeField] private string _message;
    [SerializeField] private TextPanel _textPanel;
    [SerializeField] private VariantButton[] _variantButtons;
    [SerializeField] private bool _continueTyping;
    [SerializeField] private bool _isShowTextPanel;
    [SerializeField] private UnityEvent _whenStepCloseAction; 

    private Action _onComplete;
    private ITextWritingService _textService;
    private bool _isFinished;
    private bool _isCompleted;
    private LinearStepsService _linearStepsService;

    public void StartStep(LinearStepsService linearStepsService)
    {
        _linearStepsService = linearStepsService;
        
        _onComplete += _linearStepsService.NextStep;
        
        _textService = AllServices.Container.Single<ITextWritingService>();
        
        if(_isShowTextPanel)
        {
            _textPanel.ShowPanel(_message, _textService,_continueTyping, ShowVariants);
        }
        else
        {
            ShowVariants();
        }
    }

    private void ShowVariants()
    {

        foreach (var button in _variantButtons)
        {
            button.Show(_textService, CompleteStep);
        }
    }
    
    private void CompleteStep()
    {
        Debug.Log("Complete  " + gameObject.name);
        _isCompleted = true;
        _isCanBeForceCompleted = true;
        
            _onComplete.Invoke();
            _onComplete -= _linearStepsService.NextStep;
    }
    
    public void ForceComplete()
    {
        if (_isCanBeForceCompleted)
        {
            if (_isShowTextPanel)
            {
                _textPanel.ForceComplete();
            }
            
            _isCompleted = true;
        }
    }

    public void CloseStep()
    {
        Debug.Log("FinishStep " + transform.parent.gameObject.name);
        
        if (_isShowTextPanel)
        {
            _textPanel.HidePanel();
        }

        foreach (VariantButton button in _variantButtons)
        {
            button.Hide();
        }
        
        _isFinished = true;
        _whenStepCloseAction?.Invoke();

        Debug.Log("Complete Step " + transform.parent.gameObject.name);
        _isCompleted = true;
        transform.parent.gameObject.SetActive(false);
        //DOVirtual.DelayedCall(1.5f, CompleteStep);
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