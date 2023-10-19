
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{


    // Start is called before the first frame update
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        PlayerPrefs.DeleteAll();

    }
}


