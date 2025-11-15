using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    public enum Button
    {
        Play,
        Score,
        Quit
    }
    public Button button; // Select the button type in the Inspector 

    void Awake()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    public void Click()
    {
        switch (button)
        {
            case Button.Play:
                SceneManager.LoadScene("Main"); 
                break;
            case Button.Score:
                SceneManager.LoadScene("Score");
                break;
            case Button.Quit:
                Application.Quit();
                break;
        }
    }
}