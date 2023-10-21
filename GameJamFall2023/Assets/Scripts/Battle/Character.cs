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
        if (move)
        {
            if (reverseDir)
            {
                Vector2 newPosition = Vector2.MoveTowards(transform.position, new Vector2(x, y), speed * Time.deltaTime);
                transform.position = new Vector2(newPosition.x, newPosition.y);
                if (Mathf.Abs(this.transform.position.x - x) <= 0.05f && Mathf.Abs(this.transform.position.y - y) <= 0.05f)
                {
                    reverseDir = false;
                    move = false;
                }
            }
            else if (Mathf.Abs(this.transform.position.x) > 0.05f || Mathf.Abs(this.transform.position.y) > 0.05f) //Moving towards (0, 0)
            {
                Vector2 newPosition = Vector2.MoveTowards(transform.position, new Vector2(0, 0), speed * Time.deltaTime);
                transform.position = new Vector2(newPosition.x, newPosition.y);
            }
            else
            {
                StartCoroutine(pause());
                reverseDir = true;
            }
        }
        

    }

    private IEnumerator pause()
    {
        move = false;
        yield return new WaitForSeconds(3.0f);
        move = true;
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
