using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private string[] interactableTags;
    [SerializeField] private float interactLength = 3f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, interactLength);
            if (hits.Length > 0)
            {
                foreach (RaycastHit hit in hits)
                {
                    foreach (string tag in interactableTags)
                    {
                        if (hit.transform.CompareTag(tag))
                        {
                            hit.transform.SendMessage("OnPlayerInteract");
                            break;
                        }
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * interactLength);
    }
}
