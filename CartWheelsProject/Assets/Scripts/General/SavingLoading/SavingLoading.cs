using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingLoading : MonoBehaviour
{
    //settings
    //audio
    

    //stars
    public static int BG_11_Stars;
    public static int BG_12_Stars;
    public static int BG_13_Stars;
    public static int BG_Travel_Stars;

    public static int ES_11_Stars;
    public static int ES_12_Stars;
    public static int ES_13_Stars;

    public static int SB_11_Stars;
    public static int SB_12_Stars;
    public static int SB_13_Stars;

    static public void saveGame()
    {
        PlayerPrefs.SetInt("BG_11_Stars", BG_11_Stars);
        PlayerPrefs.SetInt("BG_12_Stars", BG_12_Stars);
        PlayerPrefs.SetInt("BG_13_Stars", BG_13_Stars);
        PlayerPrefs.SetInt("BG_Travel_Stars", BG_Travel_Stars);

        PlayerPrefs.SetInt("ES_11_Stars", ES_11_Stars);
        PlayerPrefs.SetInt("ES_12_Stars", ES_12_Stars);
        PlayerPrefs.SetInt("ES_13_Stars", ES_13_Stars);

        PlayerPrefs.SetInt("SB_11_Stars", SB_11_Stars);
        PlayerPrefs.SetInt("SB_12_Stars", SB_12_Stars);
        PlayerPrefs.SetInt("SB_13_Stars", SB_13_Stars);
    }

    static public void loadGame()
    {
        BG_11_Stars = PlayerPrefs.GetInt("BG_11_Stars");
        BG_12_Stars = PlayerPrefs.GetInt("BG_12_Stars");
        BG_13_Stars = PlayerPrefs.GetInt("BG_13_Stars");
        BG_Travel_Stars = PlayerPrefs.GetInt("BG_Travel_Stars");

        ES_11_Stars = PlayerPrefs.GetInt("ES_11_Stars");
        ES_12_Stars = PlayerPrefs.GetInt("ES_12_Stars");
        ES_13_Stars = PlayerPrefs.GetInt("ES_13_Stars");

        SB_11_Stars = PlayerPrefs.GetInt("SB_11_Stars");
        SB_12_Stars = PlayerPrefs.GetInt("SB_12_Stars");
        SB_13_Stars = PlayerPrefs.GetInt("SB_13_Stars");
    }

    static public int totalStars()
    {
        int total = PlayerPrefs.GetInt("BG_11_Stars") +
        PlayerPrefs.GetInt("BG_12_Stars") +
        PlayerPrefs.GetInt("BG_13_Stars") +
        PlayerPrefs.GetInt("BG_Travel_Stars") +

        PlayerPrefs.GetInt("ES_11_Stars") +
        PlayerPrefs.GetInt("ES_12_Stars") +
        PlayerPrefs.GetInt("ES_13_Stars") +

        PlayerPrefs.GetInt("SB_11_Stars") +
        PlayerPrefs.GetInt("SB_12_Stars") +
        PlayerPrefs.GetInt("SB_13_Stars");

        return total;
    }
}
