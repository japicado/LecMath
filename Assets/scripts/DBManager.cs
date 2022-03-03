using Firebase;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    DatabaseReference reference;
    public GameOverScreen GameOverScreen;
    private FirebaseApp app;//OJO

    // Start is called before the first frame update
    void Start()
    {
        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        initDb();
    }

    void initDb()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    public void writeNewUser(string name, string score)
    {
        User user = new User(name, score);
        string json = JsonUtility.ToJson(user);

        reference.Child("users").Child(name).SetRawJsonValueAsync(json).ContinueWith(task=> {
            if (task.IsCompleted)
            {
                Debug.Log("Completo");
            }
            else
            {
                Debug.Log("InCompleto");
            }
             
        });
    }
}

public class User
{
    public string username;
    public string score;

    public User()
    {
    }

    public User(string username, string score)
    {
        this.username = username;
        this.score = score;
    }
}