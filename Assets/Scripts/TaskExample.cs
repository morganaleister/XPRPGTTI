using UnityEngine;
using System.Threading.Tasks;

public class TaskExample : MonoBehaviour
{
    float _elapsed = 0;
    void Start()
    {
        Debug.Log("Start begins");
        //Initialize a task completion source.
        //This will be our source for creating a task and also holding the result on it's completion.

        var tcs = new TaskCompletionSource<Vector3>();

        Task.Run(async () =>
        {
            Debug.Log("Task started");
            tcs.SetResult(await LongRunningTask());
            Debug.Log("Task stopped");
        });
        // ConfigureAwait must be true to get unity main thread context
        tcs.Task.ConfigureAwait(true).GetAwaiter().OnCompleted(() =>
        {
            Debug.Log("Task completed");
            transform.Rotate(tcs.Task.Result);
        });
        Debug.Log("Start method ends");
    }
    void Update()
    {
        if (_elapsed > 1)
        {
            Debug.Log($"Update loop running for : " + Time.realtimeSinceStartup + " seconds");
            _elapsed = 0;
        }
        _elapsed += Time.deltaTime;
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    async Task<Vector3> LongRunningTask()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        var rand = new System.Random();
        var v = Vector3.zero;
        // Do somethings that takes a long time
        for (var i = 0; i < 30000000; i++)
        {
            v = new Vector3(rand.Next(0, 360), rand.Next(0, 360), rand.Next(0, 360));
        }
        return v;
    }
}