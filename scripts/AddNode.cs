using Godot;
using System;

public partial class AddNode : Button
{
	[Export] private PackedScene _node;

	public void OnPressed()
	{
		Node n = _node.Instantiate();
		GetTree().Root.AddChild(n);
	}
}
