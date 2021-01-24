namespace CommonCrd
{
    public static class Code
    {
        public static class GLB
        {
            public static string CnnString;
            public static string BaseAddress = "http://localhost:52956";
            public static string apiKey = @"apiKey=6395d6ea0";
        }
    }

    // Material para proximo video
    //<GridEvents RowSelected = "@RowSelectHandler" TValue="AmigosMd"></GridEvents>
    //public void RowSelectHandler(RowSelectEventArgs<AmigosMd> args)
    //{
    //    AmigosMd amg = args.Data;
    //    //  Navigates to data entry form
    //    navigationManager.NavigateTo($"/Alterar/{amg.RowId}");
    //}

    //<GridEditSettings AllowAdding = "true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog"></GridEditSettings>                       
    //<GridSelectionSettings Type = "Syncfusion.Blazor.Grids.SelectionType.Single" ></ GridSelectionSettings >
    //< GridPageSettings PageCount="5" PageSizes="true"></GridPageSettings>

    //string Campos = ""; string Valores = "";
    //PropertyInfo[] properties = typeof(AmigosMd).GetProperties();
    //            foreach (PropertyInfo p in properties)
    //            {
    //                Campos += p.Name + " ";
    //                Valores += $"'{ Amg.GetType().GetProperty( p.Name).GetValue( Amg, null) }', ";
    //                //p.SetValue( p.Name, value); ;
    //            }
}
