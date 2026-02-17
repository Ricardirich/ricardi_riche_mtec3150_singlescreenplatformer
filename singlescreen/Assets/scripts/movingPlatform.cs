using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.5f;
    int direction = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {
        Vector2 target;
        if (direction == 1)
        {
            target = endPoint.position;
        }
        else
        {
            target = startPoint.position;
        }

        platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);
        float distance = Vector2.Distance(platform.position, target);
        if (distance < 0.5f)
        {
            direction *= -1;
        }
    }
}