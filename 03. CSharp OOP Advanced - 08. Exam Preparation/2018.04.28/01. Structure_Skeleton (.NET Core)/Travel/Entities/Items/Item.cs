﻿namespace Travel.Entities.Items
{
	using Contracts;

	public abstract class Item : IItem
	{
        public int Value { get; private set; }
        protected Item(int value)
		{
			this.Value = value;
		}
	}
}