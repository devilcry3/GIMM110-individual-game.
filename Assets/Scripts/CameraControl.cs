using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Regions help to visually organize your code into sections.
    #region Variables
    // Headers are like titles for the Unity Inspector.
    [Header("Camera Control")]
    // SerializeField allows you to see private variables in the inspector while keeping them private
    [SerializeField] int speed; // Speed of the camera movement
    #endregion // Marks the end of the region

    #region Unity Methods
    // Update is called once per frame
    private void Update()
    {
        // Moves the camera either right or left based on the arrow keys
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
    }
    #endregion
}
