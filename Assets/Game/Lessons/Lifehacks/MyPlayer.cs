using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    [field: SerializeField]
    public float Speed { get; private set; }

    public void Init()
    {
        Debug.Log("Init my player");
    }
}