using UnityEngine;


public class Laser : MonoBehaviour, IPooledObject
{
    
    public void OnObjectPooled()
    {
        LeanTween.cancel(this.gameObject);
    }
    
    public void Die()
    {
        this.gameObject.SetActive(false);
    }
    
}
