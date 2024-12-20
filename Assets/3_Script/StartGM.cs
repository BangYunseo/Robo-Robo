using UnityEngine;
using UnityEngine.UI;

public class StartGM : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LoadScene()
    {
        Debug.Log("test");
        UnityEngine.SceneManagement.SceneManager.LoadScene("1_play");
    }
}
