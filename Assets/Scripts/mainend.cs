using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class mainend : MonoBehaviour
{
     void Start()
    {
        // Ensure the cursor is visible and not locked at the start of the game or when the game ends
        UnlockCursor();
    }

    // Call this function when the game ends or when you want to show the cursor (e.g., at the end of the game)
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;  // No lock, free to move around
        Cursor.visible = true;                   // Make sure the cursor is visible
    }

    // Optionally, you can call this method to lock the cursor again, if needed
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen (useful for FPS or third-person games)
        Cursor.visible = false;                   // Make the cursor invisible when locked
    }
        // Additional game-over logic can go here (e.g., show game-over screen)
    
    
}
