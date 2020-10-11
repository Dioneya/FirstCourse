using System;
using System.Collections.Generic;
namespace Laba9
{
	class MainClass
	{
		struct Game 
		{
			public int scoreFirstTeam;
			public int scoreSecondTeam;
			public string firstCountry;
			public string secondCountry;

			public string ConvertToString() 
			{
				string info = firstCountry+" "+secondCountry+" "+scoreFirstTeam+"-"+scoreSecondTeam;
				return info;
			}
		}

		public static void Main(string[] args)
		{
			var tree = new BinaryTree<Game>();
			string[] country = { "COL", "URU", "BRA", "CHI", "FRA", "NIG", "GER", "ALG", "NED", "MEX", "CRC", "GRE", "ARG", "SWI", "BEL", "USA" };
			//int[] numOfGame = { 4, 12, 2, 6, 1 ,3, 5, 7, 10,14,9,11,13,15 };
			Game[] games = new Game[country.Length/2];
			var rnd = new Random();

			for (int i = 0, j = 0; i < games.Length; i++, j+=2) 
			{
				Game game;
				game.firstCountry = country[j];
				game.secondCountry = country[j+1];
				game.scoreFirstTeam = rnd.Next(0,6);
				game.scoreSecondTeam = rnd.Next(0, 6);

				games[i] = game; 
			}

			Game emptyGame;
			emptyGame.firstCountry = "";
			emptyGame.secondCountry = "";
			emptyGame.scoreFirstTeam = 0;
			emptyGame.scoreSecondTeam = 0;

			BinaryTreeNode<Game>[] node = new BinaryTreeNode<Game>[15]; // массив ссылок на узлы

			for (int i = 0, j = 3; i < (node.Length-1)/2; i++) // заполнение дерева пустыми значениями
			{
				if (i == 0)
				{
					node[0] = tree.AddRoot(emptyGame);
					node[1] = tree.AddLeft(node[0], emptyGame);
					node[2] = tree.AddRight(node[0], emptyGame);
				}
				else
				{
					node[j] = tree.AddLeft(node[i], emptyGame); //i отвечает за индекс родителя, j - дети
					j++;
					node[j] = tree.AddRight(node[i], emptyGame);
					j++;
				}

			}

			for (int i = node.Length - 1, j = games.Length - 1; j>-1; i--,j-- ) //заполняем листья уже счётом игры команд
				node[i].data = games[j];
			

			for (int i = 6; i > -1; i--)
				node[i].data = ResultOfNextGame(node[i].left.data, node[i].right.data);

			InOrderTraversal(node[0]);

			Console.ReadKey();
		}









		static Game ResultOfNextGame(Game game, Game game1) // для создания нового матча, где берётся победитель с нижней сетки одной игры и с другой игры и делается им рандомный счёт
		{
			string FirstCountry = "";
			string SecondCountry = "";
			var rnd = new Random();

			if (game.scoreFirstTeam >= game.scoreSecondTeam)
				FirstCountry = game.firstCountry;

			else
				FirstCountry = game.secondCountry;
			
			if (game1.scoreFirstTeam >= game1.scoreSecondTeam)
				SecondCountry = game1.firstCountry;
			else
				SecondCountry = game1.secondCountry;

			Game halfGame;
			halfGame.firstCountry = FirstCountry;
			halfGame.secondCountry = SecondCountry;
			halfGame.scoreFirstTeam = rnd.Next(0, 6);
			halfGame.scoreSecondTeam = rnd.Next(0, 6);
			return halfGame;
		}

		static void InOrder(BinaryTreeNode<Game> node, int level = 0) //обход через центр. Вынес из класса, для того, чтобы можно было работать с типом данных струтуры.
		{
			if (node != null)
			{

				InOrder(node.left, level + 1);
				string info = node.data.ConvertToString();
				for (int i = 0; i < level; i++)
					info = "              " + info;
				Console.WriteLine(info);

				InOrder(node.right, level + 1);
			}
		}

		static void InOrderTraversal(BinaryTreeNode<Game> root)
		{
			InOrder(root);
		}
	}
}
