using UnityEngine;

public class NamedArrayAttribute : PropertyAttribute
{
#if UNITY_EDITOR
    public string customName = null;

    public string prefix = null;
    public string fieldName = null;
    public string[] enumNames;
    public int enumLength;
    public int enumOffest;
    public bool isFormat;

    public NamedArrayAttribute(string custom, bool isFormat = false, int startOffest = 0)
    {
        this.isFormat = isFormat;
        this.enumOffest = startOffest;
        SetStringAttribute(custom);
    }

    public NamedArrayAttribute(string fieldName, string custom, int startOffest = 0)
    {
        this.fieldName = fieldName;
        this.enumOffest = startOffest;
        SetStringAttribute(custom);
    }

    public NamedArrayAttribute(System.Type names_enum_type, string prefix = null, int startOffest = 0)
    {
        this.prefix = prefix;
        this.enumOffest = startOffest;
        SetEnumAttribute(names_enum_type);
    }

    private void SetEnumAttribute(System.Type names_enum_type)
    {
        this.enumNames = System.Enum.GetNames(names_enum_type);
        this.enumLength = enumNames.Length;
    }

    private void SetStringAttribute(string custom)
    {
        this.customName = custom;
    }
#else
    public NamedArrayAttribute(string custom, bool isFormat = false, int startOffest = 0)
	{
	}

    public NamedArrayAttribute(string fieldName, string custom, int startOffest = 0)
	{
	}

	public NamedArrayAttribute(System.Type names_enum_type, string prefix = null,int startOffest=0)
	{
	}
#endif

}
