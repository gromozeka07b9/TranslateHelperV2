﻿using System;
using TranslateHelper.Core.BL.Contracts;
using SQLite;

namespace TranslateHelper.Core
{
	public class Direction : IBusinessEntity
	{
		public Direction ()
		{
		}
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public int DeleteMark { get; set; }
		public string Name { get; set; }
		public TranslateProvider ProviderID { get; set; }
	}
}
