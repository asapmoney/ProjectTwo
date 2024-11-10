using UnityEngine;

public class BasicPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
