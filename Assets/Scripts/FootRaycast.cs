using UnityEngine;

public class FootRaycast : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private float originOffset = 0.5f;
    [SerializeField] private float overshoot = 0.1f;
    [SerializeField] private float groundOffset = 0.06f;

    private Vector3? fixedPosition;

    private void Update()
    {
        var bodyUp = body.rotation * Vector3.up;
        //Debug.Log("bodyUp: " + bodyUp);
        var legPosition = transform.position;
        var ray = new Ray(legPosition + bodyUp * originOffset, -bodyUp);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, originOffset + overshoot))
        {
            //Debug.Log(hit.collider.name);
            //Debug.DrawLine(ray.origin, hit.point, Color.black);

            var currentFootHeight = transform.localPosition.y;
            //Debug.Log(targetPosition);
            Vector3 targetPosition = hit.point + bodyUp * currentFootHeight;

            if (fixedPosition == null)
            {
                Debug.Log("Нога не зафиксирована");
                if (currentFootHeight < groundOffset)
                {
                    Debug.Log("Нога фиксируется над поверхностью");
                    fixedPosition = targetPosition;
                }
            }
            else if (currentFootHeight > groundOffset)
            {
                Debug.Log("Если нога выше поверхности, то сбрасываем фиксацию и ищем новое положение");
                fixedPosition = null;
            }
            else
            {
                Debug.Log("Клеем ногу к поверхности");
                var velocity = (fixedPosition.Value - transform.position) / Time.deltaTime;
                velocity = Vector3.ProjectOnPlane(velocity, bodyUp);
                body.velocity = velocity;
                targetPosition = fixedPosition.Value;
                fixedPosition = null;
            }
            //transform.position = targetPosition;
            transform.position = Vector3.Lerp(
                transform.position,
                    targetPosition,
                        12);//targetPosition * Time.deltaTime ;
        }
        else
        {
            fixedPosition = null;
        }
    }
}

//    [SerializeField] private Rigidbody body;
//    [SerializeField] private float originOffset = 0.5f;
//    [SerializeField] private float overshoot = 0.1f;
//    [SerializeField] private float groundOffset = 0.06f;
//    //[SerializeField] private Transform _target;
//    private Vector3? fixedPosition;

//    private void Update()
//    {
//        var bodyUp = body.rotation * Vector3.up;
//        var legPosition = transform.position;
//        var ray = new Ray(legPosition + bodyUp * originOffset, -bodyUp);

//        RaycastHit hit;

//        if (Physics.Raycast(ray, out hit, originOffset + overshoot))
//        {

//            //Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 5f);
//            //Debug.Log(transform.name + ":" + hit.collider.name);

//            var currentFootHeight = transform.localPosition.y;
//            var targetPosition = hit.point + bodyUp * currentFootHeight;
//            if (fixedPosition == null)
//            {
//                if (currentFootHeight < groundOffset)
//                {
//                    fixedPosition = targetPosition;
//                }
//            }
//            else if (currentFootHeight > groundOffset)
//            {
//                fixedPosition = null;
//            }
//            else
//            {
//                var velocity = (fixedPosition.Value - transform.position) / Time.deltaTime;
//                velocity = Vector3.ProjectOnPlane(velocity, bodyUp);
//                body.velocity = velocity;
//                targetPosition = fixedPosition.Value;
//            }

//            transform.position = targetPosition;
//            //_target.position = targetPosition;
//        }
//        else
//        {
//            fixedPosition = null;
//        }
//    }
//}

//[SerializeField] private Rigidbody body;
//[SerializeField] private float _distance = 4;
//[SerializeField] private float _offset = 1f;
//[SerializeField] private float _speed = 1.0f;
//[SerializeField] private float _groundOffset = 0.1f;
//[SerializeField] private Transform _target;

//private Vector3? _fixedPosition;

//    private void Update()
//    {
//        Ray ray = new Ray(transform.position + Vector3.up * _offset, Vector3.down);
//        RaycastHit hit;

