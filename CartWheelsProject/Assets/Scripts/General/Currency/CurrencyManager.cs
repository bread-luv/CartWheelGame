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
        //resetCurrency();
        currency = PlayerPrefs.GetInt("Currency");
    }

    public static bool UpdateCurrency(int add)
    {
        currency += add;
        if (currency < 0) { currency = 0; }
            PlayerPrefs.SetInt("Currency", currency);
            currency = PlayerPrefs.GetInt("Currency");
            PlayerPrefs.Save();
        return true;
    }

    private void resetCurrency() {
        currency = 0;
        PlayerPrefs.SetInt("Currency", currency);
        currency = PlayerPrefs.GetInt("Currency");
        PlayerPrefs.Save();
    }
}