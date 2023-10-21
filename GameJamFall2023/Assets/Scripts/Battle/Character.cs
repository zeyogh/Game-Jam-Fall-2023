using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isStunned = false;

    public float speed = 2.0f;

    public Attack[] attacks = new Attack[2];

    private float x;

    private float y;

    private bool move = false;

    private bool reverseDir = false;

    private void Start()
    {
        x = this.transform.position.x;
        y = this.transform.position.y;
        movement();
    }

    public Character()
    {

    }

    public void FixedUpdate()
    {
        Debug.Log(this.transform.position.x + " " + this.transform.position.y);
        if (move && reverseDir)
        {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, new Vector2(x, y), speed * Time.deltaTime);
            transform.position = new Vector2(newPosition.x, newPosition.y);
            Debug.Log("backwards!");
            if (this.transform.position.x > Mathf.Abs(0.05f))
            {
                reverseDir = false;
                move = false;
                Debug.Log("stop!");
            }
        }
        else if (move && Mathf.Abs(this.transform.position.x) > 0.05f && Mathf.Abs(this.transform.position.y) > 0.05f) //Moving towards (0, 0)
        {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, new Vector2(0, 0), speed * Time.deltaTime);
            transform.position = new Vector2(newPosition.x, newPosition.y);
            //Debug.Log("forwards!");
        }
        else if (move)
        {
            StartCoroutine(pause());
            reverseDir = true;
            Debug.Log("pause!");
        }

    }

    private IEnumerator pause()
    {
        yield return new WaitForSeconds(1.0f);
    }

    public void attackBasic()
    {

    }

    public void attackSpecial()
    {

    }

    private void movement()
    {
        move = true;
        Debug.Log("move!");
    }

}
