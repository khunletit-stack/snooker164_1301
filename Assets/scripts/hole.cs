using UnityEngine;

public class hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ball b = other.GetComponent<ball>();
        if (b != null )
        {
            Gamemanager.instance.Playerscore += b.Point;
        }
    }
}
