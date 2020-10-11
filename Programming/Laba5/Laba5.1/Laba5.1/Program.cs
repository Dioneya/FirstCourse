﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Laba5
{
	class MainClass
	{
		public enum Type { Т, C }

		struct User 
		{
			public string name;
			public Type type;
			public int year;
			public int exp;

			public void DisplayInfo()
			{
				Console.WriteLine("{0,-20} {1,-15} {2,-30} {3,-20}", name, type, year, exp);
			}

		}

		struct Log 
		{
			public DateTime time;
			public string operation;
			public string name;

			public void DisplayLog() 
			{
				Console.WriteLine("{0,-20} - {1,-15} {2,-30}",time,operation,name);
			}
		}

		public static void Main(string[] args)
		{

			User Petrov;
			Petrov.name = "Петров А.А.";
			Petrov.type = Type.Т;
			Petrov.year = 1950;
			Petrov.exp = 22;

			User Shishkin;
			Shishkin.name = "Шишкин С.К.";
			Shishkin.type = Type.Т;
			Shishkin.year = 1984;
			Shishkin.exp = 8;

			User Кравченко;
			Кравченко.name = "Кравченко Г.А.";
			Кравченко.type = Type.C;
			Кравченко.year = 1981;
			Кравченко.exp = 10;

			var table = new List<User>();
			table.Add(Petrov);
			table.Add(Shishkin);
			table.Add(Кравченко);

			var logFile = new List<Log>();
			DateTime time1 = DateTime.Now;
			DateTime time2 = DateTime.Now;
			TimeSpan interval = time2-time1;
			bool errorInOption = true;
			do
			{
				Console.WriteLine("1 – Просмотр таблицы \n2 – Добавить запись \n3 – Удалить запись \n4 – Обновить запись \n5 – Поиск записей \n6 – Просмотреть лог \n7 – Выход");
				int option = Convert.ToInt32(Console.ReadLine());
				switch (option)
				{
					case 1:
						for (int i = 0; i < table.Count; i++)
						{
							table[i].DisplayInfo();
						}
						break;
					case 2:
						
						Console.WriteLine("Введите ФИО");
						string name = Console.ReadLine();
						int exp = 0;
						int year = 0;
						var type = Type.C;
						Console.WriteLine("Введите Тип (Т,С)");
						bool errorType = false;
						do
						{
							string gtype = Console.ReadLine();
							if (gtype == "Т" || gtype == "T")
							{
								type = Type.Т;
								errorType = false;
							}
							else if (gtype == "С" || gtype == "C")
							{
								type = Type.C;
								errorType = false;
							}
							else
							{
								Console.WriteLine("Введите верный тип: Т/С");
								errorType = true;
							}
						}
						while (errorType == true);
						bool errorYear = false;

						do
						{
							Console.WriteLine("Введте год рождения");
							try
							{
								year = Convert.ToInt32(Console.ReadLine());
								if (year >= 1900 && year <= 2019)
								{
									errorYear = false;
								}
								else
								{
									Console.WriteLine("Введите верный год рождения");
									errorYear = true;
								}
							}

							catch
							{
								Console.WriteLine("Введите верный год рождения");
								errorYear = true;
							}
						}
						while (errorYear);

						bool errorExp = false;

						do
						{
							Console.WriteLine("Введите стаж (опыт (лет))");
							try
							{
								exp = Convert.ToInt32(Console.ReadLine());
								errorExp = false;
							}
							catch
							{
								Console.WriteLine("Введите верный стаж опыта");
								errorExp = true;
							}
						}
						while (errorExp);
						User newUser;
						newUser.name = name;
						newUser.type = type;
						newUser.year = year;
						newUser.exp = exp;
						table.Add(newUser);

						Log ADD;
						ADD.time = DateTime.Now;
						ADD.operation = "Добавлена запись";
						ADD.name = name;
						logFile.Add(ADD);

						time1 = DateTime.Now;
						TimeSpan inteval2 = time1-time2;
						if (interval<inteval2) 
						{
							interval = inteval2;
						}
						time2 = ADD.time;
						break;
					case 3:
						Console.WriteLine("Введите  номер записи на удаление");
						bool errorDelete = false;
						do
						{
							try
							{
								int numForDelete = Convert.ToInt32(Console.ReadLine());
								if (numForDelete < table.Count || numForDelete > 0 )
								{
									errorDelete = false;
									Log DELETE;
									DELETE.time = DateTime.Now;
									DELETE.operation = "Запись удалена";
									DELETE.name = table[numForDelete-1].name;
									logFile.Add(DELETE);
									table.RemoveAt(numForDelete-1);
									time1 = DateTime.Now;
									inteval2 = time1 - time2;
									if (interval<inteval2) 
									{
										interval = inteval2;
									}
									time2 = DELETE.time;
								}
								else 
								{
									Console.WriteLine("Введите верный индекс строки");
									errorDelete = true;
								}
							}
							catch 
							{
								Console.WriteLine("Введите верный индекс строки");
								errorDelete = true;
							}
						}
						while (errorDelete);
						break;
					case 4:
						Console.WriteLine("Введите  номер записи на редактирование");
						bool errorEdit = false;
						int numOfEdit = 0;
						do
						{
							try
							{
								numOfEdit = Convert.ToInt32(Console.ReadLine());
								if (numOfEdit < table.Count || numOfEdit > 0)
								{
									errorEdit = false;
								}
								else 
								{
									Console.WriteLine("Введите верный индекс строки");
									errorEdit = true;
								}
							}
							catch 
							{
								Console.WriteLine("Введите верный индекс строки");
								errorEdit = true;
							}
						}
						while (errorEdit);
						Console.WriteLine("Введите ФИО");
						string oldName = table[numOfEdit-1].name;
						name = Console.ReadLine();
						exp = 0;
						year = 0;
						type = Type.Т;
						Console.WriteLine("Введите Тип (Т,С)");
						table.RemoveAt(numOfEdit-1);
						errorType = false;
						do
						{
							string gtype = Console.ReadLine();
							if (gtype == "Т" || gtype == "T")
							{
								type = Type.Т;
								errorType = false;
							}
							else if (gtype == "С" || gtype == "C")
							{
								type =Type.C;
								errorType = false;
							}
							else
							{
								Console.WriteLine("Введите верный тип: Т/С");
								errorType = true;
							}
						}
						while (errorType == true);

						errorYear = false;

						do
						{
							Console.WriteLine("Введте год рождения");
							try
							{
								year = Convert.ToInt32(Console.ReadLine());
								if (year >= 1900 && year <= 2019)
								{
									errorYear = false;
								}
								else
								{
									Console.WriteLine("Введите верный год рождения");
									errorYear = true;
								}
							}

							catch
							{
								Console.WriteLine("Введите верный год рождения");
								errorYear = true;
							}
						}
						while (errorYear);

						errorExp = false;

						do
						{
							Console.WriteLine("Введите стаж (опыт (лет))");
							try
							{
								exp = Convert.ToInt32(Console.ReadLine());
								errorExp = false;

							}
							catch
							{
								Console.WriteLine("Введите верный стаж опыта");
								errorExp = true;
							}
						}
						while (errorExp);
						User EditUser;
						EditUser.name = name;
						EditUser.type = type;
						EditUser.year = year;
						EditUser.exp = exp;

						Log UPDATE;
						UPDATE.time = DateTime.Now;
						UPDATE.operation = "Запись обнавлена";
						UPDATE.name = oldName;
						logFile.Add(UPDATE);
						time1 = UPDATE.time;
						inteval2 = time1 - time2;
						if(interval<inteval2)
						{
							interval = inteval2;
						}
						time2 = UPDATE.time;
						table.Insert(numOfEdit-1, EditUser);
						break;
					case 5:
						Console.WriteLine("Введите выбор поиска:");
						int numOfChoise = 0;
						bool errorChoise = false; 
						Console.WriteLine("1 - Вывести тренеров \n2 - Вывести спортсменов");
						do
						{
							try
							{
								numOfChoise = Convert.ToInt32(Console.ReadLine());
								if (numOfChoise == 1)
								{
									var found = table.FindAll(x => x.type == Type.Т);
									foreach (var gg in found) 
									{
										gg.DisplayInfo();
									}
									errorChoise = false;
								}
								else if (numOfChoise == 2)
								{
									
									var found = table.FindAll(x => x.type == Type.C);
									foreach (var gg in found)
									{
										gg.DisplayInfo();
									}
									errorChoise = false;
								}
								else
								{
									errorChoise = true;
								}

							}
							catch
							{
								Console.WriteLine("Введите верный вариант");
								errorChoise = true;
							}

						}
						while (errorChoise);
						break;
					case 6:
						for (int i = 0; i < logFile.Count; i++)
						{
							logFile[i].DisplayLog();
						}
						Console.WriteLine();
						Console.WriteLine(interval+" - Самый долгий период бездействия пользователя");
						break;
					case 7:
						errorInOption = false;
						break;
					default:
						Console.WriteLine("Введите верную команду");
						errorInOption = true;
						break;
				}
			}
			while (errorInOption);
		}
	}
}
