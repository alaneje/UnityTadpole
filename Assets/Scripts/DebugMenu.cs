using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DebugMenu : MonoBehaviour
{
    public string[] LevelNames;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToLevel(int arraynumber){
        SceneManager.LoadScene(LevelNames[arraynumber]);

    }
}
