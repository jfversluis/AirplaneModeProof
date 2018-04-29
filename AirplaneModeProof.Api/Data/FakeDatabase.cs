using System.Collections.Generic;
using AirplaneModeProof.Api.Models;

namespace AirplaneModeProof.Api.Data
{
	public static class FakeDatabase
	{
		public static IEnumerable<Superhero> Superheroes { get; }
		public static IEnumerable<Comic> Comics { get; }

		static FakeDatabase()
		{
			#region Setup Superheroes
			Superheroes = new List<Superhero>
			{
				new Superhero
				{
					Id = 1,
					Name = "Spiderman",
					Photo = "https://i.annihil.us/u/prod/marvel/i/mg/9/30/538cd33e15ab7/standard_xlarge.jpg",
					RealName = "Peter Benjamin Parker",
					Height = "1.77m",
					Power = "Peter can cling to most surfaces, has superhuman strength (able to lift 10 tons optimally) and is roughly 15 times more agile than a regular human.",
					Abilities = "Peter is an accomplished scientist, inventor and photographer.",
					Groups = "Avengers, formerly the Secret Defenders, \"New Fantastic Four\", the Outlaws"
				},
				new Superhero
				{
					Id = 2,
					Name = "Captain Marvel",
					Photo = "https://i.annihil.us/u/prod/marvel/i/mg/c/10/537ba5ff07aa4/standard_xlarge.jpg",
					RealName = "Carol Danvers",
					Height = "1.80m",
					Power = "Ms. Marvel's current powers include flight, enhanced strength, durability and the ability to shoot concussive energy bursts from her hands.",
					Abilities = "Ms. Marvel is a skilled pilot & hand to hand combatant",
					Groups = "Avengers, formerly Queen's Vengeance, Starjammers"
				},
				new Superhero
				{
					Id = 3,
					Name = "Hulk",
					Photo = "https://i.annihil.us/u/prod/marvel/i/mg/5/a0/538615ca33ab0/standard_xlarge.jpg",
					RealName = "Robert Bruce Banner",
					Height = "1.75m",
					Power = "The Hulk possesses an incredible level of superhuman physical ability.",
					Abilities = "Dr. Bruce Banner is a genius in nuclear physics, possessing a mind so brilliant that it cannot be measured on any known intelligence test. When Banner is the Hulk, Banner's consciousness is buried within the Hulk's, and can influence the Hulk's behavior only to a very limited extent.",
					Groups = "Formerly Avengers, Defenders, Fantastic Four, Pantheon, Horsemen of Apocalypse, Warbound"
				},
				new Superhero
				{
					Id = 4,
					Name = "Thor",
					Photo = "https://i.annihil.us/u/prod/marvel/i/mg/5/a0/537bc7036ab02/standard_xlarge.jpg",
					RealName = "Thor Odinson",
					Height = "1.98m",
					Power = "As the son of Odin and Gaea, Thor's strength, endurance and resistance to injury are greater than the vast majority of his superhuman race.",
					Abilities = "Thor is trained in the arts of war, being a superbly skilled warrior, highly proficient in hand-to-hand combat, swordsmanship and hammer throwing.",
					Groups = "Gods of Asgard, Avengers; formerly Queen’s Vengeance, Godpack, Thor Corps"
				},
				new Superhero
				{
					Id = 5,
					Name = "Iron Man",
					Photo = "https://i.annihil.us/u/prod/marvel/i/mg/6/a0/55b6a25e654e6/standard_xlarge.jpg",
					RealName = "Anthony Edward \"Tony\" Stark",
					Height = "1.85m",
					Power = "None; Tony's body had been enhanced by the modified techno-organic virus, Extremis, but it is currently inaccessible and inoperable.",
					Abilities = "Tony has a genius level intellect that allows him to invent a wide range of sophisticated devices, specializing in advanced weapons and armor. He possesses a keen business mind.",
					Groups = "The Avengers, Initiative, Hellfire Club (outer circle), S.H.I.E.L.D., Illuminati, Thunderbolts, Force Works, Queen's Vengeance, Alcoholics Anonymous"
				},
				new Superhero
				{
					Id = 6,
					Name = "Captain America",
					Photo = "https://i.annihil.us/u/prod/marvel/i/mg/3/50/537ba56d31087/standard_xlarge.jpg",
					RealName = "Steven \"Steve\" Rogers",
					Height = "1.87m",
					Power = "The Super-Soldier formula that he had metabolized had enhanced all of his bodily functions to the peak of human efficiency. Most notably, his body eliminates the excessive build-up of fatigue-producing poisons in his muscles, granting him phenomenal endurance.",
					Abilities = "Captain America had mastered the martial arts of American-style boxing and judo, and had combined these disciplines with his own unique hand-to-hand style of combat.",
					Groups = "Secret Avengers; formerly the Avengers, Invaders, Captain's Unnamed Superhero Team, Redeemers; formerly partner of Winter Soldier, Bucky, Jones, Rick, Rick Jones, Falcon (Sam Wilson), Falcon, Demolition Man and Nomad (Jack Monroe)"
				},
				new Superhero
				{
					Id = 7,
					Name = "Black Panther",
					Photo = "http://i.annihil.us/u/prod/marvel/i/mg/6/60/5261a80a67e7d/standard_xlarge.jpg",
					RealName = "T'Challa",
					Height = "1.83m",
					Power = "T'Challa's senses and physical attributes have been enhanced to superhuman levels by the heart-shaped herb.",
					Abilities = "T'Challa is a brilliant tactician, strategist, scientist, tracker and a master of all forms of unarmed combat whose unique hybrid fighting style incorporates acrobatics and aspects of animal mimicry. T'Challa being a royal descendent of a warrior race is also a master of armed combat, able to use a variety of weapons but prefers unarmed combat. He is a master planner who always thinks several steps ahead and will go to extreme measures to achieve his goals and protect the kingdom of Wakanda.",
					Groups = "Formerly Fantastic Four, Secret Avengers, Avengers, Pendragons, Queen's Vengeance, former Fantastic Force financier"
				},
				new Superhero
				{
					Id = 8,
					Name = "Black Widow",
					Photo = "http://i.annihil.us/u/prod/marvel/i/mg/f/30/50fecad1f395b/standard_xlarge.jpg",
					RealName = "Natalia \"Natasha\" Alianovna Romanova",
					Height = "1.70m",
					Power = "Government treatments have slowed her aging, augmented her immune system and enhanced her physical durability.",
					Abilities = "",
					Groups = "Formerly Thunderbolts, Avengers, S.H.I.E.L.D., Daredevil's Unnamed Super-Hero Team, Queen's Vengeance, Champions of Los Angeles, Lady Liberators, FSB, and K.G.B."
				},
				new Superhero
				{
					Id = 9,
					Name = "Doctor Strange",
					Photo = "http://i.annihil.us/u/prod/marvel/i/mg/5/f0/5261a85a501fe/standard_xlarge.jpg",
					RealName = "Stephen Vincent Strange",
					Height = "1.89m",
					Power = "Doctor Strange is one of the most powerful sorcerers in existence. Like most sorcerers, he draws his power from three primary sources: the invocation of powerful mystic entities or objects, the manipulation of the universe's ambient magical energy, and his own psychic resources. Strange's magical repertoire includes energy projection and manipulation, matter transformation, animation of inanimate objects, teleportation, illusion-casting, mesmerism, thought projection, astral projection, dimensional travel, time travel and mental possession, to name a few. The full range of his abilities is unknown. Doctor Strange's powers are sometimes less effective against strictly science-based opponents, although he can overcome this limitation with effort.",
					Abilities = "Doctor Strange is a skilled athlete and martial artist with substantial medical and magical knowledge. Though an expert surgeon, Strange's nerve-damaged hands prevent him from performing surgery except when supplemented by magic.",
					Groups = "Formerly Avengers, the Order, Defenders, Midnight Sons; former disciple of the Ancient One"
				},
				new Superhero
				{
					Id = 10,
					Name = "Hawkeye",
					Photo = "http://i.annihil.us/u/prod/marvel/i/mg/e/90/50fecaf4f101b/standard_xlarge.jpg",
					RealName = "Clinton Francis \"Clint\" Barton",
					Height = "1.91m",
					Power = "None. As Goliath, Barton used gases designed by Hank Pym to grow to great heights, with appropriate increases in strength and toughness. (He could also use them to shrink to minuscule size.)",
					Abilities = "Ronin is a world-class archer and marksman. His above average reflexes and hand-eye-coordination make him the most proficient archer ever known. He is also trained to throw knifes, darts, balls, bolas and boomerangs. He is natural athlete. He is also formidable unarmed combatant, thanks largely for longtime combat training with Captain America. He also has extensive training as an acrobat and aerialist. He is highly capable and charismatic team leader and a shrewd combat strategist, albeit sometimes reckless. Barton is also talented weapon designer, particularly well-versed in variations on basic traditional weaponry such as arrows, blades and hand-thrown projectiles. He has designed and crafted crescent darts, boomerangs, throwing irons, bolas, axes, custom arrows and bows. he is experienced motorcycle rider, Barton was one of the of the most proficient and daring pilots of the Avengers' supersonic Quinjets and other aircraft. He was once 80% deaf due to an injury, but his hearing was restored during his rebirth on Franklin Richards' Counter-Earth.",
					Groups = "Avengers; formerly founding member of Avengers West Coast and first chairman, Thunderbolts, S.H.I.E.L.D. (unofficial), Chain Gang 421-011, Shadows, Great Lakes Avengers, Cross Technological Enterprises, Defenders, Carson Carnival of Traveling Wonders, Tiboldt Circus (a.k.a. Circus of Crime), Queen's Vengeance; also briefly served as an agent for Silver Sable; former partner of Mockingbird, Two-Gun Kid, Black Widow, Trickshot, Swordsman"
				}
			};
			#endregion

			#region Setup Comics
			var comics = new List<Comic>();

			foreach (var hero in Superheroes)
			{
				comics.Add(new Comic
				{
					SuperheroId = hero.Id,
					Name = "Issue #1"
				});

				comics.Add(new Comic
				{
					SuperheroId = hero.Id,
					Name = "Issue #2"
				});

				comics.Add(new Comic
				{
					SuperheroId = hero.Id,
					Name = "Issue #42"
				});

				comics.Add(new Comic
				{
					SuperheroId = hero.Id,
					Name = "Issue #1337"
				});

				comics.Add(new Comic
				{
					SuperheroId = hero.Id,
					Name = "Issue #9000"
				});
			}

			Comics = new List<Comic>(comics);
			#endregion
		}
	}
}