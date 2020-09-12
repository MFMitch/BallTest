using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public enum eSelectionState { FREE, SELECTED };
    public eSelectionState _state;

    public Rigidbody _rb;


    public GameObject PREFAB;
    public int distance = 1;

    private void Update()
    {

        if (_state == eSelectionState.FREE)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    _state = eSelectionState.SELECTED;
                }
            }
        }
        else if (_state == eSelectionState.SELECTED)
        {
            //draw line
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, float.PositiveInfinity);
            Vector3 point = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            
            Vector3 lineAngle = ((point * distance) * -1).normalized;
            //Vector3 lineAngle = this.transform.position - point;

            // GameObject.Instantiate(PREFAB, point, Quaternion.identity);


            Vector3 direction = new Vector3(lineAngle.x, this.transform.position.y, lineAngle.z).normalized;

            Debug.Log("Point: " + point.ToString());
            Debug.Log("LineAngle : " + lineAngle.ToString());
            Debug.Log("Dir : " + direction.ToString());


            Debug.DrawLine(this.transform.position, direction, Color.red, 10);


            if (Input.GetMouseButtonUp(0))
            {
                //Shoot the ball
                _rb.AddForce(lineAngle * 2, ForceMode.Force);
                //_rb.AddForceAtPosition(lineAngle*10, this.transform.position, ForceMode.Acceleration);
                _state = eSelectionState.FREE;
            }
        }
    }
}
