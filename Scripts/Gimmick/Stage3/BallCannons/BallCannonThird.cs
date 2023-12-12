using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCannonThird : MonoBehaviour
{
    [SerializeField] private List<GameObject> _ballCannon;
    [SerializeField] private GameObject _gimmickForObject;

    public List<GameObject> Balls;
    public GameObject Player;

    IEnumerator shootcoroutine;
    private void Start()
    {
        int numOfChild = this.transform.childCount;
        GameObject obj = GameObject.Find("Ball Cannon 3");
        if (obj != null)
        {
            for (int i = 0; i < numOfChild; i++)
            {
                if (obj.transform.GetChild(i) != null)
                    _ballCannon.Add(obj.transform.GetChild(i).gameObject);
            }
        }

        shootcoroutine = Shoot();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(shootcoroutine);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(shootcoroutine);
        }
    }
    private IEnumerator Shoot()
    {
        int numOfChild = this.transform.childCount;

        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < numOfChild; j++)
            {
                int num = Random.Range(0, 6);
                GameObject Ball = Instantiate(Balls[num], _ballCannon[j].transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity);
                Vector3 shootDir = new Vector3(0, 8.55f, 151) - _ballCannon[j].transform.position;
                _gimmickForObject.GetComponent<GimmickForObject>().MovingObjectWithForce(Ball, shootDir.x, shootDir.y, shootDir.z, 10000f);
                Destroy(Ball, 3.0f);
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