//        if (Physics.Raycast(ray, out hit, _distance))
//        {
//            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
//            Debug.Log(transform.name + ":" + hit.collider.name);

//            float heightFoot = transform.localPosition.y;
//            Vector3 targetPosition = hit.point + Vector3.down * heightFoot;
//            //Debug.Log(targetPosition);

//            if (_fixedPosition == null)
//            {
//                if (heightFoot < _groundOffset)
//                {
//                    _fixedPosition = hit.point;
//                }
//            }
//            else if (heightFoot > _groundOffset)
//            {
//                _fixedPosition = null;
//            }
//            else
//            {
//                Vector3 velocity = (transform.position - -_fixedPosition.Value) / Time.deltaTime;
//                velocity = Vector3.ProjectOnPlane(velocity, Vector3.down);
//                body.velocity = velocity;
//                targetPosition = _fixedPosition.Value;
//            }
//            transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
//        }
//        else 
//        {
//            _fixedPosition = null;
//        }

//    }
//}
//    private void Update()
//    {
//        Ray ray = new Ray(transform.position + Vector3.up * _offset, Vector3.down);

//        RaycastHit hit;

//        if (Physics.Raycast(ray, out hit, _distance))
//        {
//            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
//            Debug.Log(hit.collider.name);
//            //Vector3 newPosition = new Vector3(
//            //    hit.point.x,
//            //        hit.point.y + _offset,
//            //            hit.point.z);

//            //_target.position = Vector3.Lerp(
//            //    _target.position,
//            //        hit.point,
//            //            _speed * Time.deltaTime
//            //    );
//            Vector3 targetPosition = Vector3.zero;
//            float currentFootHeight = _target.localPosition.y + _offset;

//            if (_fixedPosition == null)
//            {
//                //_target.position = Vector3.Lerp(
//                //_target.position,
//                //    hit.point,
//                //        _speed * Time.deltaTime
//                //        );
//                if (currentFootHeight < _groundOffset)
//                {
//                    targetPosition = hit.point;
//                }
//            }
//            else if (currentFootHeight > _groundOffset)
//            {
//                _fixedPosition = null;
//            }
//            else 
//            {
//                Vector3 velocity = (_fixedPosition.Value - transform.position) / Time.deltaTime;
//                velocity = Vector3.ProjectOnPlane(velocity, Vector3.up);
//                body.velocity = velocity;
//                targetPosition = _fixedPosition.Value;
//            }
//            _target.position = targetPosition;
//        }
//        else
//        {
//            _fixedPosition = null;
//        }
//    }
//}





















//    [SerializeField] private Rigidbody body;
//    [SerializeField] private float originOffset = 0.5f;
//    [SerializeField] private float overshoot = 0.1f;
//    [SerializeField] private float groundOffset = 0.06f;

//    private Vector3? fixedPosition;

//    private void Update()
//    {
//        var bodyUp = body.rotation * Vector3.up;
//        var legPosition = transform.position;
//        var ray = new Ray(legPosition + bodyUp * originOffset, -bodyUp);

//        RaycastHit hit;

//        if (Physics.Raycast(ray, out hit, originOffset + overshoot))
//        {
//            var currentFootHeight = transform.localPosition.y;
//            var targetPosition = hit.point + bodyUp * currentFootHeight;
//            if (fixedPosition == null)
//            {
//                if (currentFootHeight < groundOffset)
//                {
//                    fixedPosition = targetPosition;
//                }
//            }
//            else if (currentFootHeight > groundOffset)
//            {
//                fixedPosition = null;
//            }
//            else
//            {
//                var velocity = (fixedPosition.Value - transform.position) / Time.deltaTime;
//                velocity = Vector3.ProjectOnPlane(velocity, bodyUp);
//                body.velocity = velocity;
//                targetPosition = fixedPosition.Value;
//            }

//            transform.position = targetPosition;
//        }
//        else
//        {
//            fixedPosition = null;
//        }
//    }
//}
