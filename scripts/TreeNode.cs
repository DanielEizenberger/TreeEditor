using Godot;
using System;
using System.Linq;

public partial class TreeNode : Node2D
{
	[Export] private PackedScene _node;
	[Export] private Label _valueLabel;
	[Export] private Label _leftHeightLabel;
	[Export] private Label _rightHeigtLabel;
	[Export] private Button _addLeftChildButton;
	[Export] private Button _addRightChildButton;

	public int Value { get; set; }
	public int Height { get; set; }

	public TreeNode? Parent { get; set; }
	public TreeNode? LeftChild { get; set; }
	public TreeNode? RightChild { get; set; }

	private Sprite2D _childSprite;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_childSprite = GetChild<Sprite2D>(0, true);

		_addLeftChildButton.Pressed += AddLeftChild;
		_addRightChildButton.Pressed += AddRightChild;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void AddLeftChild() => AddTreeNodeChild(true);
	private void AddRightChild() => AddTreeNodeChild(false);

	private void AddTreeNodeChild(bool left)
	{
		Node node = this.Duplicate((int)DuplicateFlags.UseInstantiation);
		if (node is TreeNode == false) return;
		else this.AddChild(node);

		if (left) _addLeftChildButton.Hide();
		else _addRightChildButton.Hide();

		TreeNode treeNode = (TreeNode)node;
		Vector2 spriteSize = _childSprite.Texture.GetSize() * _childSprite.Scale;
		if (left) treeNode.GlobalPosition = this.GlobalPosition + new Vector2(-spriteSize.X, spriteSize.Y);
		else treeNode.GlobalPosition = this.GlobalPosition + spriteSize;

		GD.Print(treeNode.GlobalPosition);

		treeNode.Parent = this;
		if (left) LeftChild = treeNode;
		else RightChild = treeNode;

		QueueRedraw();
	}

	public override void _Draw()
	{
		base._Draw();
		if (LeftChild != null) DrawLineBetweenNodes(this.GlobalPosition, LeftChild.GlobalPosition);
		if (RightChild != null) DrawLineBetweenNodes(this.GlobalPosition, RightChild.GlobalPosition);
	}

	private void DrawLineBetweenNodes(Vector2 from, Vector2 to) => DrawLine(from, to, Color.Color8(0, 0, 0, 255), 1, true);
}
