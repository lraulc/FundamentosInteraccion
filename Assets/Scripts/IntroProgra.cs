using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INICIO DE SECUENCIA

public class IntroProgra : MonoBehaviour
{

    // Variables
    // Declarar (Inicializar, Initialize) = Asignar un valor a la variable cuando se crea.
    int edadWicho = 30;
    [SerializeField] string nombre = "Wicho";
    string saludo = "Hola, ";
    float estatura = 1.92f;
    // DOUBLE SE UTILIZA UNICAMENTE PARA COSAS CON MUY ALTA PRECISION.
    //double estaturaDouble = 1.92;
    //bool meGustaElCafe = true;

    // Creación de variable sin inicializar.
    int horaDeDespertar;
    bool desayuno;

    // Suma de Numero
    int numero = 0;

    // Calculadora Suma
    [SerializeField] int a = 8;
    [SerializeField] int b = 10;

    // Start is called before the first frame update
    // LA SECUENCIA DE START VA A CORRER CUANDO PRESIONE EL BOTON DE PLAY
    void Start()
    {
        saludo = saludo + nombre;
        // "Hola, Wicho. Mi estatura es: 1.92mts. Mi edad es: 30 años.
        print($"{saludo}. Mi estatura es: {estatura}mts. Mi edad es: {edadWicho} años.");

        print(suma());
        print(SumaParametros(a, b));
        print(SumaParametros(5, 10));
        /*
         * ESTO ES PARA PROBAR QUE LAS VARIABLES FUNCIONAN CORRECTAMENTE
        print(saludo);
        print(edadWicho);
        print(estatura);
        print(estaturaDouble);
        print(meGustaElCafe);
        print(horaDeDespertar);
        print(desayuno);
        */
    }

    // Update is called once per frame
    void Update()
    {
        // Frame 1 = 1.
        // Frame 2 = 2;
        // Frame 3 = 3;
        //print(numero); // Este print me va a imprimir 25
        //numero = numero + 1;
        //print(numero); // Este print me va a imprimir 50
    }

    int suma()
    {
        // Hard coded values
        // Numeros magicos
        int resultado = 3 + 2;
        return resultado;
    }

    int SumaParametros(int valor1, int valor2)
    {
        int resultado = valor1 + valor2;
        return resultado;
    }

}
// FIN DE SECUENCIA
