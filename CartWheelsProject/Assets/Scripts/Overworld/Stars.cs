using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public Sprite[] starsSpr;
    public string starVar;
    public SpriteRenderer sr;

    void Start()
    {
        sr.sprite = starsSpr[PlayerPrefs.GetInt(starVar)];
    }
}
