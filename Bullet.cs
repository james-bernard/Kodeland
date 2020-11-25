using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 3;
    Vector3 direction;
    public GameObject player;

    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
        speed += 1f;

        Collider[] targets = Physics.OverlapSphere(transform.position, 1);
        foreach (var item in targets)
        {
            if (item.tag == "Enemy")
            {
                //�������� � �������� ���� enemyCount
                /*
                    ��� ��������� � ��������� �������� ���� enemyCount ����������� �� �������
                */
                player.GetComponent<PlayerController>().enemyCount -= 1;
                Destroy(item.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
