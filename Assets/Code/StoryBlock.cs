using System;
using UnityEngine;

public class StoryBlock : MonoBehaviour
{
    public void StartBlock()
    {
        IStep[] x = GetComponentsInChildren<IStep>();
        LinearStepsService linearStepsService = AllServices.Container.Single<LinearStepsService>();
        linearStepsService.SetSteps(x);
    }
}