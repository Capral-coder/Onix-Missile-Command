using UnityEngine;
using UnityEngine.UI;

public class RocketCounter : MonoBehaviour
{
    private Text rocketCounterText;

    private void Start()
    {
        rocketCounterText = GetComponent<Text>();
    }

    private void Update()
    {
        rocketCounterText.text = " " + TankRocketController.GetDestroyedRocketsCount();
    }
}
