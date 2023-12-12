using UnityEngine;

public class SwitchingBlock : MonoBehaviour
{
    [SerializeField] private GameObject[] _blue;
    [SerializeField] private GameObject[] _red;
    private bool _isBlue;

    private void Awake()
    {
        _blue = GameObject.FindGameObjectsWithTag("BlueBlock");
        _red = GameObject.FindGameObjectsWithTag("RedBlock");

        _isBlue = true;

        for (int i = 0; i < _red.Length; i++)
        {
            _red[i].GetComponent<Collider>().isTrigger = true;
            _red[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void Update()
    {
        SwitchBlock();
    }
    private void SwitchBlock()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isBlue)
            {
                _isBlue = false;
                for (int i = 0; i < _blue.Length; i++)
                {
                    _blue[i].GetComponent<Collider>().isTrigger = true;
                    _blue[i].GetComponent<MeshRenderer>().enabled = false;
                }
                for (int i = 0; i < _red.Length; i++)
                {
                    _red[i].GetComponent<Collider>().isTrigger = false;
                    _red[i].GetComponent<MeshRenderer>().enabled = true;
                }
            }
            else
            {
                _isBlue = true;
                for (int i = 0; i < _blue.Length; i++)
                {
                    _blue[i].GetComponent<Collider>().isTrigger = false;
                    _blue[i].GetComponent<MeshRenderer>().enabled = true;
                }
                for (int i = 0; i < _red.Length; i++)
                {
                    _red[i].GetComponent<Collider>().isTrigger = true;
                    _red[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
    }
}
