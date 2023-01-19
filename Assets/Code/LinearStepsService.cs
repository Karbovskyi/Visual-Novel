using System;
using System.Collections.Generic;
using UnityEngine;

public class LinearStepsService : MonoBehaviour
{
    
    private Queue<IStep> _sentences;

    private IStep _currentStep;
    
    public void SetSteps(IStep[] steps)
    {
        _sentences = new Queue<IStep>();
        
        foreach (IStep step in steps) 
            _sentences.Enqueue(step);
        
        StartPlaySteps();
    }

    public void TryForceStepComplete()
    {
        Debug.Log("- 1");
        if (_currentStep.IsCanBeForceCompleted())
        {
            Debug.Log("- 2");
            if (_currentStep.IsCompleted())
            {
                Debug.Log("- 3");
                NextStep();
            }
            else
            {
                Debug.Log("- 4");
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
        Debug.Log("1");
        if (TryGetNextStep(out IStep step))
        {
            Debug.Log("2");
            step.StartStep();  //todo wait previous step finished
        }
            
        else
            StepsEnd();
    }

    private bool TryGetNextStep(out IStep step)
    {
        if (_sentences.Count != 0)
        {
            _currentStep?.FinishStep();  //todo wait step finished
            step = _sentences.Dequeue();
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

    private void Start()
    {
        ITextWritingService textWritingService = new TextWritingService1(this);
        AllServices.Container.RegisterSingle(textWritingService);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("asdafsd");
            TryForceStepComplete();
        }
    }
}