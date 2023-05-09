using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_goto : MonoBehaviour
{

    public GameObject ui;
    public string scene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene(scene);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
