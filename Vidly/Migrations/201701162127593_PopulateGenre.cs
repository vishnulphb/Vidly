namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres(Id,Name) values('1','Action')");
            Sql("Insert into Genres(Id,Name) values('2','Comedy')");
            Sql("Insert into Genres(Id,Name) values('3','Drama')");
            Sql("Insert into Genres(Id,Name) values('4','Horror')");
            Sql("Insert into Genres(Id,Name) values('5','Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
