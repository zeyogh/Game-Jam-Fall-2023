using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script : MonoBehaviour
{
    [SerializeField] Image currentSlide;

    [SerializeField] Sprite slide0;
    [SerializeField] Sprite slide1;
    [SerializeField] Sprite slide2;
    [SerializeField] Sprite slide3;
    [SerializeField] Sprite slide4;
    [SerializeField] Sprite slide5;
    [SerializeField] Sprite slide6;
    [SerializeField] Sprite slide7;
    [SerializeField] Sprite slide8;
    [SerializeField] Sprite slide9;

    [SerializeField] Sprite secondFrame;

    private Sprite[] sprites;

    private float nextActionTime = 0.0f;

    private int index = 1;

    private void Start()
    {
        sprites = new Sprite[10];
        sprites[0] = slide0;
        sprites[1] = slide1;
        sprites[2] = slide2;
        sprites[3] = slide3;
        sprites[4] = slide4;
        sprites[5] = slide5;
        sprites[6] = slide6;
        sprites[7] = slide7;
        sprites[8] = slide8;
        sprites[9] = slide9;


    }

    void Update()
    {
        if (index == 6)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += Time.time + .5f;
                if (currentSlide.sprite == slide6)
                {
                    currentSlide.sprite = secondFrame;
                    Debug.Log("next: " + nextActionTime + " Time.time: " + Time.time);
                }
                else
                {
                    currentSlide.sprite = slide6;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) //pressed
        {

            if (index == 10)
            {
                SceneManager.LoadScene("YearsLater");
            }
            else
            {
                flipToNext();
            }
        }
    }


    public void flipToNext()
    {
        Debug.Log(index);
        currentSlide.sprite = sprites[index];
        index++;
    }

}
