/*	An Entity is a selectable item that is placed in the room.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SpriteGlow;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(SpriteGlowEffect))]
public class Entity : MonoBehaviour
{
	[SerializeField]
	private Transform tooltipPivot;

	[SerializeField]
	private Sprite unknownSprite;

	private Sprite tooltipSprite;

	private PlacementState placementState = PlacementState.Hidden;

	private Color activeColour = new Color(1.0f, 1.0f, 1.0f, 0.01f);

	private SpriteGlowEffect glowEffect;
	private new SpriteRenderer renderer;

	private void Awake()
	{
		renderer = GetComponent<SpriteRenderer>();
		glowEffect = GetComponent<SpriteGlowEffect>();

		SetState(PlacementState.Hidden);
	}

	// Set the sprite properties based on the state of the entity.
	public void SetState(PlacementState newState)
	{
		placementState = newState;

		switch(placementState)
		{
			case PlacementState.Hidden:
				gameObject.SetActive(false);
				break;

			case PlacementState.Active:
				gameObject.SetActive(true);
				renderer.color = activeColour;
				break;

			case PlacementState.Placed:
				renderer.color = Color.white;
				glowEffect.OutlineWidth = 0;
				break;
		}
	}

	public Transform SetTooltipActive(bool active)
	{
		tooltipPivot.gameObject.SetActive(active);
		return tooltipPivot;
	}
}
