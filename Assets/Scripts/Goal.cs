using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{
    // ����������� ����, ��������� ������ ������� ����
    static public bool goalMet = false;
    void OnTriggerEnter(Collider other)
    {
        // ����� � ������� �������� �������� �������� ���-��,
        // ���������, �������� �� ��� "���-�� ��������
        if (other.gameObject.tag == "Projectile")
        {
            // ���� ��� ������, ��������� ���� goalMet �������� true
            Goal.goalMet = true;
            // ����� �������� �����-����� �����, ����� ��������� ��������������
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }
}
