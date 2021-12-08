using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public int hp;
    Health Player;
    private HealthBar ui;
    private void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Health>();
        ui = GetComponentInChildren<HealthBar>();
    }
    private void Update()
    {
        if (Player.hp <= 0)
        {
            SceneManager.LoadScene("Main Menu");
        }

        ui.SetHP(hp);     
    }
}
