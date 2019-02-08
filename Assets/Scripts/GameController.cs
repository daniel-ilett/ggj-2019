/*	GameController will handle the progression of events.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private List<Frame> gameFrames;

	[SerializeField]
	private List<Entity> entities;

	public static GameController instance;

	private void Awake()
	{
		instance = this;

		// Subscribe to all entity item click events.
		foreach(var entity in entities)
		{
			entity.OnItemClicked += ItemClicked;
		}
	}

	public void ItemClicked(Entity sender)
	{

	}
}
