using UnityEngine;

public class ShootController : MonoBehaviour
{
    public Transform FirePoint;
    
    public void Shoot()
    {
        if (Physics.Raycast(FirePoint.position, FirePoint.forward, out RaycastHit hit))
        {
            Debug.Log($"Hit! {hit.collider.name}");
        }
    }
}