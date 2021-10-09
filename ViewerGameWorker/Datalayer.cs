using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerGameWorker
{
    public class ViewerGameContext : DbContext
    {
        public ViewerGameContext(string db) : base(db)
        {
            
            Database.SetInitializer(new CreateDatabaseIfNotExists<ViewerGameContext>());
        }
        
        public DbSet<Viewer> Viewers { get; set; }
        public DbSet<BattleCard> BattleCards { get; set; }
        public DbSet<ActionCard> ActionCards { get; set; }
    }


    public class Viewer
    {
        public int ID { get; set; }
        public string UserName { get; set; } //This should be the miror value of Twitch name
        public string UserId { get; set; } //This should be the miror value of Twitch name
        public string DiscordTag { get; set; } //This should be the miror value of Twitch name
        public virtual ICollection<BattleCard> OwnedBattleCard { get; set; }
        public virtual ICollection<ActionCard> OwnedActionCard { get; set; }
        public decimal Money { get; set; }
        public int Points { get; set; } //Viewer gain points by sending messages (porportional to median long message of 12 chars), and misc event of twitch IRC API

    }
    public class Card
    {
        public int ID { get; set; }
        public string CardName { get; set; }
        public int Rarity { get; set; } //1 => Basique, 2 => Commun, 3 => Rare, 4 => Epique, 5 => Legendaire

    }

    public class BattleCard : Card// A game card 
    {
        public int Life { get; set; }
        public int Attaque { get; set; }
        public int Defense { get; set; }
        public object Picture { get; set; }
        public string Description { get; set; }
        public string Ability1 { get; set; } //Represent The Name of the Ability that refers to a Metho in the Game algo
        public string Ability2 { get; set; } //Represent The Name of the Ability that refers to a Metho in the Game algo
        public Card ToCard()
        {
            return new Card() { ID = this.ID, CardName = this.CardName, Rarity = this.Rarity };
        }
    }
    public class ActionCard : Card
    {
        public object Picture { get; set; }
        public string Description { get; set; }
        public string DiscordAbility { get; set; } //Represent The Name of the Ability that refers to a Metho in the Discord Bot
        public string TwitchAbility { get; set; } //Represent The Name of the Ability that refers to a Metho in the Twitch Bot
        public Card ToCard()
        {
            return new Card() { ID = this.ID, CardName = this.CardName, Rarity = this.Rarity };
        }
    }
}
