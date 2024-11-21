using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameObject menuPanel;
    public Movement playerMovement;

    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            menuPanel.SetActive(!menuPanel.activeSelf);

            //check if save exists dataserializer.AnySave()
            //if exists Activate continue button
            //else deactivate continue button
        }
    }

    public void NewGame()
    {
        new SaveData();
    }

    public void Continue()
    {
       
       
    }

    public void Save()
    {
        //fill save data
        playerMovement.Save();
        DataSerializer.Save();
    }

    public void Exit()
    {

    }
}
