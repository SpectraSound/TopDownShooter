using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    //Hero Rigidbody
    Rigidbody2D rb2d;

    //HeroSpeed
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Get Hero rb2d
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MoveHero();
        LookAtMouse();
    }

    //Move Hero Functions

    //Regular hero movement
    private void MoveHero()
    {
        Vector2 moveChange = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb2d.MovePosition(rb2d.position + (moveChange * Time.deltaTime * speed));
    }

    //hero faces mouse
    private void LookAtMouse()
    {
        //mouse position screen
        Vector2 mousePosition = Input.mousePosition;
        //convert mouse position screen to world position
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);

        //Angle from player facing pos to mouseworld pos
        float newAngle = Vector2.Angle(Vector2.up, mouseWorldPos - (Vector2)transform.position);

        //newangle is equal to negative newangle if mouseworld pos is bigger than player pos 
        if (mouseWorldPos.x > transform.position.x)
        {
            newAngle = -newAngle;
        }

        //rotate player to newAngle
        transform.eulerAngles = new Vector3(0, 0, newAngle);
    }

    //boost function
    private void Boost()
    {
        //addforce relative to movement
    }

}
