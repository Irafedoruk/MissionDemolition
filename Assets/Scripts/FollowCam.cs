using UnityEngine;
using System.Collections;
using UnityEngine.UIElements.Experimental;
public class FollowCam : MonoBehaviour
{
    static public GameObject POI; // ������ �� ������������ ������ // �
    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;
    [Header("Set Dynamically")]
    public float camZ; // �������� ���������� Z ������
    void Awake()
    {
        camZ = this.transform.position.z;
    }
    void FixedUpdate()
    {
        // ������������ ������ if �� ������� �������� ������
        //if (POI == null) return; // �����, ���� ��� ������������� �������
        // �������� ������� ������������� �������
        //Vector3 destination = POI.transform.position;
        Vector3 destination;
        // ���� ��� ������������� �������, ������� �:[ 0, 0, 0 ]
        if (POI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            // �������� ������� ������������� �������
            destination = POI.transform.position;
            // ���� ������������ ������ - ������, ���������, ��� �� �����������
            if (POI.tag == "Projectile")
            {
            // ���� �� ����� �� �����(�� ���� �� ���������)
            if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    // ������� �������� ��������� ���� ������ ������
                    POI = null;
                    //� ��������� �����
                    return;
                }
            }
        }
        // ���������� X � Y ������������ ����������
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        // ���������� ����� ����� ������� ��������������� ������ � destination
        destination = Vector3.Lerp(transform.position, destination, easing);
        // ������������� ���������� �������� destination.z ������ camZ, �����
        // ���������� ������ ��������
        destination.z = camZ;
        // ��������� ������ � ������� destination
        transform.position = destination;
        // �������� ������ orthographicSize ������., ����� �����
        // ���������� � ���� ������
        Camera.main.orthographicSize = destination.y + 10;
    }
}