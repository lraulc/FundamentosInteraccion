using UnityEngine;

public class PlayerPrep : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 10.0f;

    float inputVertical;
    float inputHorizontal;

    // Extra Classes
    HealthManager healthManager;

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Información de Inputs
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        // Mover objeto usando Translate()
        gameObject.transform.Translate(new Vector3(inputHorizontal, inputVertical) * (speed * Time.deltaTime));
    }
}
