using System;
using MCGalaxy.Events;
using MCGalaxy.Events.PlayerEvents;

//Pretty much forked kickjini plugin for ClassiCube. Does not stop all clients, just some clients, and classic client i think. Not for sure.

namespace MCGalaxy {
	
	public class PluginOnlyOneClient : Plugin_Simple {
		public override string creator { get { return "AnarchyDarkWolf"; } }
		public override string MCGalaxy_Version { get { return "1.9.0.0"; } }
		public override string name { get { return "OnlyOneClient"; } }
		
		public override void Load(bool startup) {
			OnPlayerConnectEvent.Register(DoOnlyOneClient, Priority.High);
		}
		
		public override void Unload(bool shutdown) {
			OnPlayerConnectEvent.Unregister(DoOnlyOneClient);
		}
		
		void DoOnlyOneClient(Player p) {
			string app = p.appName;			
			if (app != null && app.CaselessContains("classicube")) {
                
				return;
			}
            
            else {
                p.Leave("Only use the Classicube Client", true);
                p.cancellogin = true;
            }
		}
	}
}