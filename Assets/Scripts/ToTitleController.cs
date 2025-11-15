using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTitleController : MonoBehaviour
{
    public void ToTitle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }
}
