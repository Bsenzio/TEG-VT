using UnityEngine;

public class SuperCapModel : MonoBehaviour
{
    [Header("Referencia TEG")]
    public TEGCell teg;

    [Header("Supercapacitor")]

    public float capacitance = 50f;

    public float voltage = 0f;

    public float maxVoltage = 5f;

    public float storedEnergy;

    public float chargePercent;

    void Update()
    {
        float generatedPower =
            teg.power;

        storedEnergy +=
            generatedPower *
            Time.deltaTime;

        voltage =
            Mathf.Sqrt(
                (2f * storedEnergy)
                / capacitance
            );

        voltage =
            Mathf.Clamp(
                voltage,
                0,
                maxVoltage
            );

        chargePercent =
            voltage /
            maxVoltage;

        UpdateVisual();
    }

    void UpdateVisual()
    {
        Vector3 scale =
            transform.localScale;

        scale.y =
            Mathf.Lerp(
                0.2f,
                3f,
                chargePercent
            );

        transform.localScale =
            scale;
    }
}