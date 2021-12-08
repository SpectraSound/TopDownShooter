using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;
    public Text textField;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponent<Text>();
    }
    public void SetHP(int hp)
    {
        textField.text = "HP: " + hp;
        float hpF = hp;
        textField.color = Color.Lerp(Color.red, Color.green, hpF / 100);
    }
}