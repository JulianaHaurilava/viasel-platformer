using UnityEngine;

public class Bonus : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
