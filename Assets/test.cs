using UnityEngine;

public class test : MonoBehaviour
{
    private int n = 1;
    private float timer = 0f;
    void Awake()
    {
        Debug.Log("Awake");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        n++;
        if(timer > 1f)
        {

            Debug.Log(n);
            timer = 0f;
            n = 0;
        }
    }
}
