using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordCode : MonoBehaviour
{
    public int correctPassword = 1234;
    string Password = "";

    
    public Transform targetTransform; 

    public void Add0() => AddDigit("0");
    public void Add1() => AddDigit("1");
    public void Add2() => AddDigit("2");
    public void Add3() => AddDigit("3");
    public void Add4() => AddDigit("4");
    public void Add5() => AddDigit("5");
    public void Add6() => AddDigit("6");
    public void Add7() => AddDigit("7");
    public void Add8() => AddDigit("8");
    public void Add9() => AddDigit("9");

    private void AddDigit(string digit)
    {
        if (Password.Length < 4)
        {
            Password += digit;
            CheckPassword();
        }
    }

    public void DeleteLast()
    {
        if (Password.Length > 0)
            Password = Password.Substring(0, Password.Length - 1);
    }

    public void DeletePassword()
    {
        Password = "";
    }

    private void CheckPassword()
    {
        if (Password.Length == 4 && int.TryParse(Password, out int enteredPassword))
        {
            if (enteredPassword == correctPassword)
            {
                OnCorrectPassword();
            }
        }
    }

    private void OnCorrectPassword()
    {
        Debug.Log("Contraseña correcta");

        if (targetTransform != null)
        {
            
            Vector3 tempPosition = transform.position;
            Quaternion tempRotation = transform.rotation;

            transform.position = targetTransform.position;
            transform.rotation = targetTransform.rotation;

            targetTransform.position = tempPosition;
            targetTransform.rotation = tempRotation;
        }
        else
        {
            
        }
    }
}