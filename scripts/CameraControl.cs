using Godot;
using System;

public partial class CameraControl : Camera2D
{
    public override void _UnhandledInput(InputEvent @event)
	{
		base._UnhandledInput(@event);

		if (@event is InputEventKey eventKey)
		{
			// if (eventKey.Pressed && eventKey.Keycode == Key.)
			// {
			// 	GetTree().Quit();
			// }
		}
		else if (@event is InputEventMouseButton)
		{

		}
		else if (@event is InputEventMagnifyGesture)
		{
			this.Scale *= ((InputEventMagnifyGesture)@event).Factor;
		}
	}
}
