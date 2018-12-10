using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

	public CharacterState myCharacterState;
	public CharacterEvent myCharacterEvent;
	public int HandState = 0;

	public enum CharacterState {
		Unknown = 0,
		None,
		ObjectGrab,
		ObjectEatOrDrink,
		ObjectGet,
		ObjectPutOrThrow
	}

	public enum CharacterEvent {
		Unknown = 0,
		None,
		Grab,
		EatOrDrink,
		Get,
		PutOrThrow
	}

	void Awake() {
		myCharacterState = CharacterState.Unknown;
		myCharacterEvent = CharacterEvent.Unknown;
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) < 0.2 && OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) < 0.2) {
            ActNone();
        }

        if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) > 0.7 || OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) > 0.7) {
            ActGrab();
        }


	}

	public void ActGrab() {
		myCharacterState = CharacterState.ObjectGrab;
		myCharacterEvent = CharacterEvent.Grab;
	}

	public void ActEatOrDrink() {
		myCharacterState = CharacterState.ObjectEatOrDrink;
		myCharacterEvent = CharacterEvent.EatOrDrink;
	}

	public void ActGet() {
		myCharacterState = CharacterState.ObjectGet;
		myCharacterEvent = CharacterEvent.Get;
	}

	public void ActPutOrThrow() {
		myCharacterState = CharacterState.ObjectPutOrThrow;
		myCharacterEvent = CharacterEvent.PutOrThrow;
	}

	public void ActNone() {
		myCharacterState = CharacterState.None;
		myCharacterEvent = CharacterEvent.None;
	}

}
