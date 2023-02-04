using System.Collections.Generic;
using UnityEngine;

public class LinearStepsService : IService
{
    private StoryBlock _storyBlock;
    
    private Queue<IStep> _steps;

    private IStep _currentStep;
    
    public void SetSteps(StoryBlock storyBlock ,IStep[] steps)
    {
        _storyBlock = storyBlock;
        _steps = new Queue<IStep>();
        
        foreach (IStep step in steps) 
            _steps.Enqueue(step);
        
        StartPlaySteps();
    }

    public void TryForceStepComplete()
    {
        Debug.Log("Try Force Complete " + _storyBlock.gameObject.name);
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

    private void StartPlaySteps()
    {
        NextStep();
    }
    
    public void NextStep()
    {
        if (TryGetNextStep(out IStep step))
        {
            Debug.Log("Start Next Step "  + _storyBlock.gameObject.name );
            step.StartStep();
        }
        else
        {
            
            StepsEnd();
        }
            
    }

    private bool TryGetNextStep(out IStep step)
    {
        Debug.Log("Try Get Next Step "  + _storyBlock.gameObject.name);
        if (_steps.Count != 0)
        {
            Debug.Log("Get Next Step "  + _storyBlock.gameObject.name);
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
        Debug.Log("StepsEnd "  + _storyBlock.gameObject.name );
        _storyBlock.FinishBlock();
    }
}