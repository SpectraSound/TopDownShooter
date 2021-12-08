using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Camera map;


    private void Update()
    {
        FullScreen();
    }


    void FullScreen()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            map.gameObject.SetActive(true);
        }
        else
        {
            map.gameObject.SetActive(false);
        }
    }
}
