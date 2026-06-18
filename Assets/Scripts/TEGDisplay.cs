using TMPro;
using UnityEngine;

public class TEGDisplay : MonoBehaviour
{
    public TEGCell teg;

    public TMP_Text voltageText;
    public TMP_Text powerText;
    public TMP_Text deltaTText;

    void Update()
    {
        voltageText.text =
            "Voltage: " +
            teg.voltage.ToString("F2") +
            " V";

        powerText.text =
            "Power: " +
            teg.power.ToString("F2") +
            " W";

        deltaTText.text =
            "ΔT: " +
            teg.deltaT.ToString("F1") +
            " °C";
    }
}