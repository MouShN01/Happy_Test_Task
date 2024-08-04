using UnityEngine;
using UnityEngine.UI;

public class SpeedController : MonoBehaviour // a controller between speed value of circle and value of slider
{
    [SerializeField] private Slider speedSlider;
    [SerializeField] private MainCircle mainCircle;
    
    void Start()
    {
        speedSlider.value = mainCircle.Speed;
        
        speedSlider.onValueChanged.AddListener(OnSliderValueChanged); // when value of slider changed changes value of speed
    }

    private void OnSliderValueChanged(float value)
    {
        mainCircle.SetSpeed(value);
    }
}
