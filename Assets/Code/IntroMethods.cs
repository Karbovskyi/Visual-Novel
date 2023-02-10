using DG.Tweening;
using UnityEngine;

public class IntroMethods : MonoBehaviour
{
    public void Test1(StepFinishCallback s)
    {
        Debug.Log("Test 1");
        
        s.Invoke();
    }

    public void Test2(StepFinishCallback s)
    {
        Debug.Log("Test 2.1");
        DOVirtual.DelayedCall(5, () =>
        {
            Debug.Log("Test 2.2");
            s.Invoke();
        });
    }
}
