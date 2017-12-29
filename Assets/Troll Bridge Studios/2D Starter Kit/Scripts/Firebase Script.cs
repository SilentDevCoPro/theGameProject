using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NewBehaviourScript : MonoBehaviour {
    public InputField EmailAddress, Password;
    public string loginScene, newUserScene;

    public void LoginButtonPressed() {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(EmailAddress.text, Password.text).
        ContinueWith((obj) =>
        {
            SceneManager.LoadScene(loginScene);
        });
    }

    public void NewUseButtonPressed() {
        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(EmailAddress.text, Password.text).
        ContinueWith((obj) =>
        {
            SceneManager.LoadScene(newUserScene);
        });
    }
}
