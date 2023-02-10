using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IntroActions : MonoBehaviour
{
    [SerializeField] private Transform _examiner;

    private Vector3 _examinerPosition;
    private Vector3 _examinerSize;
    // Start is called before the first frame update
    void Start()
    {
        _examinerPosition = new Vector3(-15, -1400, 0);
        _examinerSize = new Vector3(2.5f, 2.5f, 2.5f);
    }

    public void ExaminerFirstMove(StepFinishCallback s)
    {
        Debug.Log("ExaminerFirstMove");
        _examiner.DOLocalMove(_examinerPosition, 2).SetEase(Ease.InOutSine);
        _examiner.DOScale(_examinerSize, 2).SetEase(Ease.InOutSine);
        s.Invoke();
    }
}