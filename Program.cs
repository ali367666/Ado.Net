using ConnectionSQLAdoNet;

AdoNet ado=new AdoNet();

//ado.DeleteByID(1);
//ado.DeleteByName("Zeynal");
//ado.InsertValue("Ali","Ahmedov");
//ado.SelectAll();
//ado.InsertedByName("Fazil");
//ado.AddColumn("Names", "City", "nvarchar(50)");

//ado.DropTable("Test1");

ado.UpdateTableByName("Names", "Ulvi", "Ali");