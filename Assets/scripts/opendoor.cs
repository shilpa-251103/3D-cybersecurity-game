using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class opendoor : MonoBehaviour
{
    private Animator anim;
    private bool IsAtDoor = false;
    [SerializeField] private TextMeshProUGUI codetext;
    string codeTextValue = "";
    public GameObject CodePanel;
    public int minPasswordLength = 8; // Set your minimum password length here
    public PlayerController1 playerController1;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Animator component not found!");
        }
        playerController1 = FindObjectOfType<PlayerController1>();
        if (playerController1 == null)
        {
            Debug.LogError("PlayerController script not found!");
        }
        else
        {
            Debug.Log("PlayerController script found!");
        }
    }

    void Update()
    {
        codetext.text = codeTextValue;

        if (IsStrongPassword(codeTextValue))
        {
            anim.SetTrigger("opendoor");
            CodePanel.SetActive(false);
            playerController1.ResumeMovement();
        }

        if (codeTextValue.Length >= minPasswordLength)
        {
            codeTextValue = "";
        }

        if (Input.GetKey(KeyCode.E) && IsAtDoor == true)
        {
            CodePanel.SetActive(true);
            playerController1.StopMovement();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsAtDoor = true;
        }
        Debug.Log("Player collided");
        playerController1.StopMovement();
    }

    private void OnTriggerExit(Collider other)
    {
        IsAtDoor = false;
        CodePanel.SetActive(false);
        playerController1.ResumeMovement();
    }

    public void ADDDigit(string digit)
    {
        codeTextValue += digit;
    }

    bool IsStrongPassword(string password)
    {
        // Add your criteria for a strong password here
        bool hasCapital = false;
        bool hasSmall = false;
        bool hasDigit = false;
        bool hasSpecialChar = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c))
                hasCapital = true;
            else if (char.IsLower(c))
                hasSmall = true;
            else if (char.IsDigit(c))
                hasDigit = true;
            else if (!char.IsLetterOrDigit(c))
                hasSpecialChar = true;
        }

        // Adjust this condition based on your specific criteria
        return hasCapital && hasSmall && hasDigit && hasSpecialChar && password.Length >= minPasswordLength;
    }
}