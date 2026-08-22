using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Mainmenu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
   
}
