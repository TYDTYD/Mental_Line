using UnityEngine;

public class FrontTrigger : MonoBehaviour
{
    [SerializeField] GameObject obj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            obj.SetActive(true);
        }
    }
}
