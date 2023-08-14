using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinTextMeatPie : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textObj;

    void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textObj.text = "YOU GOT " + MeatPieManager.score + "/" + MeatPieManager.noPies + " PIES CORRECT!\n\nYOU GOT " + MeatPieManager.score/10 + " STAR(S)!";
    }
}
