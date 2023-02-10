using Assets.Code;
using DG.Tweening;
using UnityEngine;

public class StepWithOptions : MonoBehaviour, IStep
{
    [SerializeField] private bool _isCanBeForceCompleted;
    [SerializeField] private string _message;
    [SerializeField] private TextPanel _textPanel;
    [SerializeField] private VariantButton[] _variantButtons;

    private ITextWritingService _textService;
    private bool _isFinished;
    private bool _isCompleted;
    
    public void StartStep(LinearStepsService linearStepsService)
    {
        _textService = AllServices.Container.Single<ITextWritingService>();
        _textPanel.ShowPanel(_message, _textService);
        _textPanel.OnPanelDone += ShowVariants;
    }

    private void ShowVariants()
    {
        _textPanel.OnPanelDone -= ShowVariants;

        foreach (var button in _variantButtons)
        {
            button.Show(_textService);
        }
    }
    
    private void CompleteStep()
    {
        Debug.Log("Complete Step " + transform.parent.gameObject.name);
        _isCompleted = true;
        Destroy( transform.parent.gameObject);
    }
    
    public void ForceComplete()
    {
        if (_isCanBeForceCompleted)
        {
            _textPanel.ForceComplete();
            _isCompleted = true;
        }
    }

    public void CloseStep()
    {
        Debug.Log("FinishStep " + transform.parent.gameObject.name);
        _textPanel.HidePanel();
        
        foreach (VariantButton button in _variantButtons)
        {
            button.Hide();
        }
        
        _isFinished = true;

        DOVirtual.DelayedCall(1.5f, CompleteStep);
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