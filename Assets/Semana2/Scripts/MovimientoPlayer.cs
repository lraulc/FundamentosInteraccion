using UnityEngine.VFX;
using System.Collections;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad;

    [Header("Dash Settings")]
    [SerializeField] float dashDistance = 2.0f;
    Vector3 lastMoveDir;

    // Sólo se utiliza para el movimiento V2
    float inputHorizontal;
    float inputVertical;

    // Limites de jugador
    float limitesHorizontales = 9.5f;
    float limitesVerticales = 6.0f;

    // Otras Classes
    TrailRenderer trailRenderer;


    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        if (trailRenderer == null) Debug.LogError($"No Trail Renderer Assigned to {this.gameObject}");
    }

    private void Start()
    {
        StartCoroutine(DashCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Dash();
    }

    void Movimiento()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        // Movimiento jugador v1
        //transform.Translate(new Vector2(inputHorizontal, inputVertical).normalized * velocidad * Time.deltaTime);

        //Movimiento jugador v2
        Vector3 direccion = new Vector3(inputHorizontal, inputVertical).normalized;
        Vector3 nuevaPosicion = transform.position + direccion * velocidad * Time.deltaTime;

        if (inputHorizontal != 0 || inputVertical != 0)
        {
            lastMoveDir = direccion;
        }

        transform.position = nuevaPosicion;


        // Limita movimiento HORIZONTAL y le da la vuelta a la pantalla
        if (transform.position.x >= limitesHorizontales)
        {
            transform.position = new Vector2(-limitesHorizontales, transform.position.y);
        }
        else if (transform.position.x <= -limitesHorizontales)
        {
            transform.position = new Vector2(limitesHorizontales, transform.position.y);
        }

        //// Limite VERTICAL

        if (transform.position.y >= limitesVerticales)
        {
            transform.position = new Vector2(transform.position.x, -limitesVerticales);
        }
        else if (transform.position.y <= -limitesVerticales)
        {
            transform.position = new Vector2(transform.position.x, limitesVerticales);
        }
    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(2.0f);
        Dash();
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            trailRenderer.emitting = true;
            transform.position += lastMoveDir * dashDistance;
        }
    }
}