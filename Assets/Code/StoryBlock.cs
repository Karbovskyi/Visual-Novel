using System;
using UnityEngine;

public class StoryBlock : MonoBehaviour
{
    [SerializeField] private LinearStepsService _linearStepsService;
    [SerializeField] private GameObject[] nextBlocks;
    
    private void Start()
    {
        IStep[] x = GetComponentsInChildren<IStep>();
        _linearStepsService.SetSteps(x);
    }

    public void LoadBlock(int index = 0)
    {
        Instantiate(nextBlocks[index]);
        Destroy(this);
    }
}