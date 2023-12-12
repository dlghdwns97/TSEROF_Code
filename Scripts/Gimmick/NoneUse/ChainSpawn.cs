using UnityEngine;

public class ChainSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _chainPart, parentChain;

    [SerializeField]
    [Range(0, 1000)]
    private int _length = 1;

    [SerializeField]
    private float _chainPartLength = 0.21f;

    [SerializeField]
    private bool _reset, _spawn, _fixedFirst, _fixedLast;

    private void Update()
    {
        if (_reset)
        {
            foreach (GameObject temp in GameObject.FindGameObjectsWithTag("Chain"))
            {
                Destroy(temp);
            }

            _reset = false;
        }

        if (_spawn)
        {
            Spawn();

            _spawn = false;
        }
    }

    private void Spawn()
    {
        int count = (int)(_length / _chainPartLength);

        for (int i = 0; i < count; i++)
        {
            GameObject temp;

            temp = Instantiate(_chainPart, new Vector3(transform.position.x, transform.position.y + _chainPartLength * (i + 1), transform.position.z), Quaternion.identity, parentChain.transform);
            temp.transform.eulerAngles = new Vector3(180, 0 ,0);

            temp.name = parentChain.transform.childCount.ToString();

            if (i == 0)
            {
                Destroy(temp.GetComponent<CharacterJoint>());

                if (_fixedFirst)
                {
                    temp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
            }
            else
            {
                temp.GetComponent<CharacterJoint>().connectedBody = parentChain.transform.Find((parentChain.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }

        if (_fixedLast)
        {
            parentChain.transform.Find((parentChain.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
