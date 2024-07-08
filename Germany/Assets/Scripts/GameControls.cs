using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameControls : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRB;
    [Space]
    [SerializeField] RectTransform target;
    [SerializeField] GameObject forceBar;
    [SerializeField] Image forceBarImg;

    [Space]
    [SerializeField] Color startColor;
    [SerializeField] Color endColor;

    bool isPressed = false;
    float forceValue = 0f;

    float tickColor = 0;

    public void HoldButton(InputAction.CallbackContext context)
    {
        isPressed = context.action.IsPressed();
    }

    private void Update() {
        if(isPressed)
        {
            // forceValue += 25f * Time.deltaTime;
            forceBar.SetActive(true);
            if(forceBarImg.fillAmount < 1)
            {
                forceBarImg.fillAmount += 0.5f * Time.deltaTime;
                UpdateForceBarColor();
                forceValue = forceBarImg.fillAmount * 100;
            }
        }
        else
        {
            if (forceValue != 0) //TODO: adicionar direção e desativar botões
            {
                playerRB.AddForce(transform.up * forceValue/2, ForceMode2D.Impulse);
            }

            forceBar.SetActive(false);
            forceBarImg.fillAmount = 0;
            forceValue = 0;
            tickColor = 0;
        }

        //Debug.Log("force value is: " + forceValue);
    }

    public void SetRotationTarget(float v)
    {
        target.rotation = Quaternion.EulerAngles(0, 0, v);
    }

    private void UpdateForceBarColor()
    {
        tickColor += 0.5f * Time.deltaTime;
        forceBarImg.color = Color.Lerp(startColor, endColor, tickColor);

        //var v = forceBarImg.fillAmount;
        // if(v <= 0.25f) forceBarImg.color = Color.yellow;
        // if(v > 0.25f && v <= 0.5f) forceBarImg.color = Color.orange;
        // if(v > 0.5f && v <= 1f) forceBarImg.color = Color.red;
    }
}
