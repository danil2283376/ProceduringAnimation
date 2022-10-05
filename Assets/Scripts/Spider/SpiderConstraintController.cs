using UnityEngine;

public class SpiderConstraintController : MonoBehaviour
{
    [SerializeField] private float _radius = 0.7f;
    [SerializeField] private float _speedMove = 10f;
    [SerializeField] private float _moveStoppingDistance = 0.4f;
    [SerializeField] private GameObject _targetAim;
    [SerializeField] private SpiderConstraintController _axisLeg;

    private Vector3 _standartPosition;
    private LegAimGround _legAimGroundScript;
    private bool _moving = false;
    private bool _isMove = false;
    private void Start()
    {
        _standartPosition = transform.position;
        _legAimGroundScript = _targetAim.GetComponent<LegAimGround>();
    }

    private void Update()
    {
        //transform.position = _standartPosition;

        float distanceBetweenObjCube = Vector3.Distance(_targetAim.transform.position, transform.position);

        if ((distanceBetweenObjCube >= _radius
            && !_axisLeg.IsMove()) || _moving)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                    _targetAim.transform.position + new Vector3(0, 0, _legAimGroundScript.HeightLeg),//_targetAim.transform.position + new Vector3(0, _legAimGroundScript.HeightLeg, 0),
                        _speedMove * Time.deltaTime);

            _standartPosition = transform.position;
            _isMove = true;
            _moving = true;
            if (distanceBetweenObjCube < _moveStoppingDistance) 
            {
                _moving = false;
            }
        }
        else
        {
            //transform.position = Vector3.Lerp(
            //    transform.position,
            //        _standartPosition + new Vector3(0, _legAimGroundScript.HeightLeg, 0),
            //            _speedMove * Time.deltaTime);//_standartPosition;
            transform.position = _standartPosition;

            //transform.position = Vector3.Lerp(
            //    transform.position,
            //        _standartPosition,
            //            _speedMove * Time.deltaTime);
            _isMove = false;
            _moving = false;
        }

        //if (_isMove)
        //    MoveLeg();
    }

    public bool IsMove() 
    {
        return this._isMove;
    }
}
