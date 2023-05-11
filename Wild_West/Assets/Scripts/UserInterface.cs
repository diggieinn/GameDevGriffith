using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    public GameObject _panelLevelComplete;
    public GameObject _panelLevelFailed;
    public TextMeshProUGUI txtPrisoners;

    int totPrisoners = 0;
    void Start()
    {
        
    }


    public void FreePrisoners()
    {
        totPrisoners++;
        if (totPrisoners >= 6)
        {
            FindObjectOfType<Player>()._isMove = false;
            LevelComplete();
        }
        else
        {
            txtPrisoners.text = totPrisoners + "/ 6";
        }
    }

   public void LevelComplete()
   {
        Invoke("Complete", .1f);
    }

    public void LevelFailed()
    {
        Invoke("Failed",2);
    }

    void Failed()
    {
        _panelLevelFailed.SetActive(true);

    }

    void Complete()
    {
        _panelLevelComplete.SetActive(true);
    }


    public void OnLevelComplete()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void ONLevelFailed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


}
