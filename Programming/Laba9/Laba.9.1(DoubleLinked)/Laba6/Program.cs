using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
namespace Laba6
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
				Console.WriteLine("{0,-20} - {1,-15} {2,-30}", time, operation, name);
			}
		}

		public static void Main(string[] args)
		{
			var table = new DoublyLinkedList<User>();
			string TextFilePath = @"C:\Users\user\Documents\Projects\ЛАБАРАТОРНАЯ 9\Laba.9.1\lab.dat";
			using (StreamReader readTextFile = new StreamReader(TextFilePath))
			{
				bool isFirst = true;
				while (readTextFile.Peek() > -1) 
				{
					string name = readTextFile.ReadLine();
					string typeText = readTextFile.ReadLine();
					Type type;
					if (typeText == "T" || typeText == "Т")
					{
						type = Type.Т;
					}
					else
					{
						type = Type.C;
					}
					int year = Convert.ToInt32(readTextFile.ReadLine());
					int exp = Convert.ToInt32(readTextFile.ReadLine());
					User NewUser;
					NewUser.name = name;
					NewUser.type = type;
					NewUser.year = year;
					NewUser.exp = exp;

					if (isFirst)
					{
						table.AddFirst(NewUser);
						isFirst = false;
					}
					else 
					{
						table.Add(NewUser);
					}

				}
			}

			var logFile = new List<Log>();
			DateTime time1 = DateTime.Now;
			DateTime time2 = DateTime.Now;
			TimeSpan interval = time2 - time1;
			bool errorInOption = true;
			do
			{
				Console.WriteLine("1 – Просмотр таблицы \n2 – Добавить запись \n3 – Удалить запись \n4 – Обновить запись \n5 – Поиск записей \n6 – Просмотреть лог \n7 – Сортировка\n8 - Выход");
				int option = Convert.ToInt32(Console.ReadLine());
				switch (option)
				{
					case 1:
						
						foreach (var users in table)
						{
							Console.WriteLine("{0,-20} {1,-15} {2,-30} {3,-20}", users.name, users.type, users.year, users.exp);
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
						TimeSpan inteval2 = time1 - time2;
						if (interval < inteval2)
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
								if (numForDelete < table.Count || numForDelete > 0)
								{
									errorDelete = false;
									Log DELETE;
									DELETE.time = DateTime.Now;
									DELETE.operation = "Запись удалена";
									int cnt1 = 0;
									string DeleteName = "";
									foreach (User users in table) 
									{
										if (cnt1==numForDelete-1) 
										{
											DeleteName = users.name;
											table.Remove(users);
										}
										cnt1++;
									}
									DELETE.name = DeleteName;
									logFile.Add(DELETE);
									time1 = DateTime.Now;
									inteval2 = time1 - time2;
									if (interval < inteval2)
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
						string oldName = "";
						int cnt = 0;
						foreach (var users in table) 
						{
							if (cnt==numOfEdit-1) 
							{
								oldName = users.name;
								table.Remove(users);
							}
							cnt++;
						}
						name = Console.ReadLine();
						exp = 0;
						year = 0;
						type = Type.Т;
						Console.WriteLine("Введите Тип (Т,С)");
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
						if (interval < inteval2)
						{
							interval = inteval2;
						}
						time2 = UPDATE.time;
						cnt = 0;
						table.AddToPosition(EditUser, numOfEdit-1);
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
									User[] founded = new User[50];
									int cntUserFounded = 0;
									foreach (User user in table) 
									{
										if (user.type == Type.Т) 
										{
											founded[cntUserFounded] = user;
											cntUserFounded++;
										}
									}
									for (int i = 0; i < cntUserFounded; i++)
									{
										Console.WriteLine("{0,-20} {1,-15} {2,-30} {3,-20}", founded[i].name, founded[i].type, founded[i].year, founded[i].exp);
									}
									errorChoise = false;
								}
								else if (numOfChoise == 2)
								{

									User[] founded = new User[50];
									int cntUserFounded = 0;
									foreach (User user in table)
									{
										if (user.type == Type.C)
										{
											founded[cntUserFounded] = user;
											cntUserFounded++;
										}
									}
									for (int i = 0; i < cntUserFounded; i++)
									{
										Console.WriteLine("{0,-20} {1,-15} {2,-30} {3,-20}", founded[i].name, founded[i].type, founded[i].year, founded[i].exp);
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
						Console.WriteLine(interval + " - Самый долгий период бездействия пользователя");
						break;
					case 7:
						User[] sorted = new User[50];
						int cntUserSorted = 0;
						foreach (User user in table)
						{
							sorted[cntUserSorted] = user;
							cntUserSorted++;
						}
						for (int i = 1; i < cntUserSorted; i++) 
						{
							int j;
							var buffer = sorted[i];
							char firstLeter = sorted[i].name[0];
							for (j = i - 1; j >= 0; j--) 
							{
								if (sorted[j].name[0] < firstLeter) 
								{
									break;
								}
								sorted[j + 1] = sorted[j];
							}
							sorted[j + 1] = buffer;
						}
						table.Clear();
						for (int i = 0; i < cntUserSorted; i++)
						{
							if (i == 0)
							{
								table.AddFirst(sorted[i]);
							}
							else 
							{
								table.Add(sorted[i]);
							}
						}
						break;
					case 8:
						errorInOption = false;
						using (var rewriteTextFile = new StreamWriter(TextFilePath, false))
						{
							foreach (var users in table)
							{
								rewriteTextFile.WriteLine(users.name + "\n" + users.type + "\n" + users.year + "\n" + users.exp);
							}
							rewriteTextFile.Close();
						}
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
