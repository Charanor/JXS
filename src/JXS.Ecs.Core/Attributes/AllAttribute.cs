namespace JXS.Ecs.Core.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class AllAttribute : Attribute
{
	public AllAttribute(params Type[] componentTypes)
	{
		Types = componentTypes;
	}

	public Type[] Types { get; }
}