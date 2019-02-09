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
	private bool canClickToAdvanceIPromiseThisIsDebug = false;

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

	// Begin the game by advancing to frame 0.
	private void Start()
	{
		ChangeFrame(1);
	}

	private void Update()
	{
		if(Input.GetButtonDown("Fire1") && canClickToAdvanceIPromiseThisIsDebug)
		{
			ChangeFrame(1);
		}
	}

	// Advance the game by one frame.
	public void ItemClicked(Entity sender)
	{
		ChangeFrame(1);
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

		canClickToAdvanceIPromiseThisIsDebug = (gameFrames[activeFrame].newEntity == null);
	}
}
