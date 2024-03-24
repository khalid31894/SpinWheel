
using UnityEngine;

using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Spin_Button : MonoBehaviour, IButton
{
    private Button button;

    [SerializeField] private bool isProbabiltyBased;

   [SerializeField]  private   int    desiredOctant  ;
    [SerializeField]  private   float  spinTime       ;
    [SerializeField]  private   float  revolutions    ;
    [SerializeField]  private   bool   isClockWise=false ;
    [SerializeField]  private AnimationCurve curve    ;

   // [SerializeField] private FloatReference Octant;
    


    //isProbabiltyBased? ProbabilityBasedOctant.getProbabiltyBasedOctate_Action():desiredOctant

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
