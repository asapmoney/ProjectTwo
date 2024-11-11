using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class mainend : MonoBehaviour
{
     void Start()
    {
        UnlockCursor();
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;  
        Cursor.visible = true;                   
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;                  
    }
    
    
}
