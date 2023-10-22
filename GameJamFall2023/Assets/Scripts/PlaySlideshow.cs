using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaySlideshow : MonoBehaviour
{
    [SerializeField] Image currentSlide;
    [SerializeField] bool start;

    [SerializeField] Sprite slide0;
    [SerializeField] Sprite slide1;
    [SerializeField] Sprite slide2;
    [SerializeField] Sprite slide3;
    [SerializeField] Sprite slide4;
    [SerializeField] Sprite slide5;
    [SerializeField] Sprite slide6;

    [SerializeField] GameObject text;

    private Sprite[] sprites;
    int index = 1;

    private void Start()
    {

        if (!start)
        {
            sprites = new Sprite[4];
            sprites[0] = slide0;
            sprites[1] = slide1;
            sprites[2] = slide2;
            sprites[3] = slide3;
        }
        else
        {
            sprites = new Sprite[7];
            sprites[0] = slide0;
            sprites[1] = slide1;
            sprites[2] = slide2;
            sprites[3] = slide3;
            sprites[4] = slide4;
            sprites[5] = slide5;
            sprites[6] = slide6;
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //pressed
        {

            if (!start && index == 4)
            {
                SceneManager.LoadScene("Credits");
            }
            else
            {
                flipToNext();
            }
        }
    }


    public void flipToNext()
    {
        currentSlide.sprite = sprites[index];
        if (!start && index == 3)
        {
            text.SetActive(true);
        }
        index++;
    }

}
