
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Spieler Objekt muss in Unity reingezogen werden damit in der Update Funktion dem Spieler gefolgt werden kann
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Update()
    {
        //Kamera folgt dem Spieler
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        //player.localScale.x ist wenn man nach rechts schaut 3, wenn man nach links schaut -3
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }
}
