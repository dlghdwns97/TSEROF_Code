
using UnityEngine;

public enum ButtonType  //여기서 필요한 아이템을 추가하면 됩니다 일단은 정해진 오브젝트가 없기 때문에 알파벳으로 두웠습니다.
{
    reset,
    widthTop,
    widthMiddle,
    widthBottom,
    lengthRight,
    lengthMiddle,
    lengthLeft
}
public class PuzzleButton : MonoBehaviour  //PuzzleButton 
{
    [SerializeField] private ButtonType _buttonType;

    private int[] _reset =  {0,0,0,
                             0,0,0,
                             0,0,0};

    private bool _isMove;
    private int _movecount;
    private Vector3 _moveTransform;
    private Vector3 _startposition;

    private void OnCollisionEnter(Collision collision)
    {
        int[] curPattern = PuzzleManager.instance.puzzleObjects.QuestionPattern();
        if (collision.gameObject.CompareTag("Player"))
        {
            _isMove = true;
            switch (_buttonType)
            {
                case ButtonType.reset:
                    PuzzleManager.instance.puzzleObjects.SettingObject(_reset);
                    break;
                case ButtonType.widthTop:
                    ThreeChangePuzzle(curPattern, 0, 1, 2);
                    PuzzleManager.instance.puzzleObjects.SettingObject(curPattern);
                    break;
                case ButtonType.widthMiddle:
                    ThreeChangePuzzle(curPattern, 3, 4, 5);
                    PuzzleManager.instance.puzzleObjects.SettingObject(curPattern);
                    break;
                case ButtonType.widthBottom:
                    ThreeChangePuzzle(curPattern, 6, 7, 8);
                    PuzzleManager.instance.puzzleObjects.SettingObject(curPattern);
                    break;
                case ButtonType.lengthRight:
                    ThreeChangePuzzle(curPattern, 0, 3, 6);
                    PuzzleManager.instance.puzzleObjects.SettingObject(curPattern);
                    break;
                case ButtonType.lengthMiddle:
                    ThreeChangePuzzle(curPattern, 1, 4, 7);
                    PuzzleManager.instance.puzzleObjects.SettingObject(curPattern);
                    break;
                case ButtonType.lengthLeft:
                    ThreeChangePuzzle(curPattern, 2, 5, 8);
                    PuzzleManager.instance.puzzleObjects.SettingObject(curPattern);
                    break;

            }
        }
    }
    private void Start()
    {
        _moveTransform = transform.position + new Vector3(0, 1f, 0);
        _startposition = transform.position;
    }

    private void Update()
    {
        if (_isMove)
        {
            Move();
        }

        Move();

    }

    private void ThreeChangePuzzle(int[] cur, int one, int two, int three)  //그냥 편하게 일반 메서드로 묶었다
    {
        cur[one] += 1;
        cur[two] += 1;
        cur[three] += 1;
        if (cur[one] == 3)
            cur[one] = 0;
        if (cur[two] == 3)
            cur[two] = 0;
        if (cur[three] == 3)
            cur[three] = 0;

    }

    private void Move()
    {
        if (_movecount == 0)
        {
            
            this.transform.position = Vector3.MoveTowards(_startposition, _moveTransform, 0.01f);//0.15f_pos1Time
            if (transform.position == _moveTransform)
            {
                _movecount++;
            }
        }


        if (_movecount == 1)
        {
            transform.position = Vector3.MoveTowards(_startposition, _moveTransform, 0.01f);//0.15f_pos1Time
            if (transform.position == _moveTransform)
            {
                _movecount--;
                _isMove = false;
            }
        }
    }

    private void ChangeMove()
    {

    }

}
