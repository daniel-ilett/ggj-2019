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

	Frame(Entity newEntity, Sprite newText)
	{
		this.newEntity = newEntity;
		this.newText = newText;
	}
}
