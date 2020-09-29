using System;

public class IconDisplayer
{
	private float _posX;
	public float posX{
		get{
			return _posX;
		}
	}
	private float _posY;
	public float posY{
		get{
			return _posY;
		}
	}
	private float _scaleX;
	public float scaleX{
		get{
			return _scaleX;
		}
	}
	private float _scaleY;
	public float scaleY{
		get{
			return _scaleY;
		}
	}
	public IconDisplayer (float pX, float pY, float sX, float sY)
	{
		_posX = pX;
		_posY = pY;
		_scaleX = sX;
		_scaleY = sY;
	}
}

