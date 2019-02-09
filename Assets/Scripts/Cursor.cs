using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Cursor : MonoBehaviour
{
	private List<Collider2D> lastTargets = new List<Collider2D>();

	private new Camera camera;

	private void Awake()
	{
		camera = GetComponent<Camera>();
	}

	private void Update()
	{
		Vector2 cursorPos = camera.ScreenToWorldPoint(Input.mousePosition);
		Collider2D[] currTargets = Physics2D.OverlapPointAll(cursorPos);

		// Pass through each target to decide if it should display tooltips.
		foreach (var target in currTargets)
		{
			if (lastTargets.Contains(target))
			{
				lastTargets.Remove(target);
			}
			else
			{
				target.GetComponent<Entity>()?.IsHovered(true);
			}
		}

		// We are no longer hovering over some targets.
		foreach (var target in lastTargets)
		{
			target.GetComponent<Entity>()?.IsHovered(false);
		}

		// Click the targeted items if need be.
		if (Input.GetButtonDown("Fire1"))
		{
			foreach (var target in currTargets)
			{
				target.GetComponent<Entity>()?.IsClicked();
			}
		}

		lastTargets = new List<Collider2D>(currTargets);
	}
}
