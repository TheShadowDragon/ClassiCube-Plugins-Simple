//Warning: my first plugin. Can be way better. Commented some ways to make this way better.

using System;
using MCGalaxy;
using MCGalaxy.Commands;



namespace MegaCraft
{
	public sealed class RPS : Plugin {
		public override string name {get {return "RockPaperScissors"; } }
		public override string creator { get { return "DarkWolf"; } }
		public override string MCGalaxy_Version { get { return "1.9.1.9"; } }




		public override void Load(bool startup) {
			Command.Register(new CmdRps());
			Chat.MessageGlobal("The Rock Paper Scissors plugin loaded!");
		}//bool start up

		public override void Unload(bool shutdown) {
				 Command.Unregister(Command.Find("rps"));

      Chat.MessageGlobal("&cRock Paper Scissors plugin has unloaded for you!");
		}//Bool Shutdown
	} //Public Sealed Class

	public class CmdRps : Command {
		public override string name { get { return "rockpaperscissors"; }}
		public override string shortcut { get {return "rps"; }}
		public override string type { get { return "games"; }}

	public override LevelPermission defaultRank { get { return LevelPermission.Guest; }}


	public override void Help(Player commandUser) {
	      Player.Message(commandUser, "%T/rps or /rockpaperscissors");
	      Player.Message(commandUser, "%HPlays rock paper scissors with you.Costs 10 coins!");
	  }// Player command User for /help

public override void Use(Player commandUser, string args) {
	//1 is rock, 2 paper, 3 scisors


//Use switch case
	if (commandUser.money >= 10) {

	Random random = new Random();

	int rpsbot = random.Next(1, 4);

	if (args=="rock") {
			if (rpsbot == 1) {
				Chat.MessageGlobal(commandUser.name  +  " %6 tied with rpsbot! %6 "  +  commandUser.name +  " %6 chose rock, rpsbot chose rock! %6 ");
				commandUser.SetMoney(commandUser.money - 10);
			}
			else if (rpsbot == 2) {
				Chat.MessageGlobal(commandUser.name  +  "%4 lost against rpsbot! %4 "  +  commandUser.name + " %4 chose rock, rpsbot chose paper! %4 ");
				commandUser.SetMoney(commandUser.money - 10);
			}
			else if (rpsbot == 3) {
				Chat.MessageGlobal(commandUser.name  +  " %2 won against rpsbot and got 15 coins! %2 "  +  commandUser.name  +  " %2 chose rock, rpsbot chose scissors! %2 ");
				commandUser.SetMoney(commandUser.money + 15);
			}//rps bot == 3
			}//args = rock

			if (args=="paper") {
			if (rpsbot == 1) {
				Chat.MessageGlobal(commandUser.name  +  " %2 won against rpsbot and got 15 coins! %2 "  +  commandUser.name  +  " %2 chose paper, rpsbot chose rock! %2 ");

				commandUser.SetMoney(commandUser.money + 15);
			}

			else if (rpsbot == 2) {
				Chat.MessageGlobal(commandUser.name  +  " %6 tied against rpsbot! %6 "  +  commandUser.name  +  " %6 chose paper, rpsbot chose paper! %6 ");
				commandUser.SetMoney(commandUser.money - 10);
			}
			else if (rpsbot == 3) {
				Chat.MessageGlobal(commandUser.name  +  " %4 lost against rpsbot! %4 "  +  commandUser.name  +  " %4 chose paper, rpsbot chose scissors! %4 ");
				commandUser.SetMoney(commandUser.money - 10);
			}
		}

		if (args=="scissors") {
			if (rpsbot == 1) {
				Chat.MessageGlobal(commandUser.name  +  " %4 lost against rpsbot %4 "  +  commandUser.name  +  " %4 chose scissors, rpsbot chose rock! %4 ");
				commandUser.SetMoney(commandUser.money - 10);
			}
			else if (rpsbot == 2) {
				Chat.MessageGlobal(commandUser.name  +  " %2 won against rpsbot and won 15 coins! %2 "  +  commandUser.name  +  " %2 chose scissors, rpsbot chose paper! %2 ");
				commandUser.SetMoney(commandUser.money + 15);
			}
			else if (rpsbot == 3) {
				Chat.MessageGlobal(commandUser.name  +  " %6 tied with rpsbot! %6 "  +  commandUser.name  +  " %6 chose scissors, rpsbot chose scissors! %6 ");
				commandUser.SetMoney(commandUser.money - 10);
			}
		}

	}//else if they have money

} //Game function






	}//CmdRps- Creation of command command

} //namespace
