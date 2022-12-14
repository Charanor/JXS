namespace JXS.Input.Core;

public class ScrollWheel : Axis
{
	private float value = Single.NaN;
	private float prevValue = Single.NaN;

	public ScrollWheel(ScrollDirection direction = ScrollDirection.Vertical)
	{
		Direction = direction;
	}

	public override float Value => value;
	public ScrollDirection Direction { get; init; }

	public override void Update(IInputProvider inputProvider, float delta)
	{
		base.Update(inputProvider, delta);
		var currentValue = GetCurrentValue(inputProvider);
		var difference = float.IsNaN(prevValue) ? 0 : currentValue - prevValue;
		prevValue = currentValue;
		value = difference;
	}

	private float GetCurrentValue(IInputProvider inputProvider) => Direction switch
	{
		ScrollDirection.Vertical => inputProvider.MouseState.Scroll.Y,
		ScrollDirection.Horizontal => inputProvider.MouseState.Scroll.X,
		_ => 0
	};

	public void Deconstruct(out ScrollDirection direction)
	{
		direction = Direction;
	}
}