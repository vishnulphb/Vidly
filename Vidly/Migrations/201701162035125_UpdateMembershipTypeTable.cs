namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql(" Update MembershipTypes set MembershipName = 'Pay As You Go' where Id='1' ");
            Sql(" Update MembershipTypes set MembershipName = 'Monthly' where Id='2' ");
            Sql(" Update MembershipTypes set MembershipName = 'Quarterly' where Id='3' ");
            Sql(" Update MembershipTypes set MembershipName = 'Yearly' where Id='4' ");
        }
        
        public override void Down()
        {
        }
    }
}
