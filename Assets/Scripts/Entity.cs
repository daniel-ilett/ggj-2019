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
	private SpriteRenderer tooltipPivot;

	[SerializeField]
	private Sprite unknownSprite;

	private Sprite tooltipSprite;

	private PlacementState placementState = PlacementState.Hidden;

	private Color activeColour = new Color(1.0f, 1.0f, 1.0f, 0.01f);

	private SpriteGlowEffect glowEffect;
	private new SpriteRenderer renderer;

	public delegate void ClickedHandler(Entity sender);
	public event ClickedHandler OnItemClicked;

	private void Awake()
	{
		renderer = GetComponent<SpriteRenderer>();
		glowEffect = GetComponent<SpriteGlowEffect>();

		tooltipSprite = tooltipPivot.sprite;

		SetState(PlacementState.Hidden);
		glowEffect.OutlineWidth = 0;
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

	// Set the appropriate tooltip on the item.
	public void IsHovered(bool isHovered)
	{
		tooltipPivot.gameObject.SetActive(isHovered && (placementState != PlacementState.Hidden));

		tooltipPivot.sprite = (placementState == PlacementState.Placed) ?
			tooltipSprite : unknownSprite;

		glowEffect.OutlineWidth = (isHovered && placementState == PlacementState.Active) ? 10 : 0;
	}

	// The item is clicked by the player and 'placed' in the level.
	public void IsClicked()
	{
		if(placementState == PlacementState.Active)
		{
			OnItemClicked(this);
			SetState(PlacementState.Placed);

			IsHovered(true);
		}
	}
}
