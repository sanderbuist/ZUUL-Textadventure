using System;

namespace Zuul
{
	public class Game
	{
		private Parser parser;
		private Player player;
		private Inventory inventory;

		public Game ()
		{
			player = new Player();
			CreateRooms();
			parser = new Parser();
			inventory = new Inventory();
		}

		private void CreateRooms()
		{
			// create the rooms
			Room outside = new Room("in front of the ruined castle gate");
			Room gate = new Room("inside of the gate portcullis");
			Room smithy = new Room("in the old blacksmith, there is still some equipment lying around");
			Room alchemist = new Room("in an alchemists lab, there is still some brewing equipment present");
			Room keep = new Room("in the keeps entrance hall");
			Room basement = new Room("in a basement, half underwater and filled with mold");
			Room courtyard = new Room("standing in the middle of the castle courtyard");

			Item dagger = new Item(2,"dagger", "a dagger for stabbing enemies");
			Item warhammer = new Item(5,"warhammer", "A warhammer for smashing skulls");
			
			// initialise room exits
			outside.AddExit("east", gate);

			gate.AddExit("west", outside);
			gate.AddExit("east", courtyard);

			courtyard.AddExit("north", smithy);
			courtyard.AddExit("south", alchemist);
			courtyard.AddExit("west", gate);
			courtyard.AddExit("east", keep);

			smithy.AddExit("south", courtyard);

			alchemist.AddExit("north", courtyard);

			keep.AddExit("west", courtyard);

            courtyard.Chest.Put(dagger);

			//lab.AddExit("north", outside);
			//lab.AddExit("east", office);

			//office.AddExit("west", lab);

			//basement.AddExit("up", outside);


			player.CurrentRoom = outside;  // start game outside
		}

		/**
		 *  Main play routine.  Loops until end of play.
		 */
		public void Play()
		{
			PrintWelcome();

			// Enter the main command loop.  Here we repeatedly read commands and
			// execute them until the player wants to quit.
			bool finished = false;
			while (!finished)
			{
				Command command = parser.GetCommand();
				finished = ProcessCommand(command);
			}
			Console.WriteLine("Thank you for playing.");
			Console.WriteLine("Press [Enter] to continue.");
			Console.ReadLine();
		}

		private void Take(Command command)
		{ 
			//use code definded in player.cs to take item from chest
		}
		private void Drop(Command command) 
		{ 
			//same as above but drop to chest
		}

		/**
		 * Print out the opening message for the player.
		 */
		private void PrintWelcome()
		{
			Console.WriteLine();
			Console.WriteLine("Welcome to Zuul!");
			Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
			Console.WriteLine("In where you go exploring an abandoned castle");
			Console.WriteLine("Type 'help' if you need help.");
			Console.WriteLine();
			Console.WriteLine(player.CurrentRoom.GetLongDescription());
		}

		/**
		 * Given a command, process (that is: execute) the command.
		 * If this command ends the game, true is returned, otherwise false is
		 * returned.
		 */
		private bool ProcessCommand(Command command)
		{
			bool wantToQuit = false;

			if(command.IsUnknown())
			{
				Console.WriteLine("I don't know what you mean...");
				return false;
			}

			string commandWord = command.GetCommandWord();
			switch (commandWord)
			{
				case "help":
					PrintHelp();
					break;
				case "go":
					GoRoom(command);
					break;
				case "quit":
					wantToQuit = true;
					break;
				case "look":
					Console.WriteLine(player.CurrentRoom.GetLongDescription());
					break;
				case "health":
					Console.WriteLine("Player health: " + player.Health);
					break;
				case "inventory":
					//Console.WriteLine("uwe moeke");
					Player.inventory;
					break;
				case "take":
					Game.Take(Command ,command);
					Console.WriteLine("dikzak");
					break;
				case "drop":
					Game.Drop(Command, command);
					Console.WriteLine("dikzak pt2");
					break;
			}

			return wantToQuit;
		}

		// implementations of user commands:

		/**
		 * Print out some help information.
		 * Here we print the mission and a list of the command words.
		 */
		private void PrintHelp()
		{
			Console.WriteLine("You are outside a ruined castle");
			Console.WriteLine("The air is thick and humid");
			Console.WriteLine();
			// let the parser print the commands
			parser.PrintValidCommands();
		}

		/**
		 * Try to go to one direction. If there is an exit, enter the new
		 * room, otherwise print an error message.
		 */
		private void GoRoom(Command command)
		{
			if(!command.HasSecondWord())
			{
				// if there is no second word, we don't know where to go...
				Console.WriteLine("Go where?");
				return;
			}

			string direction = command.GetSecondWord();

			// Try to go to the next room.
			Room nextRoom = player.CurrentRoom.GetExit(direction);

			if (nextRoom == null)
			{
				Console.WriteLine("There is no door to "+direction+"!");
			}
			else
			{
				player.CurrentRoom = nextRoom;
				Console.WriteLine(player.CurrentRoom.GetLongDescription());
			}
		}

	}
}
