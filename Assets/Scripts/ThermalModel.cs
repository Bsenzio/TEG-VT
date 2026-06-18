using UnityEngine;

public class ThermalModel : MonoBehaviour
{
    public TEGCell teg;

    public float ambientTemperature = 25f;

    public float heatInput = 100f;

    void Update()
    {
        teg.hotTemperature +=
            (heatInput * 0.01f)
            * Time.deltaTime;

        teg.hotTemperature -=
            (teg.hotTemperature - ambientTemperature)
            * 0.05f
            * Time.deltaTime;

        teg.coldTemperature +=
            (ambientTemperature - teg.coldTemperature)
            * 0.02f
            * Time.deltaTime;
    }
}