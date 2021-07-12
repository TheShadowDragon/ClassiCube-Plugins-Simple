//DailyScratchCard (DSC)

using System;
using MCGalaxy;
using MCGalaxy.Commands;
using System.Collections.Generic;



namespace MegaCraft
{
	public sealed class dsc : Plugin {
		public override string name {get {return "ScratchCard"; } }
		public override string creator { get { return "DarkWolf"; } }
		public override string MCGalaxy_Version { get { return "1.9.1.9"; } }




		public override void Load(bool startup) {
			Command.Register(new CmdRps());
			Chat.MessageGlobal("The Scratchcard plugin loaded!");
		}//bool start up

		public override void Unload(bool shutdown) {
				 Command.Unregister(Command.Find("dsc"));

      Chat.MessageGlobal("&cThe Scratchcard plugin has unloaded for you!");
		}//Bool Shutdown
	} //Public Sealed Class

	public class CmdRps : Command {
		public override string name { get { return "Scratchcard"; }}
		public override string shortcut { get {return "sc"; }}
		public override string type { get { return "games"; }}

	public override LevelPermission defaultRank { get { return LevelPermission.Guest; }}

    
        
	public override void Help(Player commandUser) {
	      Player.Message(commandUser, "%T/ScratchCard");
	      Player.Message(commandUser, "%HAbility to earn 100 coins at the cost of 50 coins!");
	  }// Player command User for /help
        
        static readonly object locker = new object();
		static Dictionary<string, DateTime> cooldowns = new Dictionary<string, DateTime>();

        

public override void Use(Player commandUser, string args) {
    
    
    
    TimeSpan coolDown = GetCooldown(commandUser);
		if (coolDown.TotalSeconds > 0) {
			coolDown += new TimeSpan(0, 0, 0, 1, 0);
			commandUser.Message("&4You can only scratch every 5 seconds!");
			return;
		}

		InitiateScDelay(commandUser, 5000);
    
        if (commandUser.money < 50) {
            
         commandUser.Message(" %8 You don't have enough money to buy a scratchcard!");   
            
        }
        
        else {

		Random random = new Random();
		int DscOutcome = random.Next(0, 91);
        int costrandom = random.Next(30, 51);
		commandUser.SetMoney (commandUser.money - costrandom);
		commandUser.SetMoney (commandUser.money + DscOutcome);
        Chat.MessageGlobal(commandUser.ColoredName + " %ahas won " + DscOutcome + " %acoins at the loss of " + costrandom + " %aMegaCoins!%a");
        }
} //Game function

        
public static void InitiateScDelay(Player commandUser, int milliseconds) {
	TimeSpan coolDown = TimeSpan.FromMilliseconds(milliseconds);
	lock (locker) { cooldowns[commandUser.name] = DateTime.UtcNow + coolDown; }
}

TimeSpan GetCooldown(Player commandUser) {
	DateTime expires;
	lock (locker) { cooldowns.TryGetValue(commandUser.name, out expires); }
	return expires - DateTime.UtcNow;
}








	}//CmdRps- Creation of command command

} //namespace
