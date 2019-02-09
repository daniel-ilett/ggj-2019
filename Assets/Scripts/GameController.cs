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

	[SerializeField]
	private Entity backButton;

	[SerializeField]
	private Entity forwardButton;

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

		// Subscribe to events on forward and back buttons.
		forwardButton.OnItemClicked += ItemClicked;
		backButton.OnItemClicked += GoBack;
	}

	// Begin the game by advancing to frame 0.
	private void Start()
	{
		ChangeFrame(1);
	}

	// Close the game if Escape is pressed at any point.
	private void Update()
	{
		if(Input.GetButtonDown("Cancel"))
		{
			Application.Quit();
		}
	}

	// Advance the game by one frame.
	public void ItemClicked(Entity sender)
	{
		ChangeFrame(1);
	}

	// Go back a frame.
	public void GoBack(Entity sender)
	{
		ChangeFrame(-1);
	}

	private void ChangeFrame(int delta)
	{
		if(delta > 0)
		{
			++activeFrame;

			if(activeFrame < gameFrames.Count)
			{
				dialogueBox.sprite = gameFrames[activeFrame].newText;

				Entity newEntity = gameFrames[activeFrame].newEntity;
				newEntity?.SetState(PlacementState.Active);

				forwardButton.SetState((newEntity == null) ? PlacementState.Active :
					PlacementState.Hidden);
			}
			else
			{
				// Exit the application when the story has ended.
				Application.Quit();
			}
		}
		else
		{
			gameFrames[activeFrame].newEntity?.SetState(PlacementState.Hidden);

			--activeFrame;

			dialogueBox.sprite = gameFrames[activeFrame].newText;

			Entity newEntity = gameFrames[activeFrame].newEntity;
			newEntity?.SetState(PlacementState.Active);

			forwardButton.SetState((newEntity == null) ? PlacementState.Active :
				PlacementState.Hidden);
		}

		backButton.SetState((activeFrame > 0) ? PlacementState.Active :
			PlacementState.Hidden);
	}
}
