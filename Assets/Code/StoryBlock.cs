using System;
using UnityEngine;

public class StoryBlock : MonoBehaviour
{
    [SerializeField] private StoryBlock[] nextBlocks;
    private int _nextBlockIndex = 0;
    private LinearStepsService _linearStepsService;

    public void StartBlock()
    {
        IStep[] x = GetComponentsInChildren<IStep>();
        _linearStepsService = AllServices.Container.Single<LinearStepsService>();
        _linearStepsService.SetSteps(this ,x);
    }
    public void SetNextBlock(int index = 0)
    {
        _nextBlockIndex = index;
        FinishBlock();
    }

    public void FinishBlock()
    {
        
        StoryBlock newBlock = Instantiate(nextBlocks[_nextBlockIndex]);
        Debug.Log("Start New Block " + newBlock.gameObject.name);
        newBlock.StartBlock();
    }
}