using System;
using System.Text;

namespace JXS.Graphics.Generators.Utils;

public class ClassBuilder
{
	private readonly StringBuilder sb;
	private int indentation;

	public ClassBuilder()
	{
		sb = new StringBuilder();
		indentation = 0;
	}

	public string Generate() => sb.ToString();

	public override string ToString() => Generate();

	public void Indent() => indentation++;

	public void Dedent() => indentation--;

	public void BeginBlock(string statement = "")
	{
		if (statement.Length != 0)
		{
			IndentedLn(statement);
		}

		IndentedLn("{");
		Indent();
	}

	public void EndBlock(string suffix = "")
	{
		Dedent();
		IndentedLn($"}}{suffix}");
	}

	public void Raw(string text) => sb.Append(text);

	public void Indented(string code)
	{
		for (var i = 0; i < indentation; i++)
		{
			Raw("\t");
		}

		Raw(code);
	}

	public void IndentedLn(string code) => Indented(code + Environment.NewLine);

	public void Revert(int characterCount) => sb.Remove(sb.Length - characterCount, characterCount);

	public bool EndsWith(string str) => sb.ToString().EndsWith(str);

	public void NewLine() => Raw(Environment.NewLine);
}