using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlaySlideshow : MonoBehaviour
{
    [SerializeField] Image currentSlide;

    [SerializeField] Sprite slide0;
    [SerializeField] Sprite slide1;
    [SerializeField] Sprite slide2;
    [SerializeField] Sprite slide3;
    [SerializeField] Sprite slide4;

    [SerializeField] GameObject text;
    [SerializeField] string[] phrases;

    private Sprite[] sprites;
    int index = 0;

    public bool afterFinalBoss;

    private void Start()
    {
            
            sprites = new Sprite[5];
            sprites[0] = slide0;
            sprites[1] = slide1;
            sprites[2] = slide2;
            sprites[3] = slide3;
        sprites[4] = slide4;
        text.GetComponent<TMP_Text>().text = phrases[0];


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //pressed
        {

                flipToNext();
        }
    }


    public void flipToNext()
    {
        if (index == 4)
        {
            if (!afterFinalBoss)
            {
                SceneManager.LoadScene("Final Boss");
            }
            else
            {
                SceneManager.LoadScene("Credits");
            }
        }
        else
        {
            index++;
            currentSlide.sprite = sprites[index];
            text.GetComponent<TMP_Text>().text = phrases[index];
        }
    }

}
