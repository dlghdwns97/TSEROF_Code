using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallCannon : MonoBehaviour
{
    [SerializeField] private List<GameObject> _ballCannon;
    [SerializeField] private GameObject _gimmickForObject;

    public List<GameObject> Balls;
    public GameObject Player;

    IEnumerator shootcoroutine;
    private void Start()
    {
        int numOfChild = this.transform.childCount;
        GameObject obj = GameObject.Find("Ball Cannon");
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
        
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < numOfChild; j++)
            {
                int num = Random.Range(0, 6);
                GameObject Ball = Instantiate(Balls[num], _ballCannon[j].transform.position, Quaternion.identity);
                Vector3 shootDir = Player.transform.position - _ballCannon[j].transform.position;
                _gimmickForObject.GetComponent<GimmickForObject>().MovingObjectWithForce(Ball, shootDir.x, shootDir.y + 1.5f, shootDir.z, 8000f);
                Destroy(Ball, 3.0f);
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
