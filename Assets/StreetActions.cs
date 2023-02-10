using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StreetActions : MonoBehaviour
{
    [SerializeField] private Transform _environment;
    private Vector3 _rightTurn;
    private Vector3 _leftTurn;
    private float _cycleLength = 1.5f;

    private void Start()
    {
        _rightTurn = new Vector3(-1920, 0, 0);
        _leftTurn = new Vector3(1920, 0, 0);
    }
    public void TurnRight()
    {
        _environment.DOLocalMove(_rightTurn, _cycleLength).SetEase(Ease.InOutSine).SetLoops(2,LoopType.Yoyo);
    }
    public void TurnLeft()
    {
        _environment.DOLocalMove(_leftTurn, _cycleLength).SetEase(Ease.InOutSine).SetLoops(2,LoopType.Yoyo);
    }
}
