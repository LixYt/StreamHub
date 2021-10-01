using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections;

namespace StreamerGame
{
    public class StreamerGameContext : DbContext
    {

        public StreamerGameContext() : base("StreamerGameContext")
        {

        }

        public DbSet<Viewer> Viewers { get; set; }
        public DbSet<BattleCard> BattleCards { get; set; }
        public DbSet<ActionCard> ActionCards { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class ObservableListSource<T> : ObservableCollection<T>, IListSource
            where T : class
    {
        private IBindingList _bindingList;

        bool IListSource.ContainsListCollection { get { return false; } }

        IList IListSource.GetList()
        {
            return _bindingList ??= this.ToBindingList();
        }
    }

    public class Viewer
    {
        public int ID { get; set; }
        public string UserName { get; set; } //This should be the miror value of Twitch name
        public string UserId { get; set; } //This should be the miror value of Twitch name
        public string UserType { get; set; } //This should be the miror value of Twitch name
        public virtual ObservableListSource<BattleCard> OwnedBattleCard { get; set; }
        public virtual ObservableListSource<ActionCard> OwnedActionCard { get; set; }
        public decimal Money { get; set; }
    }
    public class BattleCard // A game card 
    {
        public int ID { get; set; }
        public string CardName { get; set; }
        public int Life { get; set; }
        public int Attaque { get; set; }
        public int Defense { get; set; }
        public object Picture { get; set; }
        public string Description { get; set; }
        public int Rarity { get; set; } //Higher the value is, rarest the card is.
        public string Ability1 { get; set; } //Represent The Name of the Ability that refers to a Metho in the Discord Bot
        public string Ability2 { get; set; } //Represent The Name of the Ability that refers to a Metho in the Discord Bot
    }
    public class ActionCard
    {
        public int ID { get; set; }
        public string CardName { get; set; }
        public object Picture { get; set; }
        public string Description { get; set; }
        public int Rarity { get; set; } //Higher the value is, rarest the card is.
        public string DiscordAbility { get; set; } //Represent The Name of the Ability that refers to a Metho in the Discord Bot
        public string TwitchAbility { get; set; } //Represent The Name of the Ability that refers to a Metho in the Twitch Bot
    }
    

}
