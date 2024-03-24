
using UnityEngine;

using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Spin_Button : MonoBehaviour, IButton
{
    [SerializeField] private Button button;

    [SerializeField] private int desiredOctant;
    [SerializeField] private float spinTime;
    [SerializeField] private float revolutions;
    [SerializeField] private bool isClokWise;


    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        RotateWheel.rotate_Action(desiredOctant, revolutions, spinTime);
    }
}
