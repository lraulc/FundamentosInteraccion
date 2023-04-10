using System.Collections;
using UnityEngine;

// En caso de que no tuviera un trail component, lo agrega siempre.
[RequireComponent(typeof(TrailRenderer))]
public class PlayerMovementFinal : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad;

    [Header("Dash Settings")]
    [SerializeField] float dashDistance = 2.0f;
    Vector3 lastMoveDir;
    bool canDash = true;

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
        if (trailRenderer == null)
        {
            Debug.LogError($"No Trail Renderer Assigned to {this.gameObject}. Add a Trail Renderer");
        }
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Dash();
    }

    void Movimiento()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

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

    IEnumerator DashCoroutine()
    {
        canDash = false;
        yield return new WaitForSeconds(2.0f);
        canDash = true;
    }

    IEnumerator TrailEmitterCoroutine()
    {
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(0.1f);
        trailRenderer.emitting = false;
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDash == true)
        {
            StartCoroutine(DashCoroutine());
            StartCoroutine(TrailEmitterCoroutine());
            transform.position += lastMoveDir * dashDistance;
        }
    }
}