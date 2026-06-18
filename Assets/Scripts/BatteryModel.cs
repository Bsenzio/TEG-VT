using UnityEngine;

public class BatteryModel : MonoBehaviour
{
    [Header("Referencia al TEG")]
    public TEGCell teg;

    [Header("Batería")]

    public float capacityWh = 100f;

    public float storedEnergyWh = 0f;

    [Range(0,100)]
    public float stateOfCharge;

    void Update()
    {
        float generatedPower =
            teg.power;

        storedEnergyWh +=
            generatedPower *
            Time.deltaTime /
            3600f;

        storedEnergyWh =
            Mathf.Clamp(
                storedEnergyWh,
                0,
                capacityWh
            );

        stateOfCharge =
            (storedEnergyWh /
            capacityWh) * 100f;

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
                stateOfCharge / 100f
            );

        transform.localScale =
            scale;
    }
}