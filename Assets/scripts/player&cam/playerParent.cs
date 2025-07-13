using UnityEngine;

public class playerParent : MonoBehaviour
{
    [SerializeField] testLookAt tLA;
    [SerializeField] float yOffset;

    private void Awake()
    {
        //tLA = GetComponentInChildren<testLookAt>();
    }

    private void Update()
    {
        if (tLA != null)
        {
            float y=tLA.transform.position.y+yOffset;
            transform.position = new Vector3(transform.position.x,y,transform.position.z);
        }
    }
}
