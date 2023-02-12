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
    [SerializeField] private AudioClip _walking;
    [SerializeField] private AudioClip _carAccident;
    [SerializeField] private Transform _examiner;
    [SerializeField] private Transform _panelExaminer3Lines;
    [SerializeField] private Transform _mainCharacter;
    [SerializeField] private Transform _panelMainCharacter3Lines;
    [SerializeField] private TextPanel _panelExaminator5Lines;
    [SerializeField] private Transform _panelStory;
    [SerializeField] private Transform _walkingGirl;
    [SerializeField] private Transform _car;
    [SerializeField] private Transform _hero2;
    
    [SerializeField] private Image _introBack;
    [SerializeField] private CanvasGroup _streetBack;
    [SerializeField] private CanvasGroup _dahBack;

    [SerializeField] private Image traficLightRed;
    [SerializeField] private Image traficLightGreen;
    private Color red=Color.red;
    private Color green=Color.green;
    private Color grey=Color.grey;
    
    
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
        _introBack.DOFade(0, 1).OnComplete(() =>
        {
            SetPanelsPositionForStreet();
            _streetBack.DOFade(1, 1).OnComplete(s.Invoke);
        });
    }

    private void SetPanelsPositionForStreet()
    {
        _panelExaminer3Lines.DOLocalMove(new Vector3(398,151,0),0.1f);
        _panelMainCharacter3Lines.DOLocalMove(new Vector3(-367,-387,0), 0.1f);
    }
    
    public void GirlMoveBehindTable(StepFinishCallback s)
    {
        _audioService.PlayAudio(_walking);
        _walkingGirl.DOLocalMove(new Vector3(-1120, -462, 0), 6f).OnComplete(() =>
        {
            _walkingGirl.eulerAngles=Vector3.zero;
            _walkingGirl.localPosition = new Vector3(-2571, -562, 0);
        });
        _walkingGirl.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 5f);
        s.Invoke();
    }

    public void MoveCar(StepFinishCallback s)
    {
        traficLightRed.DOColor(Color.gray, 1f).OnComplete(() =>
        {
            traficLightGreen.DOColor(Color.green, 1f).OnComplete((() =>
            {
                _walkingGirl.DOLocalMove(new Vector3(-2009, -456,0), 2);
                _walkingGirl.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 2);
                _audioService.PlayAudio(_carAccident);
                _car.DOLocalMove(new Vector3(-2290, -349, 0), 2).OnComplete(() =>
                    {
                        _walkingGirl.DOScale(Vector3.zero, 1).SetEase(Ease.InBounce);
                        _car.DOScale(Vector3.zero, 1).SetEase(Ease.InBounce).OnComplete(s.Invoke);
                    });
            }));
        });
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

    public void StreetTurnLeftStoryBlockClose()
    {
        _panelExaminator5Lines.HidePanel();
    }

    public void HeroJumpToDah(StepFinishCallback s)
    {
        PlayPlasmaSound(s);
        _hero2.DOScale(Vector3.zero, 1).SetEase(Ease.InBounce)
            .OnComplete(( )=>
            {
                _hero2.transform.parent = _dahBack.transform;
                _streetBack.DOFade(0, 1).OnComplete(() =>
                {
                    _dahBack.DOFade(1, 1).OnComplete(() =>
                    {
                        _hero2.DOScale(new Vector3(1.9281f, 1.9281f, 1), 1).SetEase(Ease.InBounce).OnComplete(s.Invoke);
                    });
                });
            });
    }
}