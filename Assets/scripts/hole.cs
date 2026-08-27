using UnityEngine;

public class hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ball b = other.GetComponent<ball>();
        if (b != null )
        {
            if (b.Point == 0)
            {
                Gamemanager.instance.ShowString($"White ball drop!!!\nYou lose");
                Time.timeScale = 0f;
            }   
            else
            {
                Gamemanager.instance.ShowScoreText(b.Point);
            }

            Destroy(b.gameObject);
        }
    }
}
