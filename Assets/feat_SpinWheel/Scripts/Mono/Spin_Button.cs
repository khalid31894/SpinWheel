
using UnityEngine;

using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Spin_Button : MonoBehaviour, IButton
{
    private Button button;

    [Tooltip("Final Octant will be calculated using probabilty proved in SO")]
    [SerializeField] private bool isProbabiltyBased;

    [Tooltip("Octant 0 is placed on pointer, octant 2 is on the right")]
    [SerializeField]  private   int    desiredOctant  ;

    [SerializeField]  private   float  spinTime       ;
    [SerializeField]  private   float  revolutions    ;
    [SerializeField]  private   bool   isClockWise=false ;
    [SerializeField]  private AnimationCurve curve    ;


    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        RotateWheel.rotate_Action(isProbabiltyBased ? ProbabilityBasedOctant.getProbabiltyBasedOctate_Action() : desiredOctant, spinTime,  revolutions,  isClockWise, curve);
    }
}
