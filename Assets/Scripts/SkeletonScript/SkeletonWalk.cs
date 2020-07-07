using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWalk : MonoBehaviour
{
    private float speed = 3f;
    public bool walkLeft;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeDirection());
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }
    private void Walk() {
        Vector3 temp = transform.position;
        Vector3 tempScale = transform.localScale;
        if (walkLeft)
        {
            temp.x -= speed * Time.deltaTime;
            tempScale.x = -Mathf.Abs(tempScale.x);

        }
        else {
            temp.x += speed * Time.deltaTime;
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        transform.position = temp;
        transform.localScale = tempScale; 
    }


    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(3f);
        walkLeft = !walkLeft;
        StartCoroutine(ChangeDirection());


    }
}
