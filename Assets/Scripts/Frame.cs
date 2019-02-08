/*	A Frame contains the difference between two states in the game.
 */

using UnityEngine;

[System.Serializable]
public struct Frame
{
	[SerializeField]
	Entity newEntity;

	[SerializeField]
	Sprite newText;

	[SerializeField]
	bool advanceWithClick;

	Frame(Entity newEntity, Sprite newText, bool advanceWithClick)
	{
		this.newEntity = newEntity;
		this.newText = newText;
		this.advanceWithClick = advanceWithClick;
	}
}
