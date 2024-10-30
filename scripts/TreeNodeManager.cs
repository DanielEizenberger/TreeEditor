using Godot;
using System;
using System.Collections.Generic;

public partial class TreeNodeManager : Node
{

	[Export] private PackedScene _node;
	private TreeNode rootNode = new TreeNode() { Value = 5 };

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		TreeNode leftChild = new TreeNode() { Value = 1, Parent = rootNode };
		TreeNode rightChild = new TreeNode() { Value = 7, Parent = rootNode };
		rootNode.LeftChild = leftChild;
		rootNode.RightChild = rightChild;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
