using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public enum CharType
    {
        FILLER,
        HEALER,
        BUFFER,
        DEBUFFER
    }

    public CharType type;

    public ProgressBar progressBar;

    public int specialVal; //output value

    public int specialValBase; //normal output value

    public int specialCost; //cost for special

    public bool isDebuffed;

    public bool finishedMoving;

    private const float SPEED = 150.0f;

    public Attack[] attacks = new Attack[2];

    private float origX;

    private float origY;

    private bool move = false;

    private bool reverseDir = false;

    private void Start()
    {
        origX = this.transform.position.x;
        origY = this.transform.position.y;
        //movement();
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
                Debug.Log("backwards!");
                Vector2 newPosition = Vector2.MoveTowards(transform.position, new Vector2(origX, origY), SPEED * Time.deltaTime);
                transform.position = new Vector2(newPosition.x, newPosition.y);
                if (Mathf.Abs(this.transform.position.x - origX) <= 0.05f && Mathf.Abs(this.transform.position.y - origY) <= 0.05f)
                {
                    reverseDir = false;
                    move = false;
                    finishedMoving = true;
                    Debug.Log("done!");
                }
            }
            else if (Mathf.Abs(this.transform.position.x) > 0.05f || Mathf.Abs(this.transform.position.y) > 0.05f) //Moving towards (0, 0)
            {
                Vector2 newPosition = Vector2.MoveTowards(transform.position, new Vector2(0, 0), SPEED * Time.deltaTime);
                transform.position = new Vector2(newPosition.x, newPosition.y);
                Debug.Log("forwards!");
            }
            else
            {
                Debug.Log("pause!");
                StartCoroutine(pause());
                reverseDir = true;
            }
        }
        

    }

    private IEnumerator pause()
    {
        move = false;
        yield return new WaitForSeconds(1.5f);
        move = true;
    }

    public void attackBasic(Character ch)
    {
        attacks[0].activate(ch);
    }

    public void attackSpecial(Character ch)
    {
        attacks[1].activate(ch);
    }

    public void toggleReticle(bool toggle)
    {
        transform.GetChild(0).gameObject.SetActive(toggle);
    }

    public void moveCharacter()
    {
        move = true;
    }

}
