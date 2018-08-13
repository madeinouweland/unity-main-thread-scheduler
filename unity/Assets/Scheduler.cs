using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Scheduler : MonoBehaviour
{
	private static Scheduler _scheduler;
	private object _lock = new object();
	private List<Action> _work = new List<Action>();

	public static Scheduler Current
	{
		get
		{
			if (_scheduler == null)
			{
				Debug.Log("Scheduler is null. Add it to a gameobject in the hierarchy.");
			}
			return _scheduler;
		}
	}

	private void Awake()
	{
		_scheduler = this;
	}

	public void Schedule(Action work)
	{
		lock (_lock)
		{
			_work.Add(work);
		}
	}

	private void Update()
	{
		var first = _work.FirstOrDefault();
		if (first != null)
		{
			first.Invoke();
		}
		lock (_lock)
		{
			_work = _work.Skip(1).ToList();
		}
	}
}
