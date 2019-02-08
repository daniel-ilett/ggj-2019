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

	[SerializeField]
	private SpriteRenderer dialogueBox;

	private int activeFrame = -1;

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

	private void ChangeFrame(int delta)
	{
		if(delta > 0)
		{
			++activeFrame;

			dialogueBox.sprite = gameFrames[activeFrame].newText;

			gameFrames[activeFrame].newEntity?.SetState(PlacementState.Active);
		}
		else
		{
			gameFrames[activeFrame].newEntity?.SetState(PlacementState.Hidden);

			--activeFrame;

			dialogueBox.sprite = gameFrames[activeFrame].newText;

			gameFrames[activeFrame].newEntity?.SetState(PlacementState.Active);
		}

		if(activeFrame > 0)
		{
			// Set the back button active.
		}

		if(gameFrames[activeFrame].newEntity == null)
		{
			// Set the forward button active.
		}
	}
}
