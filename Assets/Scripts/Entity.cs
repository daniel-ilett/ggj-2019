/*	An Entity is a selectable item that is placed in the room.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	[SerializeField]
	private Transform tooltipPivot;

	private bool isPlaced = false;

	public Transform GetTooltipPivot()
	{
		return tooltipPivot;
	}
}
