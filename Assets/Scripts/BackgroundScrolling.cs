using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ExtensionMethods;

public class BackgroundScrolling : MonoBehaviour {

	//scrollingSpeed
	public Vector2 speed = new Vector2(2, 2);

	//moving direction
	public Vector2 direction = new Vector2(0, 1);

	//movement should be applied to camera
	public bool isLinkedToCamera = false;

	public bool isLooping = false;

	private List<SpriteRenderer> backgroundPart;
	private Vector2 repeatableSize;

	// Use this for initialization
	void Start () {

		//for infinite background:

		if (isLooping) {
		
			//retrieve all children of the background layer/gameObject
			backgroundPart = new List<SpriteRenderer> ();

			for (int i = 0; i < transform.childCount; i++) {
				
				Transform child = transform.GetChild (i);
				SpriteRenderer r = child.GetComponent<SpriteRenderer> ();

				//only visible children

				if (r != null) {
				
					backgroundPart.Add (r);
				}
					
			}

			if (backgroundPart.Count == 0) {
			
				Debug.LogError ("Nothing to scroll!");
			
			}
			//sort by position: depends on the scrolling direction

			backgroundPart = backgroundPart.OrderBy(t => t.transform.position.x * (-1 * direction.x)).ThenBy(t => t.transform.position.y * (-1 * direction.y)).ToList();
	
			//get size of repeatable parts

			var first = backgroundPart.First ();
			var last = backgroundPart.Last ();

			repeatableSize = new Vector2 (
				Mathf.Abs (last.transform.position.x - first.transform.position.x),
				Mathf.Abs (last.transform.position.y - first.transform.position.y)
			);
		}

	}
	
	// Update is called once per frame
	void Update () {

		//move
		Vector3 movement = new Vector3 (
			                   speed.x * direction.x,
			                   speed.y * direction.y,
			                   0 );

		movement *= Time.deltaTime;
		transform.Translate (movement);

		if (isLinkedToCamera) {
		
			Camera.main.transform.Translate (movement);
		}

		//loop

		if (isLooping) {
		
		//check if object is before, in, or after the camera bounds

			//camera borders

			var dist = (transform.position - Camera.main.transform.position).z;
			float leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).x;
			float rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, dist)).x;

			float topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).y;
			float bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, dist)).y;


			//determine entry and exit border using Direction

			Vector3 exitBorder = Vector3.zero;
			Vector3 entryBorder = Vector3.zero;

			if (direction.x < 0) {
			
				exitBorder.x = leftBorder;
				entryBorder.x = rightBorder;
			} else if (direction.x > 0) {
			
				exitBorder.x = rightBorder;
				entryBorder.x = leftBorder;
			}
			if (direction.y < 0) {
				exitBorder.y = bottomBorder;
				entryBorder.y = topBorder;
			
			} else if (direction.y > 0) {
			
				exitBorder.y = topBorder;
				entryBorder.y = bottomBorder;
			}


			//get the first Object

			SpriteRenderer firstChild = backgroundPart.FirstOrDefault ();

			if (firstChild != null) {
			
				bool checkVisible = false;

				//check if we are after the camera
				//check border again, depending on direction
				if(direction.x != 0){

				if((direction.x < 0 && (firstChild.transform.position.x < exitBorder.x))
					|| (direction.x > 0 && (firstChild.transform.position.x > exitBorder.x)))
						{
					checkVisible = true;

						}
			}


				if (direction.y != 0) {
					if((direction.y < 0 && (firstChild.transform.position.y < exitBorder.y))
						|| (direction.y > 0 && (firstChild.transform.position.y > exitBorder.y)))
					{
						checkVisible = true;

					}
				}

				//check if sprite is really visible on the camera or not

				if (checkVisible) {
					//object was in the camera bounds but isn't anymore
					//object has to be recycled
					//object that was first is now last, and we physically move it to the farest position
				
					if (RendererExtensions.IsVisibleFrom(firstChild,Camera.main)) {
					
						firstChild.transform.position = new Vector3 (
							firstChild.transform.position.x + ((repeatableSize.x = firstChild.bounds.size.x) * -1 * direction.x),
							firstChild.transform.position.y + ((repeatableSize.y = firstChild.bounds.size.y) * -1 * direction.y),
							firstChild.transform.position.z
						);

						//first part becomes last part
						backgroundPart.Remove(firstChild);
						backgroundPart.Add(firstChild);
					}
			
				}

		}



	}
	}
}

