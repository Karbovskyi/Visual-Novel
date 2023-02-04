using Assets.Code;
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
    
    public void StartStep()
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