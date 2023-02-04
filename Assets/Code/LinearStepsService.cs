using System.Collections.Generic;
using UnityEngine;

public class LinearStepsService : IService
{
    private Queue<IStep> _steps;

    private IStep _currentStep;
    
    public void SetSteps(IStep[] steps)
    {
        _steps = new Queue<IStep>();
        
        foreach (IStep step in steps) 
            _steps.Enqueue(step);
        
        StartPlaySteps();
        Debug.Log("NewBlock");
    }

    public void TryForceStepComplete()
    {
        if (_currentStep.IsCanBeForceCompleted())
        {
            if (_currentStep.IsCompleted())
            {
                NextStep();
            }
            else
            {
                _currentStep.ForceComplete();
            }
        }
    }
    
    public void StartPlaySteps()
    {
        NextStep();
    }
    
    private void NextStep()
    {
        if (TryGetNextStep(out IStep step))
        {
            step.StartStep();
        }
            
        else
            StepsEnd();
    }

    private bool TryGetNextStep(out IStep step)
    {
        if (_steps.Count != 0)
        {
            _currentStep?.FinishStep();
            step = _steps.Dequeue();
            _currentStep = step;
            return true;
        }

        step = null;
        return false;
    }

    private void StepsEnd()
    {
        Debug.Log("StepsEnd");
    }
    
}