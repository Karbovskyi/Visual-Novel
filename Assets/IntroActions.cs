using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class IntroActions : MonoBehaviour
{
    [SerializeField] private AudioService _audioService;
    [SerializeField] private AudioClip _plasma;
    [SerializeField] private AudioClip _cough;
    [SerializeField] private Transform _examiner;
    [SerializeField] private Transform _mainCharacter;
    
    [SerializeField] private Image _introBack;
    [SerializeField] private CanvasGroup _streetBack;
    
    
    private Vector3 _examinerPosition;
    private Vector3 _examinerSize;
    // Start is called before the first frame update
    void Start()
    {
        _examinerPosition = new Vector3(-15, -1400, 0);
        _examinerSize = new Vector3(2.5f, 2.5f, 2.5f);
    }

    public void MoveExaminerFirstPosition(StepFinishCallback s)
    {
        Debug.Log("ExaminerFirstMove");
        _examiner.DOLocalMove(_examinerPosition, 2).SetEase(Ease.InOutSine);
        _examiner.DOScale(_examinerSize, 2).SetEase(Ease.InOutSine);
        s.Invoke();
    }

    public void PlayPlasmaSound(StepFinishCallback s)
    {
        _audioService.PlayAudio(_plasma);
    }
    
    public void PlayCoughSound(StepFinishCallback s)
    {
        _audioService.PlayAudio(_cough);
        s.Invoke();
    }
    
    public void ExaminerSecondMoveIntro(StepFinishCallback s)
    {
        _examiner.DOLocalMove(new Vector3(194, -510, 0), 2).SetEase(Ease.InOutSine);
        _examiner.DOScale(new Vector3(0.95f, 0.95f, 0.95f), 2).SetEase(Ease.InOutSine);
        s.Invoke();
    }

    public void ExaminerAndPlayerJumpToStreet(StepFinishCallback s)
    {
        _examiner.DOScale(Vector3.zero, 1).SetEase(Ease.InBounce);
        _mainCharacter.DOScale(Vector3.zero, 1).SetEase(Ease.InBounce);
        s.Invoke();
    }
    
    public void HideIntroAndShowStreet(StepFinishCallback s)
    {
        _introBack.DOFade(0, 1).OnComplete(() => _streetBack.DOFade(1, 1).OnComplete(s.Invoke));
    }
    
    public void GirlMoveBehindTable(StepFinishCallback s)
    {
        s.Invoke();
    }
    
    
    [SerializeField] private Transform _streetEnvironment;
    private float _cycleLength = 1.5f;
    
    public void TurnRight(StepFinishCallback s)
    {
       // _streetEnvironment.DOLocalMove(new Vector3(-1920, 0, 0), _cycleLength).SetEase(Ease.InOutSine).SetLoops(2,LoopType.Yoyo).OnComplete(s.Invoke);
        _streetEnvironment.DOLocalMove(new Vector3(-1920, 0, 0), _cycleLength).OnComplete(s.Invoke);
        
        
    }
    public void TurnLeft(StepFinishCallback s)
    {
        //_streetEnvironment.DOLocalMove(new Vector3(1920, 0, 0), _cycleLength).SetEase(Ease.InOutSine).SetLoops(2,LoopType.Yoyo).OnComplete(s.Invoke);;
        _streetEnvironment.DOLocalMove(new Vector3(1920, 0, 0), _cycleLength).OnComplete(s.Invoke);
    }
    
    public void TurnCentr(StepFinishCallback s)
    {
        _streetEnvironment.DOLocalMove(new Vector3(0, 0, 0), _cycleLength).OnComplete(s.Invoke);
    }
}