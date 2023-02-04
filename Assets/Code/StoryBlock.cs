using System;
using UnityEngine;

public class StoryBlock : MonoBehaviour
{
    [SerializeField] private LinearStepsService _linearStepsService;
    [SerializeField] private StoryBlock[] nextBlocks;
    
    public void StartBlock()
    {
        IStep[] x = GetComponentsInChildren<IStep>();
        LinearStepsService linearStepsService = AllServices.Container.Single<LinearStepsService>();
        linearStepsService.SetSteps(x);
    }
    public void LoadBlock(int index = 0)
    {
        var newBlock=Instantiate(nextBlocks[index]);
        newBlock.StartBlock();
        Destroy(gameObject);
    }
}