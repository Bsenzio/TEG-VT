using UnityEngine;

public class TEGCell : MonoBehaviour
{
    [Header("Temperaturas")]
    public float hotTemperature = 120f;
    public float coldTemperature = 25f;

    [Header("Parámetros TEG")]
    public float seebeckCoefficient = 0.05f;

    [Header("Resultados")]
    public float deltaT;
    public float voltage;
    public float power;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        deltaT =
            hotTemperature -
            coldTemperature;

        voltage =
            seebeckCoefficient *
            deltaT;

        power =
            voltage * voltage / 10f;

        // Visualización térmica

        float t =
            Mathf.InverseLerp(
                0f,
                200f,
                deltaT
            );

        rend.material.color =
            Color.Lerp(
                Color.blue,
                Color.red,
                t
            );
    }
}