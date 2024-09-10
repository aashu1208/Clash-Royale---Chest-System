using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    public int randomValue;
    public float timeInterval;
    public bool rowStopped;
    public string stoppedSlot;

    // Start is called before the first frame update
    void Start()
    {
        rowStopped = true;
        GameControl.HandlePulled += StartRotating;
    }

    public void StartRotating()
    {
        stoppedSlot = "";
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        rowStopped = false;
        float initialSpeed = 0.015f; // Faster initial speed
        float minSpeed = 0.1f; // Slowest speed for deceleration
        float moveIncrement = 0.45f; // Larger increment for faster movement
        float decelerationTime = 2.0f; // Time for full deceleration

        // Initial spin with constant speed
        for (int i = 0; i < 30; i++)
        {
            transform.Translate(Vector2.down * moveIncrement);
            if (transform.position.y <= -1.86f)
            {
                transform.position = new Vector2(transform.position.x, 3.58f); // Loop back to top
            }
            yield return new WaitForSeconds(initialSpeed);
        }

        // Determine the stopping symbol
        randomValue = Random.Range(60, 100);
        switch (randomValue % 4)
        {
            case 0: stoppedSlot = "Bell"; break;
            case 1: stoppedSlot = "7"; break;
            case 2: stoppedSlot = "Bar"; break;
            case 3: stoppedSlot = "Fruit"; break;
        }

        // Gradual slowdown to stopping point
        float elapsedTime = 0f;
        while (elapsedTime < decelerationTime)
        {
            float t = elapsedTime / decelerationTime;
            float currentSpeed = Mathf.Lerp(initialSpeed, minSpeed, t); // Smoothly decrease speed
            float adjustedIncrement = moveIncrement * Mathf.Clamp01(1 - t); // Decrease movement increment as speed decreases

            transform.Translate(Vector2.down * adjustedIncrement);
            if (transform.position.y <= -1.86f)
            {
                transform.position = new Vector2(transform.position.x, 3.58f); // Loop back to top
            }

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for next frame
        }

        // Ensure the final speed is set to minSpeed
        float finalYPosition = 0f;
        switch (stoppedSlot)
        {
            case "Bell": finalYPosition = -0.82f; break;
            case "7": finalYPosition = 0.68f; break;
            case "Bar": finalYPosition = 2.11f; break;
            case "Fruit": finalYPosition = 3.58f; break;
        }

        // Move to the exact final position smoothly
        while (Mathf.Abs(transform.position.y - finalYPosition) > 0.01f)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, finalYPosition), 0.1f);
            yield return new WaitForSeconds(0.01f);
        }
        transform.position = new Vector2(transform.position.x, finalYPosition);

        rowStopped = true;

        // Notify GameControl that spinning is complete
        GameControl gameControl = GameObject.FindObjectOfType<GameControl>();
        if (gameControl != null)
        {
            gameControl.CheckResults(); // Adjust as needed
        }
    }


    private void OnDestroy()
    {
        GameControl.HandlePulled -= StartRotating;
    }
}
