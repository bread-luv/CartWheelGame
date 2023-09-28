using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CurrencyManager : MonoBehaviour
{

    public const string Currency = "Currency";
    public static int currency = 0;
    // Start is called before the first frame update
    void Start()
    {
        currency = PlayerPrefs.GetInt("Currency");
    }

    public static void UpdateCurrency()
    {
        PlayerPrefs.SetInt("Currency", currency);
        currency = PlayerPrefs.GetInt("Currency");
        PlayerPrefs.Save();
    }
}