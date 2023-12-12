
using System.Collections;
using UnityEngine;

public class PatternSign : MonoBehaviour
{
    private PuzzleObjects _puzzleObjects;

    [Header("patterns")]

    private int[] _pattern1 = {0, 2, 0,
                               2, 1, 2,
                               0, 2, 0 };
    private int[] _pattern2 ={ 2, 1, 2,
                               1, 0, 1,
                               2, 1, 2 };
    private int[] _pattern3 ={ 1, 2, 1,
                               0, 1, 0,
                               1, 2, 1 };
    private int[] _pattern4 ={ 0, 1, 2,
                               0, 1, 2,
                               1, 2, 0 };
    private int[] _pattern5 ={ 1, 1, 1,
                               1, 1, 1,
                               1, 1, 1 };
    private int[] _reset = {2,2,2,
                            2,2,2,
                            2,2,2};

    private int[][] _patterns = new int[5][];

    private int _random;

    private void Awake()
    {
        _puzzleObjects = GetComponent<PuzzleObjects>();
        StartSetting();
    }
    private void Start()
    {
        StartCoroutine(PatternChange());
    }
    public IEnumerator PatternChange()
    {
        var deleyTime = new WaitForSeconds(25f);  //���� �ڷ�ƾ�̱� ������ �������� ���̱� ���ؼ� ������ �ʱ�ȭ ���Ѽ� ����߽��ϴ�.
        while (true)
        {
            yield return deleyTime; // + ����
            _random = Random.Range(0, 5);
            PuzzleManager.instance.settingPuzzleButton.RandomSetting();
             _puzzleObjects.SettingObject(_patterns[_random]); //�̰� ����
            //_puzzleObjects.SettingObject(_patterns[4]);
            PuzzleManager.instance.puzzleObjects.SettingObject(_reset);
            AnswerPattern();
        }
    }

    private void StartSetting()  //for������ �ѹ��� �ְ� ������ ����� �� ã�ڽ��ϴ�. �Ф�
    {
        _patterns[0] = _pattern1;
        _patterns[1] = _pattern2;
        _patterns[2] = _pattern3;
        _patterns[3] = _pattern4;
        _patterns[4] = _pattern5;
    }

    public int[] AnswerPattern()
    {
        return _patterns[_random]; //�̰� ����
        //return _patterns[4];
    }
}
