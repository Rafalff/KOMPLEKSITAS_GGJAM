using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySfx(SoundName.KencingDapet);
            KencingManager.instance.targetDoneCount++;
            Destroy(gameObject);
        }
    }
}
