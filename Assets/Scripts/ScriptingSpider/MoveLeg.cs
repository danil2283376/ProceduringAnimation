using UnityEngine;

public class MoveLeg : MonoBehaviour
{
    [SerializeField] private GameObject _pointFoot;

    private void OnTriggerExit(Collider other)
    {
        if (other.name == _pointFoot.name)
            MovingLeg();
    }

    private void MovingLeg()
    {

    }
}
