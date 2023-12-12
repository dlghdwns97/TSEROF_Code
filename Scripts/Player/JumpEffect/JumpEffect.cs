using System.Collections;
using UnityEngine;

public class JumpEffect : MonoBehaviour
{
    private Vector3 direction;

    //SpriteRenderer render;

    //private void Start()
    //{
    //    render = GetComponent<SpriteRenderer>();
    //}

    public void OnJumpEffect(Vector3 direction)
    {
        this.direction = direction;
        StartCoroutine(DestroyEffect());
    }

    IEnumerator DestroyEffect()
    {
        //Color color = render.color;
        //for(float i = 2.0f; i >= 0.0f; i-=0.01f)
        //{
        //    color.a = i;
        //    render.color = color;
        //}
        yield return new WaitForSeconds(2.0f);

        ObjectPoolJump.ReturnObject(this);
    }

    private void Update()
    {
        transform.position = this.direction;
    }
}
