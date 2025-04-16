using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public void OnExplosionEnd()
    {
        Destroy(gameObject);
    }

}