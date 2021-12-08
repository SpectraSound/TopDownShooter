using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    SpriteRenderer heroRenderer;
    public Sprite[] sprites;

    private void Start()
    {
        heroRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            heroRenderer.sprite = sprites[0];
        }
        else if (Input.GetKeyDown("2"))
        {
            heroRenderer.sprite = sprites[1];
        }
        else if (Input.GetKeyDown("3"))
        {
            heroRenderer.sprite = sprites[2];
        }
        else if (Input.GetKeyDown("4"))
        {
            heroRenderer.sprite = sprites[3];
        }
        else if (Input.GetKeyDown("5"))
        {
            heroRenderer.sprite = sprites[4];
        }
    }

}
