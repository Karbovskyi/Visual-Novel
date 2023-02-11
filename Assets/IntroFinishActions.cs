using DG.Tweening;
using UnityEngine;

public class IntroFinishActions : MonoBehaviour
{
    [SerializeField] private Transform _examiner;
    [SerializeField] private Transform _mainCharacter;

    private Vector3 _examinerPosition;
    private Vector3 _examinerSize;
    // Start is called before the first frame update
    void Start()
    {
        _examinerPosition = new Vector3(194, -510, 0);
        _examinerSize = new Vector3(0.95f, 0.95f, 0.95f);
    }

    public void ExaminerFirstMove(StepFinishCallback s)
    {
        _examiner.DOLocalMove(new Vector3(194, -510, 0), 2).SetEase(Ease.InOutSine);
        _examiner.DOScale(new Vector3(0.95f, 0.95f, 0.95f), 2).SetEase(Ease.InOutSine);
        s.Invoke();
    }

    public void Jump(StepFinishCallback s)
    {
        _examiner.DOScale(Vector3.zero, 1).SetEase(Ease.InBounce);
        _mainCharacter.DOScale(Vector3.zero, 1).SetEase(Ease.InBounce);
        s.Invoke();
    }
}