using UnityEngine;

public class Swing : MonoBehaviour
{
    public float speed;
    public float chunkTime;
    public float startPos;
    private float timeSinceLast;
    private float multiplier = 1.0f;

    void Start() {
        timeSinceLast = startPos;
    }

    // Update is called once per frame
    void Update() {
        if (timeSinceLast > chunkTime) {
            timeSinceLast = 0.0f;
            multiplier *= -1;
        }

        float horizMultiplier = (chunkTime/2.0f-getY()) * 2.0f;
        float vertMultiplier = ((chunkTime/4.0f) - Mathf.Abs(chunkTime/4.0f-getY())) / 5.0f;
        if (timeSinceLast>chunkTime/2.0f) {
            vertMultiplier *= -1.0f;
        }
        

        transform.Translate(0.0f,Time.deltaTime * speed * multiplier * horizMultiplier,vertMultiplier);
        timeSinceLast += Time.deltaTime;

        float rotMultiplier = (chunkTime/4.0f) - Mathf.Abs(chunkTime/4.0f-getY());
        transform.Rotate(-multiplier * rotMultiplier, 0.0f, 0.0f);
    }

    float getY() {
        if (timeSinceLast>chunkTime/2.0f) {
            return timeSinceLast - chunkTime/2.0f;
        } else {
            return chunkTime/2.0f - timeSinceLast;
        }
    }
}
