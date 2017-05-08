using System;

public class Service
{
	public Service(String _name, int _id)
	{
        Name = _name;
        Id = _id;
	}

    public String Name { get; set; }
    public int Id { get; set; }
}
