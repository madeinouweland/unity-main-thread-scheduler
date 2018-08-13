# unity-main-thread-scheduler
A lightweight singleton MonoBehavior that allows you to dispatch work on the main thread in Unity

## Usage

- Add [Scheduler](https://github.com/madeinouweland/unity-main-thread-scheduler/blob/master/unity/Assets/Scheduler.cs) to your unity project:
- Attach the scheduler script to an empty or existing **GameObject**
- Dispatch work like this:

```
var result = await client.Get("https://jsonplaceholder.typicode.com/todos/1"); // result coming from different thread

Scheduler.Current.Schedule(() =>
{
    GetComponent<TextMesh>().text = result;
});
```
