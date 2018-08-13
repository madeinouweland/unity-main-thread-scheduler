using System.Threading.Tasks;
using RestTest;
using UnityEngine;

public class App : MonoBehaviour
{
	void Start()
	{
		FetchFakeData();
	}

	private void FetchFakeData()
	{
		var client = new RestClient();

		Task.Run(async () =>
		{
			var result = await client.Get("https://jsonplaceholder.typicode.com/todos/1");

			Scheduler.Current.Schedule(() =>
			{
				var mesh = GetComponent<TextMesh>();
				mesh.text = result;
				Debug.Log(mesh);
			});
		});
	}
}
