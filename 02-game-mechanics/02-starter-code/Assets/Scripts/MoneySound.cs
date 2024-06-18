using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySound : MonoBehaviour
{
private int money = 50;
public AudioSource chaChingSFX;

public int Money {
    get { return money; }
    set 
    {  
        money = value;
        chaChingSFX.Play();
    }
}
}
