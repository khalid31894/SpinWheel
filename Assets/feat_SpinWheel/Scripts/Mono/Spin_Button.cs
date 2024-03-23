
using UnityEngine;

using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Spin_Button : MonoBehaviour, IButton
{
    [SerializeField] private Button button;

    [SerializeField] private int number;
    [SerializeField] private float rot;
    [SerializeField] private float time;


    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        RotateWheel.rotate_Action(number,rot,time);
    }
}
