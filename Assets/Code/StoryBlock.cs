using System;
using UnityEngine;

public class StoryBlock : MonoBehaviour
{
    [SerializeField] private LinearStepsService _linearStepsService;
    
    private void Start()
    {
        IStep[] x = GetComponentsInChildren<IStep>();
        _linearStepsService.SetSteps(x);
    }
}