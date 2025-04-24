using UnityEngine;

public class BackTrigger : MonoBehaviour
{
    [SerializeField] GameObject obj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            obj.SetActive(false);
        }
    }
}
