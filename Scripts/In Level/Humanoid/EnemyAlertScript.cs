using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAlertScript : MonoBehaviour
{
    public Image prefabUI;
    private Image uiuse;
    public Camera cam;
    public Transform enemy_head;
    public Transform fly_obj;
    private Vector3 offset = new Vector3(0, 2f, 0);
    public EnemyAI enem;
    float scale = 0.1f;
    float elapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        uiuse = Instantiate(prefabUI, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
    }

    bool check_if_within_cam()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(enemy_head.position);
        return (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0);
    }

    // Update is called once per frame
    void Update()
    {

        uiuse.enabled = false;
        bool res = check_if_within_cam();
        uiuse.transform.position = cam.WorldToScreenPoint(transform.position);
        elapsed += Time.deltaTime;
        if (elapsed >= 0.1f)
        {
            elapsed = 0f;
            scale = scale + 0.1f;
            if (scale > 1f)
            {
                scale = 0.1f;
            }
        }
        uiuse.transform.localScale = new Vector3(scale, scale, 0);
        if (!res)
        {
            uiuse.enabled = false;
        }   
        else
        {
            if (enem.is_in_sight_range())
            {
                uiuse.enabled = true;
            }
        }
    }

}
