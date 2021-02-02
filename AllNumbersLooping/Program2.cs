using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace AllNumbersLooping {
	public class Program2 {
		class Player {
			// A delegate is to a Method
			// What an interface is to a class
			// Delegates are always Lists internally.
			// There can always be multiple ones.
			public delegate void HealthChangeDelegate(int newPlayerHealth);
			// Events can be subscribed to by other classes
			public event HealthChangeDelegate HealthChanged;
			int _health;
			
		
			public int Health {
				get => this._health;
				set {
					// use of property: validation
					if (value < 0)
						value = 0;
					this._health = value;
					// We can invoke our events
					this.HealthChanged?.Invoke(value);
				}
			}

			public Player(int health) {
				this.Health = health;
			}
		}

		class PlayerReachedHundredHealthAchievement {
			readonly Player player;

			void PlayerHealthUpdated(int health) {
				if(health >= 100)
					AchievementGained();
			}

			void AchievementGained() {
				Console.WriteLine("Congrats! Achievement Unlocked! Player Reached 100 Health!");
				// Other classes can unsubscribe from events
				this.player.HealthChanged-=PlayerHealthUpdated;
			}
			
			public PlayerReachedHundredHealthAchievement(Player player) {
				this.player = player;
				// Other classes can subscribe to events
				this.player.HealthChanged+=PlayerHealthUpdated;
			}
		}
		class PlayerReachedThousandHealthAchievement {
			readonly Player player;

			void PlayerHealthUpdated(int health) {
				if(health >= 1000)
					AchievementGained();
			}

			void AchievementGained() {
				Console.WriteLine("Congrats! Achievement Unlocked! Player Reached 1000 Health!");
				this.player.HealthChanged-=PlayerHealthUpdated;
			}
			
			public PlayerReachedThousandHealthAchievement(Player player) {
				this.player = player;
				this.player.HealthChanged+=PlayerHealthUpdated;
			}
		}

		class PlayerHud {
			void PlayerHealthUpdated(int health) {
				Console.WriteLine($"Player's Health: {health}");
			}

			public PlayerHud(Player player) {
				player.HealthChanged+=PlayerHealthUpdated;
			}
		}

		static void Main1() {
			var player = new Player(-10);
			
			// These constructions could happen ANYWHERE at ANY TIME:
			new PlayerHud(player);
			new PlayerReachedHundredHealthAchievement(player);
			new PlayerReachedThousandHealthAchievement(player);
			
			while (true) {
				Console.WriteLine("How do you want to change the player's health?");
				var healthChange = int.Parse(Console.ReadLine());
				player.Health += healthChange;
			}
		}
	}
}